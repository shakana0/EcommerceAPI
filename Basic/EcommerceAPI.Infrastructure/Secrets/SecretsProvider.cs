using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace EcommerceAPI.Infrastructure.Secrets
{
    public class SecretsProvider
    {
        private readonly SecretClient _licenseClient;
        private readonly SecretClient _connstrClient;

        public SecretsProvider(IConfiguration config)
        {
            TokenCredential credential;

            var runningInAzure = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME"));

            if (runningInAzure)
            {
                credential = new ManagedIdentityCredential();
            }
            else
            {
                credential = new DefaultAzureCredential();
            }

            _licenseClient = new SecretClient(new Uri("https://luckypenny-license-key.vault.azure.net/"), credential);
            _connstrClient = new SecretClient(new Uri("https://connstr-ecomdb.vault.azure.net/"), credential);
        }

        public string GetLicenseKey()
        {
            try
            {
                return _licenseClient.GetSecret("LicenseKey").Value.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Key Vault error (LicenseKey): {ex.Message}");
                return string.Empty;
            }
        }

        public string GetConnectionString()
        {
            try
            {
                var runningInAzure = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME"));

                if (runningInAzure)
                {
                    // Prod secret Managed Identity
                    var secret = _connstrClient.GetSecret("EcommerceDb");
                    return secret.Value.Value;
                }
                else
                {
                    // Dev secret SQL login or AAD password
                    var secret = _connstrClient.GetSecret("EcommerceDb-Dev");
                    return secret.Value.Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Key Vault error (EcommerceDb): {ex.Message}");
                return string.Empty;
            }
        }
    }
}
