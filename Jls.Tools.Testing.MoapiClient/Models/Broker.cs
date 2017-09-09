using System;
using System.Collections.Generic;
using System.Linq;
using Jls.Tools.Testing.MoapiClient.Geography;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]    
    public class Broker 
    {
        #region Consts 
        /* 
         *  be database driven.
         */
        private const string ORGANIZATION_NAME = "John L. Scott Real Estate";
        private const string TITLE_NAME = "Real Estate Specialist";
        #endregion

        #region Privates
        private int _brokerId;
        private string _mlsId;
        private string _alias;
        private int _officeId;
        private string _firstName;
        private char _middleInitial;
        private string _lastName;
        private Address _address;
        private string _webContent;
        private string _welcomeMessage;
        private MediaLink _photo;        
        private string _websiteUrl;
        private string _email;
        private string _marketArea;
        private GeoPoint _marketAreaLocation;
        private LanguageCollection _spokenLanguages = new LanguageCollection();
        private List<PhoneNumber> _phoneNumbers = new List<PhoneNumber>();
        private DesignationCollection _designations = new DesignationCollection();
        private List<MediaLink> _publicLinks  = new List<MediaLink>();
        private List<string> _specialties = new List<string>();
        private string _tagLine;
        private string _alternateTitle = ", Real Estate Specialist";
        private string _title;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the unique Broker Identifer
        /// </summary>        
        public int ID
        {
            get { return _brokerId; }
            set { _brokerId = value; }
        }

        /// <summary>
        /// Gets or sets the ID of the office associated with the broker
        /// </summary>
        public int OfficeID
        {
            get { return _officeId; }
            set { _officeId = value; }
        }

        /// <summary>
        /// Gets or sets the user alias (userid) of the broker.
        /// </summary>
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

        /// <summary>
        /// Gets or sets the broker's first name.
        /// </summary>
        
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Gets a broker's full name.  
        /// </summary>        
        public string FullName
        {
            get { return _firstName + ' ' + _lastName; }
        }

        /// <summary>
        /// Gets or sets the broker's middle initial
        /// </summary>
        
        public char MiddleInital
        {
            get { return _middleInitial; }
            set { _middleInitial = value; }
        }

        /// <summary>
        /// Gets or sets the last name or surname of the broker.
        /// </summary>
        
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Gets or sets the address of the broker.  In most cases this is the broker's primary 
        /// office address.
        /// </summary>
        
        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// Gets or sets the broker's custom web content and/or bio.
        /// </summary>
        
        public string WebContent
        {
            get { return _webContent; }
            set { _webContent = value; }
        }

        /// <summary>
        /// Gets or sets the custom welcome message that can be displayed on the client's notification screen.
        /// </summary>
        
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { _welcomeMessage = value; }
        }

        /// <summary>
        /// Gets or sets the broker tagline
        /// </summary>
        
        public string TagLine
        {
            get { return _tagLine; }
            set { _tagLine = value; }
        }

        
        public string DisplayTitle
        {
            get
            {
                if (!this.FullName.Contains(','))
                    return this.FullName + _alternateTitle;
                else
                    return this.FullName;
            }
            private set { /* NOOP - to make serialization happy */ }
        }

        /// <summary>
        /// Gets or sets the title 
        /// </summary>
        
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Getse or sets the broker's main photo location.
        /// </summary>
        
        public MediaLink Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        /// <summary>
        /// Gets or sets the collection of contact phone numbers.
        /// </summary>
        
        public List<PhoneNumber> PhoneNumbers
        {
            get { return _phoneNumbers; }
            set { _phoneNumbers = value; }
        }

        /// <summary>
        /// Gets or sets the broker's website url.
        /// </summary>
        
        public string WebSiteUrl
        {
            get { return _websiteUrl; }
            set { _websiteUrl = value; }
        }

        /// <summary>
        /// Gets or sets the unique MLS provided identifier for this broker.
        /// </summary>
        
        public string MLSIdentifier
        {
            get { return _mlsId; }
            set { _mlsId = value; }
        }

        /// <summary>
        /// Gets or sets the broker's email address.
        /// </summary>
        
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Gets or sets the name of the market area
        /// </summary>
        
        public string MarketArea
        {
            get { return _marketArea; }
            set { _marketArea = value; }
        }

        /// <summary>
        /// Gets or sets the geo spatial lat/long location object for the market area.
        /// </summary>
        
        public GeoPoint MarketAreaLocation
        {
            get { return _marketAreaLocation; }
            set { _marketAreaLocation = value; }
        }

        /// <summary>
        /// Gets or sets languages list spoken by the broker
        /// </summary>
        
        public LanguageCollection SpokenLanguages
        {
            get { return _spokenLanguages; }
            set { _spokenLanguages = value; }
        }

        /// <summary>
        /// Gets or sets the list of designations for this broker
        /// </summary>
        
        public DesignationCollection Designations
        {
            get { return _designations; }
            set { _designations = value; }
        }

        /// <summary>
        /// Gets or sets the broker's list of specialties
        /// </summary>
        
        public List<string> Specialties
        {
            get { return _specialties; }
            set { _specialties = value; }
        }

        /// <summary>
        /// Gets or sets the list of public favorite links for this broker
        /// </summary>
        
        public List<MediaLink> PublicLinks
        {
            get { return _publicLinks; }
            set { _publicLinks = value; }
        }

        #endregion

        public Broker ToListProjection()
        {
            return new Broker()
            {
                ID = this.ID,
                Address = this.Address,
                Alias = this.Alias,
                DisplayTitle = this.DisplayTitle,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                MarketArea = this.MarketArea,
                MiddleInital = this.MiddleInital,
                MLSIdentifier = this.MLSIdentifier,
                OfficeID = this.OfficeID,
                Title = this.Title,
                Photo = this.Photo,
                PhoneNumbers = this.PhoneNumbers,
                TagLine = this.TagLine                
            };

        }

        /*   VCardWriter need to be a singleton serializer class and not
         *        Implemented in this class        
        public string TovCard()
        {
            string vcardData = null;

            vCardWriter writer = new vCardWriter(this._firstName, this.LastName);

            writer.WriteOrginization(ORGANIZATION_NAME);
            writer.WriteJobTitle(TITLE_NAME);

            foreach (PhoneNumber ph in _phoneNumbers) {
                writer.WritePhoneNumber(ph);
            }

            writer.WriteAddress(this._address);
            writer.WriteWebSiteURL(this._websiteUrl);
            writer.WriteEmail(this._email);

            vcardData = writer.GetvCardData();

            return vcardData;
        }
       */
    }
}
