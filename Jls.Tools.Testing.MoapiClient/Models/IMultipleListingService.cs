namespace Jls.Tools.Testing.MoapiClient.Models
{
    public interface IMultipleListingService
    {
        int ID { get; }
        string Key { get; }
        string ShortName { get; }
        string LongName { get; }
        MediaLink Icon { get; }        
    }
}
