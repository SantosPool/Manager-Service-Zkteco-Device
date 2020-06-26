using System.Collections.Generic;

namespace ManagerService.Entities.Entities
{
    public class DataTerminalHeader
    {
        public string TypeRequest { get; set; }
        public string VersionHTTP { get; set; }
        public string Command { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
