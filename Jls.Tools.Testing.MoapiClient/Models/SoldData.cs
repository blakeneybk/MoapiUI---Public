using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]
    
    public class SoldData
    {
        private int _soldPrice;
        private DateTime? _soldDate = null;

        /// <summary>
        /// Gets or sets the closing price
        /// </summary>
        
        public int SoldPrice
        {
            get { return _soldPrice; }
            set { _soldPrice = value; }
        }

        /// <summary>
        /// Gets or sets the date the listing closed
        /// </summary>
        
        public DateTime? SoldDate
        {
            get { return _soldDate; }
            set { _soldDate = value; }
        }
    }
}
