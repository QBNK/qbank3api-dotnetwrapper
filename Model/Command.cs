using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class Command : RestResponse
    {
        /// <summary>
        /// The name of the command
        /// </summary>
        public string Class { get; set; }
    }
}