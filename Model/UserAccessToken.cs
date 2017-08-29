using System;

namespace QBankApi.Model
{
    internal class UserAccessToken
    {
        public string UserName { get; set; }
        public TokenResponse Token { get; set; }
        public DateTime Expires { get; set; }
    }
}