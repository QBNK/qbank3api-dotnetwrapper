using System.Collections.Generic;

namespace QBankApi.Model
{
    //NOT RELATED TO QBANK MODELS
    internal class ClientRequest
    {
        public Dictionary<object, object> Query { get; set; }
        public string Body { get; set; }
        public Dictionary<object, object> Headers { get; set; }
    }
}