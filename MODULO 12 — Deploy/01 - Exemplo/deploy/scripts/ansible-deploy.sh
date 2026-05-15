#!/usr/bin/env bash
# Terraform (se necessário) + inventário + Ansible em etapas visíveis.
#
# Uso:
#   ./deploy/scripts/ansible-deploy.sh azure
#   ./deploy/scripts/ansible-deploy.sh aws
#   ./deploy/scripts/ansible-deploy.sh azure --tags etapa2
#   ./deploy/scripts/ansible-deploy.sh azure --skip-terraform

set -euo pipefail

if [[ $# -lt 1 ]]; then
  echo "Uso: $0 <azure|aws> [opções ansible-playbook...]" >&2
  exit 1
fi

CLOUD="$1"
shift

SKIP_TERRAFORM=false
EXTRA_ARGS=()
for arg in "$@"; do
  if [[ "$arg" == "--skip-terraform" ]]; then
    SKIP_TERRAFORM=true
  else
    EXTRA_ARGS+=("$arg")
  fi
done

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
DEPLOY_DIR="$(cd "${SCRIPT_DIR}/.." && pwd)"
ANSIBLE_DIR="${DEPLOY_DIR}/ansible"
INVENTORY="${ANSIBLE_DIR}/inventory/hosts.${CLOUD}.yml"

if [[ "$SKIP_TERRAFORM" != true ]]; then
  echo ">> Terraform apply (${CLOUD})"
  (cd "${DEPLOY_DIR}/terraform/${CLOUD}" && terraform apply -auto-approve)
fi

echo ">> Gerar inventário Ansible"
"${SCRIPT_DIR}/generate-inventory.sh" "$CLOUD"

echo ">> Aguardar SSH (até 3 min)"
IP="$(cd "${DEPLOY_DIR}/terraform/${CLOUD}" && terraform output -raw public_ip)"
USER="$([[ "$CLOUD" == azure ]] && echo azureuser || echo ubuntu)"
SSH_KEY="${SSH_KEY:-$HOME/.ssh/id_ed25519}"
for i in $(seq 1 18); do
  if ssh -o StrictHostKeyChecking=accept-new -o ConnectTimeout=5 -i "$SSH_KEY" "${USER}@${IP}" "echo ok" 2>/dev/null; then
    echo "   SSH disponível"
    break
  fi
  sleep 10
done

if ! command -v ansible-playbook >/dev/null; then
  echo "Instale o Ansible: brew install ansible" >&2
  exit 1
fi

echo ">> Instalar collections Ansible (community.docker, ansible.posix)"
ansible-galaxy collection install -r "${ANSIBLE_DIR}/requirements.yml"

echo ">> Ansible playbook (etapas 1 → 2 → 3)"
cd "$ANSIBLE_DIR"
ansible-playbook -i "$INVENTORY" playbook.yml "${EXTRA_ARGS[@]}"

echo ">> Concluído"
terraform -chdir="${DEPLOY_DIR}/terraform/${CLOUD}" output web_url 2>/dev/null || true
