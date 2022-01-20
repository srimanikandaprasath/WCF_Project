using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using System.ServiceModel;

namespace ServerLib
{
    public partial class ServerControl : UserControl
    {
        ServiceHost _host;

        bool _serviceRunning = false;

        public ServerControl()
        {
            InitializeComponent();
        }
        public void LogMessage(string msg)
        {
            logger.Text += System.Environment.NewLine +
                DateTime.Now.ToLocalTime().ToString() + ":" +
                msg;
        }
        void ClearMessage()
        {
            logger.Text = string.Empty;
        }

       

        private void bStartStopServer_Click(object sender, EventArgs e)
        {
            try
            {
                _serviceRunning = !_serviceRunning;
                if (_serviceRunning)
                {
                    ServerSvc svc = new ServerSvc(this);
                    _host = new ServiceHost(
                        svc,
                        new Uri[] { new Uri("net.pipe://localhost") });
                    _host.AddServiceEndpoint(
                        typeof(IexcService),
                        new NetNamedPipeBinding(),
                        "DataExchangeSrv");

                    _host.Open();

                    ClearMessage();
                    LogMessage("Server started ...");
                }
                else
                {
                    _host.Close();
                    _host = null;

                    LogMessage("Server stopped ...");
                }
            }

            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }
    }
}
