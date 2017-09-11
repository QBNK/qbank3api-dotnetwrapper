using System;
using RestSharp;

namespace QBankApi
{
    public abstract class Communication
    {
	    public RestClient Client { get; }

        protected Communication(string apiAddress, OAuth2Authenticator authenticator)
        {
            if (!string.IsNullOrWhiteSpace(apiAddress))
            {
				Client = new RestClient(new Uri(apiAddress)) {Authenticator = authenticator};
            }
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            if (Client == null)
            {
                return default(T);
            }

            var response = Client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var qbankException = new ApplicationException(message, response.ErrorException);
                throw qbankException;
            }
            return response.Data;
        }

        protected OAuth2Authenticator OAuth2Authenticator => Client?.Authenticator as OAuth2Authenticator;
    }
}