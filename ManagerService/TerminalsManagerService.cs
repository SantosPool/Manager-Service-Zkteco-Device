using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ManagerService.Entities.Entities;
using ManagerService.Services;
using Ninject;
using ManagerService.Utilities;
using System.Net;
using System.Net.Sockets;

namespace ManagerService
{
    public partial class TerminalsManagerService : ServiceBase
    {
        private IProcessorService processor;
        public Thread listenThread;

        public TerminalsManagerService()
        {
            InitializeComponent();
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            this.processor = kernel.Get<IProcessorService>();
        }

        protected override void OnStart(string[] args)
        {
            InitializeServerForClients();

            General.WriteInFile("Terminals Administrator Service Running.");
            this.ScheduleService();
        }

        protected override void OnStop()
        {
            General.WriteInFile("Terminals Administrator Service Stoped.");
            this.Schedular.Dispose();
        }
        private Timer Schedular;
        //Custom method to Start the timer
        public void ScheduleService()
        {
            try
            {
                Schedular = new Timer(new TimerCallback(SchedularCallback));
                Schedular.Change(60000, Timeout.Infinite);
            }
            catch (GenericException ex)
            {
                General.WriteInFile("Terminals Administrator Service Error in: {0} " + ex.Message + ex.StackTrace);
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("TerminalsAdministratorService"))
                {
                    serviceController.Stop();
                }
            }
        }
        private void SchedularCallback(object e)
        {
            try
            {

                //lista.Clear();
                //lista = Procesos.ObtenerProyectos();
                //Procesos.EjecucionDLLProyecto(lista);
                this.ScheduleService();
            }
            catch (GenericException ex)
            {
                General.WriteInFile(string.Format("Terminals Administrator Service Error in: {0} ", ex.Message + ex.StackTrace));
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("TerminalsAdministratorService"))
                {
                    serviceController.Stop();
                }
            }
        }
        public void InitializeServerForClients()
        {
            //Create the Server Object ans Start it.
            listenThread = new Thread(this.processor.ListenCustomers);
            listenThread.Start();
        }
        public void SimulateRun()
        {
            var a = this.processor.DoSomething();
            var d = "";
        }
    }
}
