using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ManagerService.Database.NHibernate;
using ManagerService.Entities.Entities;
using NHibernate;
using System;
using System.ServiceProcess;

namespace ManagerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                SessionUtilities.SessionFactoryHost = CreateSessionFactory();
                var myService = new TerminalsManagerService();
                if (Environment.UserInteractive)
                {
                    myService.InitializeServerForClients();
                    myService.SimulateRun();
                }
                else
                {
                    ServiceBase.Run(myService);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        private static ISessionFactory CreateSessionFactory()
        {            
            return Fluently.Configure()
                    .Database(
                      MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=localhost; Initial Catalog=test; User ID=test; Password=test")
                      .ShowSql()
                      .FormatSql()
                    ).Mappings(m =>
                    {
                        m.FluentMappings.AddFromAssemblyOf<User>();
                    }
                    )
                    .BuildSessionFactory();
        }
    }
}
