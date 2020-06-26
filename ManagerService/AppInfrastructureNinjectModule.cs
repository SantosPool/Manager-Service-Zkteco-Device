using ManagerService.Repositories;
using ManagerService.Repositories.Impl;
using ManagerService.Services;
using ManagerService.Services.Impl;
using Ninject.Modules;

namespace ManagerService
{
    public class AppInfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IUserService>().To<UserServiceImpl>();
            Bind<IUserDAO>().To<UserDAOImpl>();

            Bind<ITerminalAdministratorService>().To<TerminalAdministratorServiceImpl>();
            Bind<ITerminalAdministratorDAO>().To<TerminalAdministratorDAOImpl>();

            Bind<IListenerCustomerService>().To<ListenerCustomerServiceImpl>();
            Bind<IListenerCustomerDAO>().To<ListenerCustomerDAOImpl>();

        }
    }
}
