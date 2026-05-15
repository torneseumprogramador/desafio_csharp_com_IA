#!/usr/bin/env bash
# Gera inventário Ansible a partir do output do Terraform.
#
# Uso:
#   ./deploy/scripts/generate-inventory.sh azure
#   ./deploy/scripts/generate-inventory.sh aws

set -euo pipefail

if [[ $# -ne 1 ]]; then
  echo "Uso: $0 <azure|aws>" >&2
  exit 1
fi

CLOUD="$1"
SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
DEPLOY_DIR="$(cd "${SCRIPT_DIR}/.." && pwd)"
ANSIBLE_INV="${DEPLOY_DIR}/ansible/inventory"
SSH_KEY="${SSH_KEY:-$HOME/.ssh/id_ed25519}"

case "$CLOUD" in
  azure)
    TF_DIR="${DEPLOY_DIR}/terraform/azure"
    USER="azureuser"
  ;;
  aws)
    TF_DIR="${DEPLOY_DIR}/terraform/aws"
    USER="ubuntu"
  ;;
  *)
    echo "Cloud inválida: $CLOUD (use azure ou aws)" >&2
    exit 1
  ;;
esac

IP="$(cd "$TF_DIR" && terraform output -raw public_ip)"
OUT="${ANSIBLE_INV}/hosts.${CLOUD}.yml"

mkdir -p "$ANSIBLE_INV"

cat > "$OUT" <<EOF
---
# Gerado por generate-inventory.sh em $(date -u +"%Y-%m-%dT%H:%M:%SZ")
all:
  children:
    ecommerce:
      hosts:
        ${CLOUD}_vm:
          ansible_host: ${IP}
          ansible_user: ${USER}
          ansible_ssh_private_key_file: ${SSH_KEY}
EOF

echo ">> Inventário: ${OUT}"
echo "   Host: ${USER}@${IP}"
