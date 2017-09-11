using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class MoodboardTemplateResponse
    {
        /// <summary>
        /// The template identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The template name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Dynamic object detailing the templates options.
        /// </summary>
        public object Options { get; set; }
    }
}