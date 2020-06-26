using ManagerService.Entities.Entities;
using System.Net.Sockets;

namespace ManagerService.Repositories
{
    public interface ITerminalAdministratorDAO 
    {
        DataTerminal GetDataTerminal(Socket socket, byte[] info);
    }
}
