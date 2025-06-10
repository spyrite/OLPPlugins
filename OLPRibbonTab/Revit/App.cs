using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using OLPRibbonTab.Resources;

namespace OLPRibbonTab.Revit
{
    public enum WorkMode
    {
        All,
        OAP,
        OSK,
        OIS
    }

    public class App : IExternalApplication
    {
        private const string _tabName = "OLPRibbonTab";
        private UIControlledApplication _app;
        
        
        internal static Dictionary<string, RibbonPanelConfig> RibbonPanelConfigs;
        internal static PushButton AutoparametersAutoButton;
        internal static bool AutoparametersAutoButtonStatus;
        internal static WorkMode WorkMode;

        public Result OnStartup(UIControlledApplication application)
        {
            _app = application;
            _app.CreateRibbonTab(_tabName);
            RibbonPanelConfigs = [];
            RibbonPanelConfigs[RibbonPanelNames.Name0] = RibbonPanelConfig.InitPanel0(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name1] = RibbonPanelConfig.InitPanel1(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name2] = RibbonPanelConfig.InitPanel2(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name5] = RibbonPanelConfig.InitPanel5(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name3] = RibbonPanelConfig.InitPanel3(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name4] = RibbonPanelConfig.InitPanel4(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name6] = RibbonPanelConfig.InitPanel6(application, _tabName);

            AutoparametersAutoButton = RibbonPanelConfigs[RibbonPanelNames.Name1].PushButtons[11];
            AutoparametersAutoButtonStatus = false;

            WorkMode = (WorkMode)Properties.App.Default.WorkMode;
            Handlers.SetRibbonTabDisciplineConfiguration(WorkMode);

            SubscribingToEvents();

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            _app = application;
            UnsubscribingToEvents();

            return Result.Succeeded;
        }

        private void SubscribingToEvents()
        {
            _app.ViewActivated += new EventHandler<ViewActivatedEventArgs>(Handlers.SwitchRibbonTabMode);
        }

        private void UnsubscribingToEvents()
        {
            _app.ViewActivated -= new EventHandler<ViewActivatedEventArgs>(Handlers.SwitchRibbonTabMode);
        }
    }
}