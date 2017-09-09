using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient
{
    public class MoapiClientException : Exception
    {
        public MoapiClientException(string message, params object[] args) : base(string.Format(message, args))
        {
        }        

    }
}
