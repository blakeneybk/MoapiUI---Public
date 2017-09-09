using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jls.Tools.Testing.MoapiClient.Configuration;
using Jls.Tools.Testing.MoapiClient.Geography;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    public class SearchRequestDefault:ISearchRequest
    {
        public SearchRequestDefault(IMoapiSettings settings = null)
        {
            
          
            Year = new CriterionRange<int>();
            Price = new CriterionRange<int>();
            Garages = new CriterionRange<int>();
            Beds = new CriterionRange<int>();
            Baths = new CriterionRange<decimal>();
            SqFt = new CriterionRange<int>();
            Acres = new CriterionRange<decimal>();
            
            // Pre-populate some statuses and property types
            StatusTypes = new List<int> {1, 2};
            PropertyTypes = new List<int> {1, 2, 3, 4, 5, 6, 8};

            Year.Min = 1800;

            // Preset the max results to 100
            MaxResults = 100;

            if (settings != null)
            {
                MaxResults = settings.MaxResults;
            }
        }

        public GeoRectangle Area { get; set; }

        public int TimeOnMarket { get; set; }
        public List<int> StatusTypes { get; set; }
        public List<int> PropertyTypes { get; set; }
        public List<int> SearchOptionTypes { get; set; }
        public int CDOM { get; set; }
        public CriterionRange<int> Year { get; set; }
        public CriterionRange<int> Price { get; set; }
        public CriterionRange<int> Garages { get; set; }
        public CriterionRange<decimal> Baths { get; set; }
        public CriterionRange<int> Beds { get; set; }
        public CriterionRange<int> SqFt { get; set; }
        public CriterionRange<decimal> Acres { get; set; }
        //public bool OpenHouse { get; set; }
        //public bool View { get; set; }
        //public bool Waterfront { get; set; }
        //public bool BankOwned { get; set; }
        //public bool ShowOffices { get; set; }
        //public bool ShortSales { get; set; }
        public string Options { get; set; }
        public int MaxResults { get; set; }
    }
}
