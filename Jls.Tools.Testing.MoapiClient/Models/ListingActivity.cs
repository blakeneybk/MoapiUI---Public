using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    
    public class ListingActivity
    {
        
        public DateTime Date { get; set; }

        
        public ListingActivityType Type { get; set; }

        
        public int Price { get; set; }

        
        public int StatusId { get; set; }

        
        public string StatusName { get; set; }
    }
}
