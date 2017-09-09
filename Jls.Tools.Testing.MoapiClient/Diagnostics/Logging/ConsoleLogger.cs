using System;
using System.Globalization;
using System.Linq;

namespace Jls.Tools.Testing.MoapiClient.Diagnostics.Logging
{
    /// <summary>
    ///     Provides basic logging features to the console window.  Use for developement
    ///     command line applications.  Note: Consider using the NLog configured implementation.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private readonly Func<string, object[], string> _formatter = (s, objects) =>
            $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} - {(!objects.Any() ? s : string.Format(s, objects))}";

        public void Debug(string message, params object[] args)
        {
            ColorWriteLine(ConsoleColor.Magenta, message, args);
        }

        public void Info(string message, params object[] args)
        {
            Console.WriteLine(_formatter(message, args));
        }

        public void Warn(string message, params object[] args)
        {
            ColorWriteLine(ConsoleColor.Yellow, message, args);
        }

        public void Warn(Exception ex)
        {
            ColorWriteLine(ConsoleColor.Yellow, ex.Message);
        }

        public void Error(string message, params object[] args)
        {
            ColorWriteLine(ConsoleColor.Red, message, args);
        }

        public void Error(Exception exception)
        {
            ColorWriteLine(ConsoleColor.Red, "[{0}] {1}", exception.GetType(), exception.Message);
            ColorWriteLine(ConsoleColor.Red, "\n--- INNER ---");
            var inner = exception.InnerException;
            while (inner != null)
            {
                ColorWriteLine(ConsoleColor.Red, "  [{0}] {1}", exception.GetType(), exception.Message);
                inner = inner.InnerException;
            }
            ColorWriteLine(ConsoleColor.Red, "\n--- STACK TRACE ---");
            ColorWriteLine(ConsoleColor.Red, exception.StackTrace);
        }

        public void Error(string message, Exception exception)
        {
            ColorWriteLine(ConsoleColor.Red, message);
            Error(exception);
        }

        public void Critical(string message, params object[] args)
        {
            ColorWriteLine(ConsoleColor.Red, message, args);
        }

        public void Critical(Exception exception)
        {
            ColorWriteLine(ConsoleColor.Red, "[{0}] {1}", exception.GetType(), exception.Message);
            ColorWriteLine(ConsoleColor.Red, "\n--- INNER ---");
            var inner = exception.InnerException;
            while (inner != null)
            {
                ColorWriteLine(ConsoleColor.Red, "  [{0}] {1}", exception.GetType(), exception.Message);
                inner = inner.InnerException;
            }
            ColorWriteLine(ConsoleColor.Red, "\n--- STACK TRACE ---");
            ColorWriteLine(ConsoleColor.Red, exception.StackTrace);
        }

        public void Critical(string message, Exception exception)
        {
            ColorWriteLine(ConsoleColor.Red, message);
            Error(exception);
        }

        private void ColorWriteLine(ConsoleColor color, string message, params object[] args)
        {
            var ccolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(_formatter( message, args));
            Console.ForegroundColor = ccolor;
        }
    }
}