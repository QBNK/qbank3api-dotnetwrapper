using RestSharp;
using System.Collections.Generic;
using System;


namespace QBankApi.Model
{
    public class PropertyType : RestResponse
    {
        /// <summary>
        /// When the Property was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The identifier of the User who created the Property.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// When the Property was updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Which user who updated the Property.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Whether the Property is deleted.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// The Property name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Property system name, this is used for programmatic access.
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// A description of the PropertyType.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data type for the Property (1: Boolean, 2: DateTime, 3: Decimal, 4: Float, 5: Integer, 6: String) In addition, definition can alter the way a Property should be displayed.
        /// </summary>
        public int DataTypeId { get; set; }

        /// <summary>
        /// A Key/Value Object containing extra information about how this Property should be used.
        /// </summary>
        public object Definition { get; set; }
    }
}