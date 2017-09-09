using System;
using System.Collections.Generic;
using Jls.Tools.Testing.MoapiClient.Geography;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]    
    public class Office
    {
        private int _id;
        private string _name;
        private Address _address;
        private string _email;
        //private string _contactName;
        //private string _contactPhone;
        //private string _contactEmail;
        private MediaLink _photo;
        private GeoPoint _location;
        private string _webContent;
        private IList<PhoneNumber> _phoneNumbers = new List<PhoneNumber>();
        private IList<MediaLink> _publicLinks = new List<MediaLink>();
        private IList<Broker> _brokers = new List<Broker>();

        
        public int ID 
        {
            get { return _id; }
            set { _id = value; }
        }

        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        
        public MediaLink Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        
        public GeoPoint Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Gets or sets the office's custom web content and/or bio.
        /// </summary>
        
        public string WebContent
        {
            get { return _webContent; }
            set { _webContent = value; }
        }

        
        public IList<PhoneNumber> PhoneNumbers
        {
            get { return _phoneNumbers; }
            set { _phoneNumbers = value; }
        }

        /// <summary>
        /// Gets or sets the list of public favorite links for this office
        /// </summary>
        
        public IList<MediaLink> PublicLinks
        {
            get { return _publicLinks; }
            set { _publicLinks = value; }
        }

        /// <summary>
        /// Gets or sets the list of brokers associated with the office
        /// </summary>
        
        public IList<Broker> Brokers
        {
            get { return _brokers; }
            set { _brokers = value; }
        }
        
        public string TovCard()
        {
            throw new NotImplementedException();            
        }
    }
}
