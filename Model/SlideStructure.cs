using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class SlideStructure
    {
        /// <summary>
        /// Media that contains the slide
        /// </summary>
        public int? MediaId { get; set; }

        /// <summary>
        /// Slide number, first slide is slide 0.
        /// </summary>
        public int? Slide { get; set; }

        /// <summary>
        /// The transition to use when showing this slide
        /// </summary>
        public SlideTransition Transition { get; set; }
    }
}