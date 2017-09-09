using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]
    
    public class MultipleListingService 
    {
        private int _id;
        private string _key;
        private string _shortName;
        private string _longName;
        private MediaLink _icon;

        public MultipleListingService() { }

        #region IMultipleListingService Members

        /// <summary>
        /// Gets the unique JLS MLS Identifier
        /// </summary>
        
        //public int ID
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}
        
        //public string Key
        //{
        //    get { return _key; }
        //    set { _key = value; }
        //}

        /// <summary>
        /// Gets the MLS short name
        /// </summary>
        
        public string ShortName
        {
            get { return (_shortName != null ? _shortName.ToUpper() : _shortName); }
            set { _shortName = value; }
        }

        /// <summary>
        /// Gets the MLS long name
        /// </summary>
        
        public string LongName
        {
            get { return _longName;  }
            set { _longName = value; }
        }

        /// <summary>
        /// Gets or sets the MLS Icon image
        /// </summary>
        
        public MediaLink Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        #endregion
    }
}
