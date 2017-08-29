using System;
using RestSharp;
using RestSharp.Deserializers;

namespace QBankApi.Model
{
    internal class TokenResponse : RestResponse
    {
        /// <summary>Gets or sets the access token issued by the authorization server.</summary>
        [DeserializeAs(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the token type as specified in http://tools.ietf.org/html/rfc6749#section-7.1.
        /// </summary>
        [DeserializeAs(Name = "token_type")]
        public string TokenType { get; set; }

        /// <summary>Gets or sets the lifetime in seconds of the access token.</summary>
        [DeserializeAs(Name = "expires_in")]
        public long? ExpiresInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the refresh token which can be used to obtain a new access token.
        /// For example, the value "3600" denotes that the access token will expire in one hour from the time the
        /// response was generated.
        /// </summary>
        [DeserializeAs(Name = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the scope of the access token as specified in http://tools.ietf.org/html/rfc6749#section-3.3.
        /// </summary>
        [DeserializeAs(Name = "scope")]
        public string Scope { get; set; }

        /// <summary>The date and time that this token was issued. <remarks>
        /// It should be set by the CLIENT after the token was received from the server.
        /// </remarks>
        /// </summary>
        public DateTime Issued { get; set; }

        /// <summary>
        /// Returns <c>true</c> if the token is expired or it's going to be expired in the next minute.
        /// </summary>
        public bool IsExpired()
        {
            if (AccessToken == null || !ExpiresInSeconds.HasValue)
            {
                return true;
            }

            return Issued.AddSeconds(ExpiresInSeconds.Value + 60) <= DateTime.Now;
        }
    }
}