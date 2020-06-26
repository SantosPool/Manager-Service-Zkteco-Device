using ManagerService.Repositories;

namespace ManagerService.Services.Impl
{
    public class ListenerCustomerServiceImpl:IListenerCustomerService
    {
        private IListenerCustomerDAO listenerCustomerDAO;
        public ListenerCustomerServiceImpl(IListenerCustomerDAO _listenerCustomerDAO)
        {
            this.listenerCustomerDAO = _listenerCustomerDAO;
        }
        public void ListenCustomers()
        {
            this.listenerCustomerDAO.ListenCustomers();
        }
    }
}
