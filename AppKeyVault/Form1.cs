using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using static System.Net.WebRequestMethods;


namespace AppKeyVault
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NECESITAMOS CREAR OPCIONES DE COMO RECUPERAR LA CLAVE
            //DEBEMOS INDICAR EL NUMERO DE REINTENTOS ANTES DE UN ERROR
            SecretClientOptions options = new SecretClientOptions
            {
                Retry =
                {
                    Delay = TimeSpan.FromSeconds(3),
                    MaxDelay = TimeSpan.FromSeconds(15),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                }
            };
            string urlkeyvault = "https://mykeyvaultdcc.vault.azure.net/";
            Uri uri = new Uri(urlkeyvault);
            SecretClient client = new SecretClient(uri, new DefaultAzureCredential(), options);
            KeyVaultSecret secret = client.GetSecret("passwordchampions");
            string value= secret.Value;
            this.label1.Text = value;
        }
    }
}