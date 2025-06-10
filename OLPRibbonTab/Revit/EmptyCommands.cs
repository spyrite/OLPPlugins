using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using OLPRibbonTab.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OLPRibbonTab.Revit
{
    [Transaction(TransactionMode.Manual)]
    internal class EmptyCommands : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    internal class TurnOnOff11 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (App.AutoparametersAutoButton != null)
            {
                switch (App.AutoparametersAutoButtonStatus)
                {
                    case false:
                        App.AutoparametersAutoButton.ItemText = PushButtonDatas.ParametersAutoOLPAuto_Name_On;
                        App.AutoparametersAutoButton.Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPAutoOn_16.ico", UriKind.RelativeOrAbsolute));
                        App.AutoparametersAutoButton.LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPAutoOn_32.ico", UriKind.RelativeOrAbsolute));
                        App.AutoparametersAutoButtonStatus = true;
                        break;
                    case true:
                        App.AutoparametersAutoButton.ItemText = PushButtonDatas.ParametersAutoOLPAuto_Name_Off;
                        App.AutoparametersAutoButton.Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPAutoOff_16.ico", UriKind.RelativeOrAbsolute));
                        App.AutoparametersAutoButton.LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPAutoOff_32.ico", UriKind.RelativeOrAbsolute));
                        App.AutoparametersAutoButtonStatus = false;
                        break;
                }
            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    internal class WorkModeSwitch : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            RadioButtonGroup rbg = App.RibbonPanelConfigs[RibbonPanelNames.Name0].RadioButtonGroups[1];
            Properties.App.Default.WorkMode = rbg.GetItems().IndexOf(rbg.Current);
            Properties.App.Default.Save();

            App.WorkMode = (WorkMode)Properties.App.Default.WorkMode;
            Handlers.SetRibbonTabDisciplineConfiguration(App.WorkMode);

            return Result.Succeeded;

        }
    }

}
