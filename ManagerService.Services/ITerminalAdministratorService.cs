using ManagerService.Entities.Entities;
using System.Net.Sockets;

namespace ManagerService.Services
{
    public interface ITerminalAdministratorService
    {
        DataTerminal GetDataTerminal(Socket socket, byte[] info);
    }
}
