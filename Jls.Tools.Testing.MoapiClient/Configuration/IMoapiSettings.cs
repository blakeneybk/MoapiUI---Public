using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient.Configuration
{
    public interface IMoapiSettings
    {
        string MapSourceA { get; }

        string MapSourceB { get; }

        string ApiKey { get; }
        string AppKey { get; }

        int MaxResults { get; }

        string DefaultCriteria { get; }

    }
}
