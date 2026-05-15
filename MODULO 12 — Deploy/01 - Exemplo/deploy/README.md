# Deploy — Ecommerce (Módulo 11)

**Terraform** cria a VM (Azure ou AWS). **Ansible** configura o servidor em **etapas visíveis** e faz o deploy da stack **MySQL + API + Web**.

## Estrutura

```
deploy/
├── docker-compose.yml
├── .env.example
├── ansible/
│   ├── playbook.yml              # Etapa 1 → 2 → 3
│   ├── requirements.yml          # community.docker, ansible.posix
│   ├── inventory/
│   │   ├── hosts.azure.yml       # gerado (não versionar)
│   │   └── hosts.aws.yml
│   └── roles/
│       ├── common/               # Etapa 1 — pacotes e /opt/ecommerce
│       ├── docker/               # Etapa 2 — Docker + Compose plugin
│       └── ecommerce/            # Etapa 3 — código + docker compose up
├── scripts/
│   ├── ansible-deploy.sh         # fluxo completo recomendado
│   ├── generate-inventory.sh
│   └── publish-to-server.sh      # legado → redireciona para Ansible
└── terraform/
    ├── azure/
    └── aws/
```

## Pré-requisitos

- Terraform >= 1.5
- [Ansible](https://docs.ansible.com/) >= 2.14 (`brew install ansible`)
- Azure: `az login` + subscrição ativa (`az account set --subscription "..."`)
- AWS: `aws configure`
- Chave SSH (`~/.ssh/id_ed25519` ou `id_rsa`)

## Fluxo recomendado (tudo automatizado)

**Azure:**
```bash
chmod +x deploy/scripts/*.sh
./deploy/scripts/ansible-deploy.sh azure
```

**AWS:**
```bash
./deploy/scripts/ansible-deploy.sh aws
```

O script executa: `terraform apply` → inventário → `ansible-playbook` (3 etapas).

## Acompanhar cada etapa

Listar tarefas:
```bash
cd deploy/ansible
ansible-playbook -i inventory/hosts.azure.yml playbook.yml --list-tasks
```

Só uma etapa:
```bash
ansible-playbook -i inventory/hosts.azure.yml playbook.yml --tags etapa1   # pacotes
ansible-playbook -i inventory/hosts.azure.yml playbook.yml --tags etapa2   # docker
ansible-playbook -i inventory/hosts.azure.yml playbook.yml --tags etapa3   # app
```

VM já criada (sem Terraform de novo):
```bash
./deploy/scripts/generate-inventory.sh azure
cd deploy/ansible
ansible-galaxy collection install -r requirements.yml
ansible-playbook -i inventory/hosts.azure.yml playbook.yml
```

Ou:
```bash
./deploy/scripts/ansible-deploy.sh azure --skip-terraform
```

## Terraform (manual)

```bash
cd deploy/terraform/azure   # ou aws
cp terraform.tfvars.example terraform.tfvars
terraform init && terraform apply
```

No `az login`, escolha o **número** da lista (ex.: `1`), não o GUID da subscrição.

## Docker local (sem VM)

```bash
cd deploy
cp .env.example .env
docker compose up --build
```

## URLs na VM

| Serviço | Porta |
|---------|-------|
| Admin (Web) | `http://<IP>:5260/admin` |
| Swagger (API) | `http://<IP>:5047/swagger` |

## Destruir

```bash
cd deploy/terraform/azure   # ou aws
terraform destroy
```
