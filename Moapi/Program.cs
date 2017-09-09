using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jls.Tools.Testing.MoapiClient.Geography;
using Jls.Tools.Testing.MoapiClient.Models;
using Jls.Tools.Testing.MoapiUI;

namespace Moapi
{
    class Program
    {
        static void Main(string[] args)
        {
            var ds = new ApiMapSource(new Uri("http://api.johnlscott.com/v3.5"));
            ds.Initialize();

            var request = new SearchRequest();
            request.Area = new GeoRectangle(-121.90113F, 48.0627F, -121.9834F, 48.07083F);

            var results = ds.Search(request);
            Console.WriteLine(results.Count);
        }
    }
}
