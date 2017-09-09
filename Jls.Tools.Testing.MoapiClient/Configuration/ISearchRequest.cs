using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jls.Tools.Testing.MoapiClient.Geography;
using Jls.Tools.Testing.MoapiClient.Models;

namespace Jls.Tools.Testing.MoapiClient.Configuration
{
    public interface ISearchRequest
    {
        int MaxResults { get; set; }
        List<int> StatusTypes { get; set; }
        List<int> PropertyTypes { get; set; }
        List<int> SearchOptionTypes { get; set; }
        CriterionRange<int> Year { get; set; }
        CriterionRange<int> Price { get; set; }
        CriterionRange<int> Garages { get; set; }
        CriterionRange<decimal> Baths { get; set; }
        CriterionRange<int> Beds { get; set; }
        CriterionRange<int> SqFt { get; set; }
        CriterionRange<decimal> Acres { get; set; }
        GeoRectangle Area { get; set; }
        int CDOM { get; set; }
        string Options { get; set; }
    }
}
