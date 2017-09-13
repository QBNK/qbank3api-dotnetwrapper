using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class MediaUsageResponse
    {
        /// <summary>
        ///
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime Deleted { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int UpdatedBy { get; set; }
    }
}