namespace Jls.Tools.Testing.MoapiClient.Models
{    
    public enum ListingStatus : int 
    {
        Active = 1,
        Pending,
        Expired,
        Cancelled,
        OffMarket,
        Sold = 6
    }
}
