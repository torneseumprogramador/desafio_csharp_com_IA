variable "project_name" {
  type        = string
  description = "Prefixo dos recursos na AWS."
  default     = "ecommerce"
}

variable "environment" {
  type        = string
  description = "Ambiente (dev, staging, prod)."
  default     = "dev"
}

variable "aws_region" {
  type        = string
  description = "Região AWS (ex.: sa-east-1, us-east-1)."
  default     = "sa-east-1"
}

variable "instance_type" {
  type        = string
  description = "Tipo da instância EC2."
  default     = "t3.small"
}

variable "admin_username" {
  type        = string
  description = "Utilizador SSH da instância Ubuntu."
  default     = "ubuntu"
}

variable "ssh_public_key" {
  type        = string
  description = "Conteúdo da chave pública SSH (ex.: conteúdo de id_rsa.pub)."
}

variable "allowed_ssh_cidr" {
  type        = string
  description = "CIDR autorizado para SSH (restringir ao seu IP em produção)."
  default     = "0.0.0.0/0"
}
