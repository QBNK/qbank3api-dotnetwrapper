using RestSharp;
using System.Collections.Generic;


namespace QBankApi.Model
{
    public class SlideTransition
    {
        /// <summary>
        /// The transition to use
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// Speed of the transition, in milliseconds
        /// </summary>
        public int? Speed { get; set; }

        /// <summary>
        /// Advance to the next slide after X milliseconds
        /// </summary>
        public int? AdvanceAfterTime { get; set; }

        /// <summary>
        /// Indicates if we should move to the next slide on mouse click
        /// </summary>
        public bool? AdvanceOnClick { get; set; }

        /// <summary>
        /// Orientation of transition, if applicable
        /// </summary>
        public int? Orientation { get; set; }

        /// <summary>
        /// Direction of transition, if applicable
        /// </summary>
        public int? Direction { get; set; }

        /// <summary>
        /// Pattern of transition, if applicable
        /// </summary>
        public int? Pattern { get; set; }

        /// <summary>
        /// Indicates if transition should bounce, if applicable
        /// </summary>
        public bool? Bounce { get; set; }

        /// <summary>
        /// Indicates if transition should bounce, if applicable
        /// </summary>
        public bool? FromBlack { get; set; }
    }
}