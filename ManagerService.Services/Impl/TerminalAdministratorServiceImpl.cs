using ManagerService.Entities.Entities;
using ManagerService.Repositories;
using System.Net.Sockets;

namespace ManagerService.Services.Impl
{
    public class TerminalAdministratorServiceImpl: ITerminalAdministratorService
    {
        private ITerminalAdministratorDAO terminalAdministrator;
        public TerminalAdministratorServiceImpl(ITerminalAdministratorDAO _terminalAdministrator)
        {
            this.terminalAdministrator = _terminalAdministrator;
        }
        public DataTerminal GetDataTerminal(Socket socket, byte[] info)
        {
            return this.terminalAdministrator.GetDataTerminal(socket, info);
        }
    }
}
