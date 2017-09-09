using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    public interface IListing 
    {
        string MlsListingId { get; }
        int ListPrice { get; }
        int Bedrooms { get; }
        decimal Bathrooms { get; }
        DateTime? ListDate { get; }
        int Sqft { get; }
        string Style { get; }
        MediaLink MainPhoto { get; }        
    }
}
