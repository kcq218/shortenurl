Update-AzFunctionApp -Name 'urlshortenerkgs' -ResourceGroupName 'rg-urlshortener-prod-uswest-001' -IdentityType SystemAssigned
Update-AzFunctionApp -Name 'urlrdi' -ResourceGroupName 'rg-urlshortener-prod-uswest-001' -IdentityType SystemAssigned
Update-AzFunctionApp -Name 'urlread' -ResourceGroupName 'rg-urlshortener-prod-uswest-001' -IdentityType SystemAssigned

# Create Key Vault
New-AzKeyVault -Name "kv-urlshortener-prod" -ResourceGroupName 'rg-urlshortener-prod-uswest-001' -Location "WestUS"
