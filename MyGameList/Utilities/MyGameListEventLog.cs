using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.Threading.Tasks;

namespace MyGameList.Utilities
{
    public class MyGameListEventLog
    {
        private TraceSwitch traceSwitch;
        private EventLog eventLog;
        public MyGameListEventLog()
        {
            traceSwitch = new TraceSwitch("LevelOfInformation", "Switch used to specify how much information should be saved in MyGameListJournal.");
            string eventLogName = ConfigurationManager.AppSettings.Get("MyGameListJournal");
            string eventLogSource = ConfigurationManager.AppSettings.Get("MyGameListSource");
            if (!EventLog.SourceExists(eventLogSource, "."))
            {
                EventLog.CreateEventSource(eventLogSource, eventLogName);
            }
            eventLog = new EventLog(eventLogName, ".", eventLogSource);
        }
        public void WriteEntry(string message, string type)
        {
            if (traceSwitch.TraceVerbose)
            {
                if (type == "Info")
                {
                    eventLog.WriteEntry(message, EventLogEntryType.Information);
                }
                else if (type == "Warning")
                {
                    eventLog.WriteEntry(message, EventLogEntryType.Warning);
                }
                else if (type == "Error")
                {
                    eventLog.WriteEntry(message, EventLogEntryType.Error);
                }
            }
            else
            {
                if (traceSwitch.TraceInfo && type == "Info")
                {
                    eventLog.WriteEntry(message, EventLogEntryType.Information);
                }
                else if (traceSwitch.TraceWarning && type == "Warning")
                {
                    eventLog.WriteEntry(message, EventLogEntryType.Warning);
                }
                else if (traceSwitch.TraceError && type == "Error")
                {
                    eventLog.WriteEntry(message, EventLogEntryType.Error);
                }
            }
        }
    }
}
