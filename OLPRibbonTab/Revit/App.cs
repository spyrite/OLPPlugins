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
    public class App : IExternalApplication
    {
        private const string _tabName = "OLPRibbonTab";
        private UIControlledApplication _app;
        
        
        internal static Dictionary<string, RibbonPanelConfig> RibbonPanelConfigs;
        internal static PushButton AutoparametersAutoButton;
        internal static bool AutoparametersAutoButtonStatus;

        public Result OnStartup(UIControlledApplication application)
        {
            _app = application;
            _app.CreateRibbonTab(_tabName);
            RibbonPanelConfigs = [];
            RibbonPanelConfigs[RibbonPanelNames.Name0] = RibbonPanelConfig.Config0(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name1] = RibbonPanelConfig.Config1(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name2] = RibbonPanelConfig.Config2(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name5] = RibbonPanelConfig.Config5(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name3] = RibbonPanelConfig.Config3(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name4] = RibbonPanelConfig.Config4(application, _tabName);
            RibbonPanelConfigs[RibbonPanelNames.Name6] = RibbonPanelConfig.Config6(application, _tabName);

            AutoparametersAutoButton = RibbonPanelConfigs[RibbonPanelNames.Name1].PushButtons[11];
            AutoparametersAutoButtonStatus = false;

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