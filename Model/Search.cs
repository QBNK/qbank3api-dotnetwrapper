using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class Search
    {
        /// <summary>
        /// Starting offset of the search
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The number of results to return
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// A freetext string to search for, operators like and/or/not and grouping by parentheses is available
        /// </summary>
        public string FreeText { get; set; }

        /// <summary>
        /// An array with ObjectIds to filter by
        /// </summary>
        public List<int> ObjectIds { get; set; }

        /// <summary>
        /// An array with MediaIds to filter by
        /// </summary>
        public List<int> MediaIds { get; set; }

        /// <summary>
        /// Filter by creators of Media
        /// </summary>
        public List<int> CreatedByIds { get; set; }

        /// <summary>
        /// Filter by created date
        /// </summary>
        public DateTimeRange CreatedRange { get; set; }

        /// <summary>
        /// Filter by updaters of Media
        /// </summary>
        public List<int> UpdatedByIds { get; set; }

        /// <summary>
        /// Filter by updated date
        /// </summary>
        public DateTimeRange UpdatedRange { get; set; }

        /// <summary>
        /// An array with MediaStatuses to filter by
        /// </summary>
        public List<int> MediaStatusIds { get; set; }

        /// <summary>
        /// An array with FolderIds to search within
        /// </summary>
        public List<int> FolderIds { get; set; }

        /// <summary>
        /// The depth of folders to fetch objects from when doing folder searches
        /// </summary>
        public int FolderDepth { get; set; }

        /// <summary>
        /// An array with MoodboardIds to search within
        /// </summary>
        public List<int> MoodboardIds { get; set; }

        /// <summary>
        /// An array with CategoryIds to search within
        /// </summary>
        public List<int> CategoryIds { get; set; }

        /// <summary>
        /// Indicates that we should ignore grouping and return child objects in the result
        /// </summary>
        public bool IgnoreGrouping { get; set; }

        /// <summary>
        /// Search for media that have this media as parent
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// An array with DeploymentSiteIds to search within
        /// </summary>
        public List<int> DeploymentSiteIds { get; set; }

        /// <summary>
        /// An array of Properties to filter by
        /// </summary>
        public List<PropertyCriteria> Properties { get; set; }

        /// <summary>
        /// Filter by file size. An array with "min" and/or "max" values.
        /// </summary>
        public List<string> FileSizeCriteria { get; set; }

        /// <summary>
        /// Filter by file width. An array with "min" and/or "max" values.
        /// </summary>
        public List<string> WidthCriteria { get; set; }

        /// <summary>
        /// Filter by file height. An array with "min" and/or "max" values.
        /// </summary>
        public List<string> HeightCriteria { get; set; }

        /// <summary>
        /// Filter by mime type. An array of normal LIKE database syntax, for example image/% will return all images, video/% all videos.
        /// </summary>
        public List<string> MimeTypes { get; set; }

        /// <summary>
        /// Filter by file name, uses normal LIKE database syntax
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Filter by object name, uses normal LIKE database syntax
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Filter by deployment date
        /// </summary>
        public DateTimeRange DeploymentDateRange { get; set; }

        /// <summary>
        /// An array of SearchSort fields to order results by
        /// </summary>
        public List<SearchSort> SortFields { get; set; }

        /// <summary>
        /// Search only for duplicates
        /// </summary>
        public bool Duplicates { get; set; }
    }
}