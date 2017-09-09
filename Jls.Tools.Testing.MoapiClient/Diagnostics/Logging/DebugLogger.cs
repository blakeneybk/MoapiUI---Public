using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Jls.Tools.Testing.MoapiClient.Diagnostics.Logging
{
    public class DebugLogger : ILogger
    {
        public void Debug(string message, params object[] args)
        {
            WriteLine("[DEBUG] " + message, args);
        }

        public void Info(string message, params object[] args)
        {
            WriteLine("[INFO] " + message, args);
        }

        public void Warn(string message, params object[] args)
        {
            WriteLine("[WARN] " + message, args);
        }

        public void Warn(Exception ex)
        {
            WriteLine("[WARN] " + ex.Message);
        }

        public void Error(string message, params object[] args)
        {
            WriteLine("[ERROR] " + message, args);
        }

        public void Error(Exception exception)
        {
            WriteLine("[ERROR] " + BuildExceptionMessage(exception));
        }

        public void Error(string message, Exception exception)
        {
            WriteLine("[ERROR] {0}, {1} ", message, BuildExceptionMessage(exception));
        }

        public void Critical(string message, params object[] args)
        {
            WriteLine("[FATAL] " + message, args);
        }

        public void Critical(Exception exception)
        {
            WriteLine("[FATAL] " + BuildExceptionMessage(exception));
        }

        public void Critical(string message, Exception exception)
        {
            WriteLine("[FATAL] {0}, {1} ", message, BuildExceptionMessage(exception));
        }

        private void WriteLine(string message, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(!args.Any() ? message : string.Format(message, args));
        }


        /// <summary>
        ///     This method formats an error message so that it is in a
        ///     nice readable format for the event log or other targets.
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <returns>A formatted error message</returns>
        private string BuildExceptionMessage(Exception exception)
        {
            var errorMsg = new StringBuilder();

            // Construct our exception message.
            errorMsg
                .AppendFormat("\nException:   {0}", exception.GetType())
                .AppendFormat("\nMessage:     {0}", exception.Message)
                .AppendFormat("\nSource:      {0}", exception.Source)
                .AppendFormat("\nStack Trace: {0}", exception.StackTrace)
                .AppendFormat("\nTargetSite:  {0}", exception.TargetSite);



            foreach (var key in exception.Data.Keys)
            {
                var data = exception.Data[key];
                if (data == null) continue;
                errorMsg.AppendFormat("\nData {0}:  {1}", key, data);
            }


            var sqlException = exception as SqlException;
            if (sqlException != null)
            {
                for (var j = 0; j < sqlException.Errors.Count; j++)
                {
                    var se = sqlException.Errors[j];
                    errorMsg.AppendFormat("\nSQL Class:      {0}", se.Class)
                            .AppendFormat("\nSQL LineNumber: {0}", se.LineNumber)
                            .AppendFormat("\nSQL Message:    {0}", se.Message)
                            .AppendFormat("\nSQL Number:     {0}", se.Number)
                            .AppendFormat("\nSQL Procedure:  {0}", se.Procedure)
                            .AppendFormat("\nSQL Server:     {0}", se.Server)
                            .AppendFormat("\nSQL Source:     {0}", se.Source)
                            .AppendFormat("\nSQL State:      {0}", se.State);
                }
            }

            var ex = exception.InnerException;
            int i = 0;
            while (ex != null)
            {
                i++;
                errorMsg.AppendLine();
                errorMsg.AppendFormat("=== InnerException [{0}] ===", i).AppendLine();
                errorMsg
                    .AppendFormat("\nException:   {0}", exception.GetType())
                    .AppendFormat("\nMessage:     {0}", ex.Message)
                    .AppendFormat("\nSource:      {0}", ex.Source)
                    .AppendFormat("\nStack Trace: {0}", ex.StackTrace)
                    .AppendFormat("\nTargetSite:  {0}", ex.TargetSite);
                ex = ex.InnerException;
            }

            return errorMsg.ToString();
        }
    }
}
