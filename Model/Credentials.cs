namespace QBankApi.Model
{
    public class Credentials
    {
        public string ClientId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string ClientSecret { get; private set; }

        public Credentials(string clientId, string userName, string password, string clientSecret = "")
        {
            ClientId = clientId;
            UserName = userName;
            Password = password;
            ClientSecret = clientSecret;
        }
    }
}