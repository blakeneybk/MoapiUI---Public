using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jls.Tools.Testing.MoapiClient.Configuration;
using Jls.Tools.Testing.MoapiClient.Geography;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    public class SearchRequest : ISearchRequest
    {
        public SearchRequest(IMoapiSettings settings = null)
        {
            Price = new CriterionRange<int>(){Min = 0,Max = Int32.MaxValue};
            Beds = new CriterionRange<int>(){Min = 0,Max = Int32.MaxValue};
            Baths = new CriterionRange<decimal>(){Min = 0,Max = Int32.MaxValue};
            SqFt = new CriterionRange<int>(){Min = 0,Max = Int32.MaxValue};
            Acres = new CriterionRange<decimal>(){Min = 0,Max = Int32.MaxValue};
            Year = new CriterionRange<int>(){Min = 1800,Max = DateTime.Now.Year};
            Garages = new CriterionRange<int>(){Min = 0,Max = Int32.MaxValue};
            CDOM = Int32.MaxValue;
            StatusTypes = new List<int>(){ 1, 2 };
            PropertyTypes = new List<int>(){ 1, 2, 3, 4, 5, 6, 8 };
            SearchOptionTypes = new List<int>();

            // Preset the max results to 100
            MaxResults = 100;

            if (settings != null)
            {
                MaxResults = settings.MaxResults;
            }
        }
        
        public int MaxResults { get; set; }
        public List<int> StatusTypes { get; set; }
        public List<int> PropertyTypes { get; set; }
        public List<int> SearchOptionTypes { get; set; }
        public CriterionRange<int> Year { get; set; }
        public CriterionRange<int> Price { get; set; }
        public CriterionRange<int> Garages { get; set; }
        public CriterionRange<decimal> Baths { get; set; }
        public CriterionRange<int> Beds { get; set; }
        public CriterionRange<int> SqFt { get; set; }
        public CriterionRange<decimal> Acres { get; set; }
        public GeoRectangle Area { get; set; }
        public int CDOM { get; set; }
        public string Options { get; set; }

    }
}
