using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]
    public class Address : IFormattable
    {
        #region Privates
        private string _street;
        private string _street2;
        private string _county;
        private string _city;
        private string _state;
        private string _zip;
        #endregion

        #region Constructors
        public Address() { }

        public Address(string street, string city, string state, string zip) : this(street, null, city, state, zip) { }        

        public Address(string street, string county, string city, string state, string zip)
        {
            _street = street;
            _county = county;
            _city = city;
            _state = state;
            _zip = zip;
        }

        #endregion
         
        #region Public Properties
        /// <summary>
        /// Gets or sets the house number and street
        /// </summary>        
        public string Street 
        {
            get { return _street; }
            set { _street = value; }
        }

        /// <summary>
        /// Gets or sets any second line of street data
        /// </summary>       
        public string Street2
        {
            get { return _street2; }
            set { _street2 = value; }
        }

        /// <summary>
        /// Gets or sets the long name of the county
        /// </summary>        
        public string County
        {
            get { return _county; }
            set { _county = value; }
        }

        /// <summary>
        /// Gets or sets the long name of the city
        /// </summary>        
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// Gets or sets the state abbreviation
        /// </summary>        
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// Gets or sets the zipcode\postalcode
        /// </summary>        
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        #endregion

        // http://msdn.microsoft.com/en-us/library/system.iformatprovider.aspx

        #region IFormattable Members

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return base.ToString();
        }

        #endregion
    }
}
