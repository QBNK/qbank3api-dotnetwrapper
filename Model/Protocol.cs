using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class Protocol
    {
        /// <summary>
        /// The Protocol identifier.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The human readable description of the Protocol.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Protocol name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Protocol definition. Describes the needed values and other parameters.
        /// </summary>
        public object Definition { get; set; }
    }
}