using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    public class SearchResponse
    {
        public int Count { get; set; }

        public List<Listing> Listings { get; set; }

        public int Mode { get; set; }

        public string Offices { get; set; }

        public int SearchId { get; set; }

        public int Status { get; set; }

        public string StatusDescription { get; set; }
    }
}
