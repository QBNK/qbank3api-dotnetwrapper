using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class SearchSort : RestResponse
    {
        /// <summary>
        /// Field to sort by
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Sort Direction
        /// </summary>
        public string SortDirection { get; set; }

        /// <summary>
        /// When sorting on Media Popularity, the source to check (QBank Backend, frontend, etc)
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// When sorting on Media Popularity, a optional dateRange to find popular media within
        /// </summary>
        public DateTimeRange DateRange { get; set; }

        /// <summary>
        /// When sorting on a property, the system name of the property to sort on
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// When sorting on a Json Property, the Json key to sort by
        /// </summary>
        public string JsonKey { get; set; }

        /// <summary>
        /// When sorting on deploymentdate, the optional site id to sort by
        /// </summary>
        public int DeploymentSiteId { get; set; }
    }
}