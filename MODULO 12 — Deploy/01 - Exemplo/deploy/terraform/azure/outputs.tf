output "resource_group_name" {
  value = azurerm_resource_group.this.name
}

output "public_ip" {
  description = "IP público da VM de deploy."
  value       = azurerm_public_ip.this.ip_address
}

output "ssh_command" {
  value = "ssh ${var.admin_username}@${azurerm_public_ip.this.ip_address}"
}

output "web_url" {
  value = "http://${azurerm_public_ip.this.ip_address}:5260/admin"
}

output "api_swagger_url" {
  value = "http://${azurerm_public_ip.this.ip_address}:5047/swagger"
}
