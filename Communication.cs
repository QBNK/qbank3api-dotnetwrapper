using System;
using RestSharp;

namespace QBankApi
{
    public abstract class Communication
    {
        readonly RestClient _client;

        internal Communication(string apiAddress, OAuth2Authenticator authenticator)
        {
            if (!string.IsNullOrWhiteSpace(apiAddress))
            {
                _client = new RestClient(new Uri(apiAddress)) {Authenticator = authenticator};
            }
        }

        internal T Execute<T>(RestRequest request) where T : new()
        {
            if (_client == null)
            {
                return default(T);
            }

            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var qbankException = new ApplicationException(message, response.ErrorException);
                throw qbankException;
            }
            return response.Data;
        }

        internal OAuth2Authenticator OAuth2Authenticator => _client?.Authenticator as OAuth2Authenticator;
    }
}