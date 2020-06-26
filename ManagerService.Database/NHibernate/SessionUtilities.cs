using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerService.Database.NHibernate
{
    public class SessionUtilities
    {
        private static ISessionFactory _sessionFactoryHost = null;

        public static ISessionFactory SessionFactoryHost
        {
            get { return _sessionFactoryHost; }
            set { _sessionFactoryHost = value; }
        }

        public static ISession Open()
        {
            return SessionFactoryHost.OpenSession();
        }
    }
}
