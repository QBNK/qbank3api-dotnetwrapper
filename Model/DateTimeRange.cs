using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class DateTimeRange
    {
        /// <summary>
        /// Minimum date in this range, leave empty for none.
        /// </summary>
        public DateTime Min { get; set; }

        /// <summary>
        /// Maximum date in this range, leave empty for none.
        /// </summary>
        public DateTime Max { get; set; }
    }
}