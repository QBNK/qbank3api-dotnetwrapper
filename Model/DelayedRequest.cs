using RestSharp;

namespace QBankApi.Model
{
    internal class DelayedRequest
    {
        internal Method Method { get; set; }
        internal string Endpoint { get; set; }
        internal ClientRequest Parameters { get; set; }
    }
}