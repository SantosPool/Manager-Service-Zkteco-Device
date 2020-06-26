using ManagerService.Entities.Entities;
using System.Collections.Generic;

namespace ManagerService.Services
{
    public class IProcessorService
    {
        private IUserService userService;
        private ITerminalAdministratorService terminalAdministrator;
        private IListenerCustomerService listenerCustomerService;

        public IProcessorService(IListenerCustomerService _listenerCustomerService,IUserService _userService, ITerminalAdministratorService _terminalAdministrator)
        {
            this.listenerCustomerService = _listenerCustomerService;
            this.userService = _userService;
            this.terminalAdministrator = _terminalAdministrator;            
        }

        public void ListenCustomers()
        {
            this.listenerCustomerService.ListenCustomers();
        }
        public IList<object> DoSomething()
        {
            var widget = this.userService.GetUsers();
            return widget;
        }

        //public DataTerminal GetDataTerminal()
        //{
        //    return this.terminalAdministrator.GetDataTerminal();
        //}
    }
}
