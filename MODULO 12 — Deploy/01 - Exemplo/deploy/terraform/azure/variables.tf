variable "project_name" {
  type        = string
  description = "Prefixo dos recursos na Azure."
  default     = "ecommerce"
}

variable "environment" {
  type        = string
  description = "Ambiente (dev, staging, prod)."
  default     = "dev"
}

variable "location" {
  type        = string
  description = "Região Azure (ex.: brazilsouth, eastus)."
  default     = "brazilsouth"
}

variable "vm_size" {
  type        = string
  description = "SKU da VM Linux."
  default     = "Standard_B2s"
}

variable "admin_username" {
  type        = string
  description = "Utilizador SSH da VM Ubuntu."
  default     = "azureuser"
}

variable "ssh_public_key" {
  type        = string
  description = "Conteúdo da chave pública SSH (ex.: conteúdo de id_rsa.pub)."
}

variable "allowed_ssh_cidr" {
  type        = string
  description = "CIDR autorizado para SSH (restringir ao seu IP em produção)."
  default     = "*"
}
