#!/usr/bin/env bash
# Encaminha para o fluxo Ansible (substitui rsync manual).
#
# Uso legado:
#   ./deploy/scripts/publish-to-server.sh <IP> azureuser
# Preferível:
#   ./deploy/scripts/ansible-deploy.sh azure --skip-terraform

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

if [[ $# -ge 1 ]]; then
  echo "Este script foi substituído pelo Ansible." >&2
  echo "Se a VM já existe, gere o inventário e rode o playbook:" >&2
  echo "  ./deploy/scripts/generate-inventory.sh azure   # ou aws" >&2
  echo "  cd deploy/ansible && ansible-playbook -i inventory/hosts.azure.yml playbook.yml" >&2
  exit 1
fi

exec "${SCRIPT_DIR}/ansible-deploy.sh" azure "$@"
