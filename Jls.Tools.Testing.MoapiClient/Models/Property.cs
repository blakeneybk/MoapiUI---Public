using System;
using Jls.Tools.Testing.MoapiClient.Geography;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]
    
    public class Property
    {
        #region Privates
        private int _propertyId;
        private Address _address;
        private GeoPoint _location;
        private decimal _lotSize;
        private decimal _propertyTax;
        private Listing _activeListing;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the unique Property Identifier
        /// </summary>
        public int PropertyId
        {
            get { return _propertyId; }
            set { _propertyId = value; }
        }

        /// <summary>
        /// Gets or sets the property address
        /// </summary>
        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// Gets or sets the geographical location (lat/long)
        /// </summary>
        public GeoPoint Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Gets or sets the lot size in acres 
        /// </summary>
        public decimal LotSize
        {
            get { return _lotSize; }
            set { _lotSize = value; }
        }

        /// <summary>
        /// Gets or sets the active listing for this property.
        /// </summary>
        public Listing ActiveListing
        {
            get { return _activeListing; }
            set { _activeListing = value; }
        }

        /// <summary>
        /// Gets or sets the Property Tax amount
        /// </summary>
        public decimal PropertyTax
        {
            get { return _propertyTax; }
            set { _propertyTax = value; }
        }

        #endregion
    }
}
