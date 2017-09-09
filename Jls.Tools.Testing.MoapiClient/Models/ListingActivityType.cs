using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{    
    [Flags]
    public enum ListingActivityType : int
    {
        New = 0,
        PriceChange,
        StatusChange,
        PriceAndStatusChange
    }
}
