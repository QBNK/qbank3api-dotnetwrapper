using System;
using QBankApi.Model;
using RestSharp;
using RestSharp.Authenticators;

namespace QBankApi
{
    public class OAuth2Authenticator : IAuthenticator
    {
        readonly string _clientId;
        readonly string _clientSecret;
        readonly string _username;
        readonly string _password;

        private RestClient _authClient;

        private TokenResponse _token;

        private readonly object _lockObject = new object();

        internal TokenResponse Token
        {
            get
            {
                lock (_lockObject)
                {
                    return _token;
                }
            }
            private set
            {
                lock (_lockObject)
                {
                    _token = value;
                }
            }
        }

        public OAuth2Authenticator(Credentials credentials)
        {
            _password = credentials.Password;
            _username = credentials.UserName;
            _clientSecret = credentials.ClientSecret;
            _clientId = credentials.ClientId;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (_authClient == null)
            {
                _authClient = new RestClient(client.BaseUrl);
            }

            if (Token == null || Token.IsExpired())
            {
                GetAccessTokenWithClientCredentials(_username, _password);
            }
            else if (Token != null && Token.IsExpired() && Token.RefreshToken != null)
            {
                GetAccessTokenWithRefreshToken(Token.RefreshToken);
            }

            if (Token != null)
            {
                request.Resource += "?access_token={token}";
                request.AddUrlSegment("token", _token.AccessToken);
            }

            //request.AddParameter("access_token", Token == null ? string.Empty : Token.AccessToken);
        }

        protected void GetAccessTokenWithClientCredentials(string username, string password)
        {
            _authClient.Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret);

            RestRequest request = new RestRequest("oauth2/token", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            TokenResponse response = _authClient.Execute<TokenResponse>(request).Data;
            if (response != null)
                response.Issued = DateTime.Now;
            Token = response;
        }

        protected void GetAccessTokenWithRefreshToken(string refreshToken)
        {
        }
    }
}