using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class CommentResponse
    {
        /// <summary>
        /// Id of the comment
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The QBank user that wrote this comment
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Time this comment was made
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// A array of eventual replies to this comment
        /// </summary>
        public List<CommentResponse> Replies { get; set; }
    }
}