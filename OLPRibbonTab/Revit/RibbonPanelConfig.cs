using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OLPRibbonTab.Resources;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Media.Imaging;
using Autodesk.Windows;
using OLPRibbonTab.Customs;

using RibbonItem = Autodesk.Revit.UI.RibbonItem;
using RibbonPanel = Autodesk.Revit.UI.RibbonPanel;
using System.Xml.Linq;

namespace OLPRibbonTab.Revit
{
    internal class RibbonPanelConfig
    {
        private static readonly string _thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

        private static Dictionary<int, SplitButtonData> _splitButtonDatas;
        private static Dictionary<int, PulldownButtonData> _pulldownButtonDatas;
        private static Dictionary<int, PushButtonData> _pushButtonDatas;
        private static List<RibbonItem> _ribbonItems;

        public RibbonPanel RibbonPanel;
        public Dictionary<int, SplitButton> SplitButtons;
        public Dictionary<int, PulldownButton> PulldownButtons;
        public Dictionary<int, PushButton> PushButtons;

        internal RibbonPanelConfig(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel = app.CreateRibbonPanel(tabName, panelName);
            PushButtons = [];
            SplitButtons = [];
            PulldownButtons = [];
        }

        //BIM
        internal static RibbonPanelConfig Config0(UIControlledApplication app, string tabName)
        {

            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name0);


            _pulldownButtonDatas = new Dictionary<int, PulldownButtonData>
            {

                { 1, new PulldownButtonData("PullDownButton_1", PulldownButtonDatas.FamilyUtils_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "FamilyUtils_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "FamilyUtils_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
            };

            _pushButtonDatas = new Dictionary<int, PushButtonData>()
            {
                { 1, new PushButtonData("PushButton_1", PushButtonDatas.ParametersFamily_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersFamily_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersFamily_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 2, new PushButtonData("PushButton_2", PushButtonDatas.ParametersCopier_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersCopier_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersCopier_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
            };

            rpc.PulldownButtons[1] = rpc.RibbonPanel.AddItem(_pulldownButtonDatas[1]) as PulldownButton;
            rpc.PushButtons[1] = rpc.PulldownButtons[1].AddPushButton(_pushButtonDatas[1]);
            rpc.PushButtons[2] = rpc.PulldownButtons[1].AddPushButton(_pushButtonDatas[2]);

            return rpc;
        }

        //Параметры
        internal static RibbonPanelConfig Config1(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name1);

            _pulldownButtonDatas = new Dictionary<int, PulldownButtonData>
            {
                { 11, new PulldownButtonData("PullDownButton_11", PulldownButtonDatas.ParametersFill_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersFill_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersFill_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 12, new PulldownButtonData("PullDownButton_12", PulldownButtonDatas.ParametersAuto_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAuto_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAuto_32.ico", UriKind.RelativeOrAbsolute))
                    }
                }
            };

            _pushButtonDatas = new Dictionary<int, PushButtonData>()
            {
                { 11, new PushButtonData("PushButton_11", PushButtonDatas.ParametersAutoOLPAuto_Name, _thisAssemblyPath, typeof(TurnOnOff11).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPAutoOff_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPAutoOff_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 12, new PushButtonData("PushButton_12", PushButtonDatas.ParametersAutoOLPManual_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPManual_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPManual_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 13, new PushButtonData("PushButton_13", PushButtonDatas.ParametersCustomer_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersCustomer_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersCustomer_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },

                { 15, new PushButtonData("PushButton_15", PushButtonDatas.ParametersNSection_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersNSection_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersNSection_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 16, new PushButtonData("PushButton_16", PushButtonDatas.ParametersElevation_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersElevation_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersElevation_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },

            };

            _ribbonItems = [.. rpc.RibbonPanel.AddStackedItems(_pulldownButtonDatas[12], _pulldownButtonDatas[11])];

            rpc.PulldownButtons[12] = _ribbonItems[0] as PulldownButton;
            rpc.PushButtons[11] = rpc.PulldownButtons[12].AddPushButton(_pushButtonDatas[11]);
            rpc.PushButtons[12] = rpc.PulldownButtons[12].AddPushButton(_pushButtonDatas[12]);

            rpc.PulldownButtons[11] = _ribbonItems[1] as PulldownButton;
            rpc.PushButtons[13] = rpc.PulldownButtons[11].AddPushButton(_pushButtonDatas[13]);
            rpc.PushButtons[15] = rpc.PulldownButtons[11].AddPushButton(_pushButtonDatas[15]);
            rpc.PushButtons[16] = rpc.PulldownButtons[11].AddPushButton(_pushButtonDatas[16]);

            return rpc;
        }

        //Менеджеры
        internal static RibbonPanelConfig Config2(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name2);

            _splitButtonDatas = new Dictionary<int, SplitButtonData>()
            {
                { 21, new SplitButtonData("SplitButton_21", SplitButtonDatas.ManageTask_Name) },
            };
            _pushButtonDatas = new Dictionary<int, PushButtonData>()
            {
                { 21, new PushButtonData("PushButton_21", PushButtonDatas.ManageFamilies_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageFamilies_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageFamilies_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 22, new PushButtonData("PushButton_22", PushButtonDatas.ManageMaterials_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageMaterials_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageMaterials_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 23, new PushButtonData("PushButton_23", PushButtonDatas.ManageTask1_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageTask1_32.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageTask1_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 24, new PushButtonData("PushButton_24", PushButtonDatas.ManageTask2_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageTask2_32.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageTask2_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 25, new PushButtonData("PushButton_25", PushButtonDatas.ManageBrowseViews, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageBrowseViews_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageBrowseViews_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
            };
            
            rpc.PushButtons[21] = rpc.RibbonPanel.AddItem(_pushButtonDatas[21]) as PushButton;

            _ribbonItems = [.. rpc.RibbonPanel.AddStackedItems(_pushButtonDatas[22], _pushButtonDatas[25])];
            rpc.PushButtons[22] = _ribbonItems[0] as PushButton;
            rpc.PushButtons[25] = _ribbonItems[1] as PushButton;

            rpc.SplitButtons[21] = rpc.RibbonPanel.AddItem(_splitButtonDatas[21]) as SplitButton;
            rpc.PushButtons[23] = rpc.SplitButtons[21].AddPushButton(_pushButtonDatas[23]);
            rpc.PushButtons[24] = rpc.SplitButtons[21].AddPushButton(_pushButtonDatas[24]);
            rpc.SplitButtons[21].CurrentButton = rpc.PushButtons[24];

            return rpc;
        }

        //Виды/Листы
        internal static RibbonPanelConfig Config3(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name3);

            _splitButtonDatas = new Dictionary<int, SplitButtonData>()
            {
                { 31, new SplitButtonData("SplitButton_31", SplitButtonDatas.ViewsBuffer_Name) },
            };

            _pulldownButtonDatas = new Dictionary<int, PulldownButtonData>()
            {
                { 31, new PulldownButtonData("PulldownButton_31", PulldownButtonDatas.SchedulesUtils_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesUtils_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesUtils_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 32, new PulldownButtonData("PulldownButton_32", PulldownButtonDatas.SheetsUtils_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsUtils_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsUtils_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 33, new PulldownButtonData("PulldownButton_33", PulldownButtonDatas.ViewsUtils_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsUtils_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsUtils_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
            };

            _pushButtonDatas = new Dictionary<int, PushButtonData>()
            {
                { 31, new PushButtonData("PushButton_31", PushButtonDatas.ViewsInsertSectionViewport_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsInsertSectionViewport_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsInsertSectionViewport_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 32, new PushButtonData("PushButton_32", PushButtonDatas.ViewsCopy_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsCopy_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsCopy_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 33, new PushButtonData("PushButton_33", PushButtonDatas.ViewsPaste_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsPaste_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsPaste_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 34, new PushButtonData("PushButton_34", PushButtonDatas.ViewsMultiCopier_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsMultiCopier_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsMultiCopier_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 35, new PushButtonData("PushButton_35", PushButtonDatas.ViewsRenamer_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsRenamer_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsRenamer_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 36, new PushButtonData("PushButton_36", PushButtonDatas.ViewsCreator_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsCreator_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsCreator_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 37, new PushButtonData("PushButton_37", PushButtonDatas.SheetsCopier_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsCopier_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsCopier_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 38, new PushButtonData("PushButton_38", PushButtonDatas.SheetsEnumerator_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsEnumerator_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsEnumerator_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 39, new PushButtonData("PushButton_39", PushButtonDatas.SheetsAddRevision_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsAddRevision_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsAddRevision_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 310, new PushButtonData("PushButton_310", PushButtonDatas.SchedulesColumnWidth_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesColumnWidth_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesColumnWidth_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 311, new PushButtonData("PushButton_311", PushButtonDatas.SchedulesFilterReplacer_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesFilterReplacer_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesFilterReplacer_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
            };

            rpc.PulldownButtons[33] = rpc.RibbonPanel.AddItem(_pulldownButtonDatas[33]) as PulldownButton;
            rpc.PushButtons[36] = rpc.PulldownButtons[33].AddPushButton(_pushButtonDatas[36]);
            rpc.PushButtons[34] = rpc.PulldownButtons[33].AddPushButton(_pushButtonDatas[34]);
            rpc.PushButtons[35] = rpc.PulldownButtons[33].AddPushButton(_pushButtonDatas[35]);
            rpc.PulldownButtons[33].AddSeparator();
            rpc.PushButtons[32] = rpc.PulldownButtons[33].AddPushButton(_pushButtonDatas[32]);
            rpc.PushButtons[33] = rpc.PulldownButtons[33].AddPushButton(_pushButtonDatas[33]);

            rpc.PulldownButtons[31] = rpc.RibbonPanel.AddItem(_pulldownButtonDatas[31]) as PulldownButton;
            rpc.PushButtons[310] = rpc.PulldownButtons[31].AddPushButton(_pushButtonDatas[310]);
            rpc.PushButtons[311] = rpc.PulldownButtons[31].AddPushButton(_pushButtonDatas[311]);

            rpc.PulldownButtons[32] = rpc.RibbonPanel.AddItem(_pulldownButtonDatas[32]) as PulldownButton;
            rpc.PushButtons[31] = rpc.PulldownButtons[32].AddPushButton(_pushButtonDatas[31]);
            rpc.PushButtons[39] = rpc.PulldownButtons[32].AddPushButton(_pushButtonDatas[39]);
            rpc.PushButtons[37] = rpc.PulldownButtons[32].AddPushButton(_pushButtonDatas[37]);
            rpc.PulldownButtons[32].AddSeparator();
            rpc.PushButtons[38] = rpc.PulldownButtons[32].AddPushButton(_pushButtonDatas[38]);

            return rpc;
        }

        //Импорт/Экспорт
        internal static RibbonPanelConfig Config4(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name4);

            _pushButtonDatas = new Dictionary<int, PushButtonData>
            {
                { 41, new PushButtonData("PushButton_41", PushButtonDatas.ImportLinks_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ImportLinks_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ImportLinks_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 42, new PushButtonData("PushButton_42", PushButtonDatas.ImportDWG_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ImportDWG_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ImportDWG_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 43, new PushButtonData("PushButton_43", PushButtonDatas.ExportPrint_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ExportPrint_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ExportPrint_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 44, new PushButtonData("PushButton_44", PushButtonDatas.ExportXLS_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ExportXLS_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ExportXLS_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
            };

            rpc.PushButtons[41] = rpc.RibbonPanel.AddItem(_pushButtonDatas[41]) as PushButton;

            _ribbonItems = [.. rpc.RibbonPanel.AddStackedItems(_pushButtonDatas[42], _pushButtonDatas[44])];
            rpc.PushButtons[42] = _ribbonItems[0] as PushButton;
            rpc.PushButtons[44] = _ribbonItems[1] as PushButton;

            rpc.PushButtons[43] = rpc.RibbonPanel.AddItem(_pushButtonDatas[43]) as PushButton;

            return rpc;
        }

        //Моделирование
        internal static RibbonPanelConfig Config5(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name5);

            _pushButtonDatas = new Dictionary<int, PushButtonData>
            {
                { 51, new PushButtonData("PushButton_51", PushButtonDatas.ModellingAutoJoin_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingAutoJoin_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingAutoJoin_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 52, new PushButtonData("PushButton_52", PushButtonDatas.ModellingConnectWallBeam_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingConnectWallBeam_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingConnectWallBeam_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 53, new PushButtonData("PushButton_53", PushButtonDatas.ModellingCutByVoids_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingCutByVoids_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingCutByVoids_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
            };

            _ribbonItems = [.. rpc.RibbonPanel.AddStackedItems(_pushButtonDatas[51], _pushButtonDatas[52], _pushButtonDatas[53])];

            rpc.PushButtons[51] = _ribbonItems[0] as PushButton;
            rpc.PushButtons[52] = _ribbonItems[1] as PushButton;
            rpc.PushButtons[53] = _ribbonItems[2] as PushButton;
            foreach (RibbonItem ribbonItem in _ribbonItems) ribbonItem.SetStandardSize(false);

            return rpc;
        }

        //Анализ/Проверка
        internal static RibbonPanelConfig Config6(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name6);

            _pushButtonDatas = new Dictionary<int, PushButtonData>
            {
                { 61, new PushButtonData("PushButton_61", PushButtonDatas.CheckModel_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckModel_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckModel_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 62, new PushButtonData("PushButton_62", PushButtonDatas.CheckCollisions_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckCollisions_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckCollisions_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
                { 63, new PushButtonData("PushButton_63", PushButtonDatas.CheckParameters_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckParameters_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckParameters_32.ico", UriKind.RelativeOrAbsolute))
                    }
                },
            };

            rpc.PushButtons[61] = rpc.RibbonPanel.AddItem(_pushButtonDatas[61]) as PushButton;

            _ribbonItems = [.. rpc.RibbonPanel.AddStackedItems(_pushButtonDatas[62], _pushButtonDatas[63])];
            rpc.PushButtons[62] = _ribbonItems[0] as PushButton;
            rpc.PushButtons[63] = _ribbonItems[1] as PushButton;

            return rpc;
        }
    }
}
