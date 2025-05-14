// infra/outputs.tf

output "resource_group" {
  description = "Resource Group name"
  value       = azurerm_resource_group.rg.name
}

output "acr_login_server" {
  description = "ACR login server (registry URL)"
  value       = azurerm_container_registry.acr.login_server
}

output "aks_fqdn" {
  description = "AKS API server FQDN"
  value       = azurerm_kubernetes_cluster.aks.fqdn
}
