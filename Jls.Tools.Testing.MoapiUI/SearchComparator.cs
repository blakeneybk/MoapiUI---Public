using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Jls.Tools.Testing.MoapiClient.Diagnostics.Logging;
using Jls.Tools.Testing.MoapiClient.Models;
using Newtonsoft.Json.Linq;
using JsonDiffPatchDotNet;
using static Jls.Tools.Testing.MoapiUI.SimpleHelpers.ObjectDiffPatch;

namespace Jls.Tools.Testing.MoapiUI
{
    public class SearchComparator
    {
        private readonly ILogger _logger;

        public SearchComparator(ILogger logger)
        {
            _logger = logger;
        }

        public List<DisparityItem> Compare(IList<Listing> source, IList<Listing> target)
        {
            var diffs = new List<DisparityItem>();

            //source.Except()

            return diffs;
        }



    }

    public class DisparityItem
    {
        public string Message { get; set; }

        public DisparityType DisparityType { get; set; }

        public Direction Direction { get; set; }        

        public object Tag { get; set; }
    }

    public enum DisparityType
    {
        Missing,
        Conflict,
        Other
    }

    public enum Direction
    {
        SourceA,
        SourceB, 
        Both
    }

}
