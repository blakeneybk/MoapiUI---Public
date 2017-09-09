using System;
using System.Collections.Generic;
using Jls.Tools.Testing.MoapiClient.Geography;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]    
    public class Listing : IListing
    {
        /* 
         * Timespan used to determin if a listing is new on market. 
             eq; ((DateTime - ListDate) <= NEW_ON_MARKET_DAYS) = {New On Market};
        */
        private readonly TimeSpan NEW_ON_MARKET_DAYS = new TimeSpan(14, 0, 0, 0);

        #region Privates
        private int _id;
        private string _mlsListingId;
        private decimal _bathrooms;
        private int _bedrooms;
        private int _listPrice;
        private DateTime? _listDate;
        private int _sqft;
        private string _style;
        private int _yearBuilt;
        private int _scottLine;
        private string _courtesyOf;
        private string _remark;
        private decimal _garageSpaces;
        private int _fireplaces;
        private SchoolDistrict _schools;
        private MediaLink _mainPhoto;
        private List<MediaLink> _photos;
        private string _statusName;
        private Address _address;
        private GeoPoint _location;
        private long _lotSize;
        private ListingStatus _status;
        private PropertyType _propType;
        private FeatureCollection _features;
        private MultipleListingService _mls;
        private SoldData _soldData;
        private PresentationOptions _uiMask;
        private List<Broker> _listingBroker;
        private int _listingBrokerId;
        private DateTime? _openHouseDate;
        private int _openHouseDuration;
        private List<Tax> _taxes;
        private int _cdom;
        private List<ListingActivity> _history;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the unique JLS listing identifier
        /// </summary>
        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the MLS specific listing identifier
        /// </summary>
        
        public string MlsListingId
        {
            get { return _mlsListingId; }
            set { _mlsListingId = value; }
        }
        
        /// <summary>
        /// Gets or sets the number of bathrooms
        /// </summary>
        
        public decimal Bathrooms
        {
            get { return _bathrooms; }
            set { _bathrooms = value; }
        }

        /// <summary>
        /// Gets or sets the number of bedrooms
        /// </summary>
        
        public int Bedrooms
        {
            get { return _bedrooms; }
            set { _bedrooms = value; }
        }

        /// <summary>
        /// Gets or sets the current list price 
        /// </summary>
        
        public int ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// <summary>
        /// Gets or sets the date and time this listing was listed
        /// </summary>
        
        public DateTime? ListDate
        {
            get { return _listDate; }
            set {                 
                _listDate = value;

                // Calculate the new on market flag and set the option
                if (_listDate != null && _listDate.HasValue) {
                    if (DateTime.Now - _listDate.Value <= NEW_ON_MARKET_DAYS)
                        _uiMask |= PresentationOptions.NewOnMarket;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Cumulative days on market field
        /// </summary>
        
        public int CumulativeDaysOnMarket
        {
            get { return _cdom; }
            set { _cdom = value; }
        }

        /// <summary>
        /// Gets or sets the status name of this listing.
        /// </summary>
        
        public string StatusName
        {
            get { return _statusName; }
            set { _statusName = value; }
        }

        /// <summary>
        /// Gets or set the status of this listing.
        /// </summary>
        
        public ListingStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Gets or sets the living space in square feet
        /// </summary>
        
        public int Sqft
        {
            get { return _sqft; }
            set { _sqft = value; }
        }

        /// <summary>
        /// Gets or sets the architectural style (e.g. 1 story,...)
        /// </summary>
        
        public string Style
        {
            get { return _style; }
            set { _style = value; }
        }

        
        public PropertyType PropertyType
        {
            get { return _propType; }
            set { _propType = value; }
        }

        /// <summary>
        /// Gets or sets the year the structure was built
        /// </summary>
        
        public int YearBuilt
        {
            get { return _yearBuilt; }
            set { _yearBuilt = value; }
        }

        /// <summary>
        /// Gets the Multiple Listing Service data class
        /// </summary>
        
        public MultipleListingService Mls
        {
            get { return _mls; }
            set { _mls = value; }
        }

        /// <summary>
        /// Gets or sets the sold data for this listing
        /// </summary>
        
        public SoldData SoldData
        {
            get { return _soldData; }
            set { _soldData = value; }
        }

        /// <summary>
        /// Gets or sets the user interface/presentation options bitmask.
        /// </summary>
        
        public PresentationOptions UIMask
        {
            get { return _uiMask; }
            set { _uiMask = value; }
        }

        /// <summary>
        /// Gets or sets the John L. Scott Line number
        /// </summary>
        
        public int ScottLine
        {
            get { return _scottLine; }
            set { _scottLine = value; }
        }

        /// <summary>
        /// Gets or sets the name of the listing office
        /// </summary>
        
        public string CourtesyOf
        {
            get { return _courtesyOf; }
            set { _courtesyOf = value; }
        }

        /// <summary>
        /// Gets or sets the agent remarks for this listing
        /// </summary>
        
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        /// <summary>
        /// Gets or sets the main photo for the listing
        /// </summary>
        
        public MediaLink MainPhoto
        {
            get { return _mainPhoto; }
            set { _mainPhoto = value; }
        }

        /// <summary>
        /// Gets or sets a collection of listing photos
        /// </summary>
        
        public List<MediaLink> Photos
        {
            get { return _photos; }
            set { _photos = value; }
        }

        /// <summary>
        /// Gets or sets the number of garage spaces
        /// </summary>
        
        public decimal GarageSpaces
        {
            get { return _garageSpaces; }
            set { _garageSpaces = value; }
        }

        /// <summary>
        /// Gets or sets the total number of fireplaces
        /// </summary>
        
        public int Fireplaces
        {
            get { return _fireplaces; }
            set { _fireplaces = value; }
        }

        /// <summary>
        /// Gets or sets the school district information including; district,elem,jr,high.
        /// </summary>
        
        public SchoolDistrict Schools
        {
            get { return _schools; }
            set { _schools = value; }
        }

        /// <summary>
        /// Gets or sets the Features for this listing.  
        /// </summary>

        //public FeatureCollection Features  // DISABLING FOR NOW
        //{
        //    get { return _features; }
        //    set { _features = value; }
        //}

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
        /// Gets or sets the lot size in sqft
        /// </summary>
        
        public long LotSize
        {
            get { return _lotSize; }
            set { _lotSize = value; }
        }

        /// <summary>
        /// Gets or sets the taxes for this listing
        /// </summary>
        
        public List<Tax> Taxes
        {
            get { return _taxes; }
            set { _taxes = value; }
        }

        /// <summary>
        /// Gets or sets the listing agent/broker representing this listing.
        /// </summary>
        
        public List<Broker> ListingBrokers
        {
            get { return _listingBroker; }
            set { _listingBroker = value; }
        }
        
        public int ListingBrokerId
        {
            get { return _listingBrokerId; }
            set { _listingBrokerId = value; }
        }

        /// <summary>
        /// Gets or sets the listing open house start date and time
        /// </summary>
        
        public DateTime? OpenHouseDate
        {
            get {
                //if (_openHouseDate.HasValue) {
                //    return _openHouseDate.Value.ToUniversalTime();
                //}
                //else
                    return _openHouseDate;
            }
            set { _openHouseDate = value; }
        }

        /// <summary>
        /// Gets or sets the open house duration in minutes
        /// </summary>
        
        public int OpenHouseDuration
        {
            get { return _openHouseDuration; }
            set { _openHouseDuration = value; }
        }


        /// <summary>
        /// Gets or sets the historical activity for this listing
        /// </summary>
        
        public List<ListingActivity> Activity
        {
            get { return _history; }
            set { _history = value; }
        }

        
        public bool Favorite { get; set; }

        #endregion

        public Listing ToListProjection()
        {
            return new Listing()
            {
                ID = this.ID,
                Address = this.Address,
                ListPrice = this.ListPrice,
                MlsListingId = this.MlsListingId,
                Bedrooms = this.Bedrooms,
                Bathrooms = this.Bathrooms,
                Sqft = this.Sqft,
                PropertyType = this.PropertyType,
                Status = this.Status,
                StatusName = this.StatusName,
                UIMask = this.UIMask,
                SoldData = this.SoldData,
                MainPhoto = this.GetPrimaryPhoto(),
                LotSize = this.LotSize,
                Mls = this.Mls,
                ScottLine = this.ScottLine,
                Location = this.Location
            };
        }

        public MediaLink GetPrimaryPhoto()
        {
            MediaLink photo = null;

            if (MainPhoto == null) {
                if ((Photos != null) && Photos.Count > 0) {
                    photo = Photos[0];
                }
            }
            else
                photo = MainPhoto;

            return photo;
        }
    }
}
