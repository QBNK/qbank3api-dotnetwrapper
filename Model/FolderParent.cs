using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class FolderParent
    {
        /// <summary>
        /// The Folder identifier.
        /// </summary>
        public int Folderid { get; set; }

        /// <summary>
        /// The distance from the specified Folder identifer, ie. the reverse depth.
        /// </summary>
        public int Depth { get; set; }
    }
}