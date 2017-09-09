using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    public class SessionContext
    {
        public string ApplicationUrl { get; set; }

        public string Message { get; set; }

        public Guid SessionKey { get; set; }

        public int Status { get; set; }

        public string User { get; set; }
    }
}
