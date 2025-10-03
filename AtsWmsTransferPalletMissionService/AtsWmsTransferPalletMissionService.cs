using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AtsWmsTransferPalletMissionService
{
    
    public partial class AtsWmsTransferPalletMissionService : ServiceBase
    {
        static string className = "AtsWmsTransferPalletMissionService";
        private static readonly ILog Log = LogManager.GetLogger(className);
        public AtsWmsTransferPalletMissionService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Log.Debug("OnStart :: AtsWmsTransferPalletMission in OnStart....");

                try
                {
                    XmlConfigurator.Configure();
                    try
                    {
                        AtsWmsTransferPalletMissionTaskThread();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("OnStart :: Exception occured while AtsWmsTransferPalletMissionTaskThread  threads task :: " + ex.Message);
                    }
                    Log.Debug("OnStart :: AtsWmsTransferPalletMissionTaskThread in OnStart ends..!!");
                }
                catch (Exception ex)
                {
                    Log.Error("OnStart :: Exception occured in OnStart :: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Log.Error("OnStart :: Exception occured in OnStart :: " + ex.Message);
            }
        }

        public async void AtsWmsTransferPalletMissionTaskThread()
        {
            await Task.Run(() =>
            {
                try
                {
                    AtsWmsTransferPalletMissionServiceDetails AtsWmsTransferPalletMissionServiceDetailsInstance = new AtsWmsTransferPalletMissionServiceDetails();
                    AtsWmsTransferPalletMissionServiceDetailsInstance.startOperation();
                }
                catch (Exception ex)
                {
                    Log.Error("TestService :: Exception in AtsWmsEquipmentAlarmTaskThread :: " + ex.Message);
                }

            });
        }
        protected override void OnStop()
        {
            try
            {
                Log.Debug("OnStop :: AtsWmsTransferPalletMission in OnStop ends..!!");
            }
            catch (Exception ex)
            {
                Log.Error("OnStop :: Exception occured in OnStop :: " + ex.Message);
            }
        }
    }
}
