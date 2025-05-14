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

output "kube_config" {
  description = "Raw kubeconfig for AKS user authentication"
  value       = azurerm_kubernetes_cluster.aks.kube_config[0].raw_config
  sensitive   = true
}

output "kube_admin_config" {
  description = "Raw kubeconfig for AKS admin authentication"
  value       = azurerm_kubernetes_cluster.aks.kube_admin_config[0].raw_config
  sensitive   = true
}
