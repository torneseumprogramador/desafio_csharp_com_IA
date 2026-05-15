output "instance_id" {
  value = aws_instance.this.id
}

output "public_ip" {
  description = "IP público da instância de deploy."
  value       = aws_instance.this.public_ip
}

output "ssh_command" {
  value = "ssh ${var.admin_username}@${aws_instance.this.public_ip}"
}

output "web_url" {
  value = "http://${aws_instance.this.public_ip}:5260/admin"
}

output "api_swagger_url" {
  value = "http://${aws_instance.this.public_ip}:5047/swagger"
}
