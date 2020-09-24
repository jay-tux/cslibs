using System;
using System.Diagnostics;

namespace Jay.IO.Logging
{
    public abstract class DiagnosticEventLogger : DefaultEventLogger
    {
        public override void Log(string message)
        {
            LogEventArgs args = new DiagnosticLogEventArgs(LogSeverity.Message, message);
            if(FirePre) Fire(args);
            CascadeLog(message);
            if(!FirePre) Fire(args);
        }

        public override void Log(string message, LogSeverity severity)
        {
            LogEventArgs args = new DiagnosticLogEventArgs(severity, message);
            if(FirePre) Fire(args);
            CascadeLog(message);
            if(!FirePre) Fire(args);
        }
    }

    public class SimpleDiagnosticEventLogger : DiagnosticEventLogger
    {
        public static SimpleDiagnosticEventLogger Instance = new SimpleDiagnosticEventLogger();
        private SimpleDiagnosticEventLogger() {}

        public override void CascadeLog(string message) => CascadeLog(message, LogSeverity.Message);
        public override void CascadeLog(object message) => CascadeLog(message.ToString());
        public override void CascadeLog(string message, LogSeverity severity) => Console.WriteLine($"{severity.ToString().ToUpper()}\t{message}");
        public override void CascadeLog(object message, LogSeverity severity) => CascadeLog(message.ToString(), severity);
    }

    public class DiagnosticLogEventArgs : LogEventArgs
    {
        public StackFrame Frame { get => Trace.GetFrame(1); }
        public StackTrace Trace;

        public DiagnosticLogEventArgs(LogSeverity severity, string message) : base(severity, message)
        {
            Trace = new StackTrace(true);
        }
    }
}
