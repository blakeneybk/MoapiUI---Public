using Jls.Tools.Testing.MoapiClient.Configuration;
using Jls.Tools.Testing.MoapiClient.Models;

namespace Jls.Tools.Testing.MoapiUI
{
    public interface IMapSource
    {
        void Initialize();
        SearchResponse Search(ISearchRequest searchRequest);
    }
}