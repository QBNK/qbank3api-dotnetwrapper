using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class VideoTemplate
    {
        /// <summary>
        /// The Video Template identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Video Template
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        public MimeType MimeType { get; set; }

        /// <summary>
        /// An array of commands for this template
        /// </summary>
        public List<Command> Commands { get; set; }
    }
}