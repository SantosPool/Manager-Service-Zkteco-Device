using ManagerService.Entities.Entities;
using System;
using System.IO;
using System.Reflection;

namespace ManagerService.Utilities
{
    public class General
    {
        public static void WriteInFile(string mensaje)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            StreamWriter ws = new StreamWriter(dir + "\\archivo.log", true);
            ws.WriteLine(DateTime.Now + " " + mensaje);
            ws.Close();
        }
    }
}
