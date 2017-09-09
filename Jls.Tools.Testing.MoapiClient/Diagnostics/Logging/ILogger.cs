using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient.Diagnostics.Logging
{
    public interface ILogger
    {
        void Debug(string message, params object[] args);
        void Info(string message, params object[] args);
        void Warn(string message, params object[] args);
        void Warn(Exception ex);

        void Error(string message, params object[] args);
        void Error(Exception exception);
        void Error(string message, Exception exception);

        void Critical(string message, params object[] args);
        void Critical(Exception exception);
        void Critical(string message, Exception exception);
    }
}
