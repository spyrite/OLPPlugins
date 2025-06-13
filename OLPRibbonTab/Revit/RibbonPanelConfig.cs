﻿using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Imaging;
using OLPRibbonTab.Resources;
using OLPRibbonTab.Customs;

using RibbonItem = Autodesk.Revit.UI.RibbonItem;
using RibbonPanel = Autodesk.Revit.UI.RibbonPanel;
using System.Linq;

namespace OLPRibbonTab.Revit
{
    internal class RibbonPanelConfig
    {
        private static readonly string _thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

        private static Dictionary<int, SplitButtonData> _splitButtonDatas;
        private static Dictionary<int, PulldownButtonData> _pulldownButtonDatas;
        private static Dictionary<int, PushButtonData> _pushButtonDatas;
        private static Dictionary<int, RadioButtonGroupData> _radioButtonGroupDatas;
        private static Dictionary<int, ToggleButtonData> _toggleButtonDatas;
        private static List<RibbonItem> _ribbonItems;

        public RibbonPanel RibbonPanel;
        public Dictionary<int, SplitButton> SplitButtons;
        public Dictionary<int, PulldownButton> PulldownButtons;
        public Dictionary<int, PushButton> PushButtons;
        public Dictionary<int, RadioButtonGroup> RadioButtonGroups;
        public Dictionary<int, ToggleButton> ToggleButtons;

        internal RibbonPanelConfig(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel = app.CreateRibbonPanel(tabName, panelName);
            PushButtons = [];
            SplitButtons = [];
            PulldownButtons = [];
            RadioButtonGroups = [];
            ToggleButtons = [];
        }

        //BIM
        internal static RibbonPanelConfig InitPanel0(UIControlledApplication app, string tabName)
        {

            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name0);

            _radioButtonGroupDatas = new Dictionary<int, RadioButtonGroupData>
            {
                { 1, new RadioButtonGroupData("RadioButtonGroup_1")
                    {
                        ToolTip = "Переключатель конфигурации вкладки по отделам"
                    }
                }
            };

            _toggleButtonDatas = new Dictionary<int, ToggleButtonData>
            {
                { 0, new ToggleButtonData("ToggleButton_0", ToggleButtonDatas.WorkMode_All_Name, _thisAssemblyPath, typeof(WorkModeSwitch).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "WorkMode_All_32.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "WorkMode_All_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = ToggleButtonDatas.WorkMode_All_DescriptionShort,
                        LongDescription = ToggleButtonDatas.WorkMode_All_DescriptionLong,
                    }
                },
                { 1, new ToggleButtonData("ToggleButton_1", ToggleButtonDatas.WorkMode_OAP_Name, _thisAssemblyPath, typeof(WorkModeSwitch).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "WorkMode_OAP_32.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "WorkMode_OAP_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = ToggleButtonDatas.WorkMode_OAP_DescriptionShort,
                        LongDescription = ToggleButtonDatas.WorkMode_OAP_DescriptionLong,
                    }
                },
                { 2, new ToggleButtonData("ToggleButton_2", ToggleButtonDatas.WorkMode_OSK_Name, _thisAssemblyPath, typeof(WorkModeSwitch).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "WorkMode_OSK_32.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "WorkMode_OSK_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = ToggleButtonDatas.WorkMode_OSK_DescriptionShort,
                        LongDescription = ToggleButtonDatas.WorkMode_OSK_DescriptionLong,
                    }
                },
                { 3, new ToggleButtonData("ToggleButton_3", ToggleButtonDatas.WorkMode_OIS_Name, _thisAssemblyPath, typeof(WorkModeSwitch).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "WorkMode_OIS_32.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "WorkMode_OIS_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = ToggleButtonDatas.WorkMode_OIS_DescriptionShort,
                        LongDescription = ToggleButtonDatas.WorkMode_OIS_DescriptionLong,
                    }
                },
            };

            _pulldownButtonDatas = new Dictionary<int, PulldownButtonData>
            {

                { 1, new PulldownButtonData("PullDownButton_1", PulldownButtonDatas.FamilyUtils_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "FamilyUtils_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "FamilyUtils_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PulldownButtonDatas.FamilyUtils_DescriptionShort,
                        LongDescription = PulldownButtonDatas.FamilyUtils_DescriptionShort,
                    }
                },
            };

            _pushButtonDatas = new Dictionary<int, PushButtonData>()
            {
                { 1, new PushButtonData("PushButton_1", PushButtonDatas.ParametersFamily_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersFamily_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersFamily_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ParametersFamily_DescriptionShort,
                        LongDescription = PushButtonDatas.ParametersFamily_DescriptionLong,
                    }
                },
                { 2, new PushButtonData("PushButton_2", PushButtonDatas.ParametersCopier_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersCopier_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersCopier_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ParametersCopier_DescriptionShort,
                        LongDescription = PushButtonDatas.ParametersCopier_DescriptionLong,
                    }
                },
                { 3, new PushButtonData("PushButton_3", PushButtonDatas.LevelRenamer_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "LevelRenamer_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "LevelRenamer_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.LevelRenamer_DescriptionShort,
                        LongDescription = PushButtonDatas.LevelRenamer_DescriptionLong,
                    }
                },
                { 4, new PushButtonData("PushButton_4", PushButtonDatas.ModellingMasonaryOpenings_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingMasonaryOpenings_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingMasonaryOpenings_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ModellingMasonaryOpenings_DescriptionShort,
                        LongDescription = PushButtonDatas.ModellingMasonaryOpenings_DescriptionLong,
                    }
                },
                { 5, new PushButtonData("PushButton_5", PushButtonDatas.UserCallback_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "UserCallback_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "UserCallback_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.UserCallback_DescriptionShort,
                        LongDescription = PushButtonDatas.UserCallback_DescriptionLong,
                    }
                },
            };

            rpc.PushButtons[1] = rpc.RibbonPanel.AddItem(_pushButtonDatas[1]) as PushButton;
            rpc.PushButtons[2] = rpc.RibbonPanel.AddItem(_pushButtonDatas[2]) as PushButton;
            rpc.PushButtons[3] = rpc.RibbonPanel.AddItem(_pushButtonDatas[3]) as PushButton;
            rpc.PushButtons[4] = rpc.RibbonPanel.AddItem(_pushButtonDatas[4]) as PushButton;

            rpc.RibbonPanel.AddSlideOut();

            rpc.RadioButtonGroups[1] = rpc.RibbonPanel.AddItem(_radioButtonGroupDatas[1]) as RadioButtonGroup;
            rpc.RadioButtonGroups[1].AddItems([.. _toggleButtonDatas.Values]);
            int i = 0;
            foreach (ToggleButton toggleButton in rpc.RadioButtonGroups[1].GetItems())
            {
                //toggleButton.SetListSize();
                rpc.ToggleButtons[i] = toggleButton;
                i++;
            }
            rpc.RadioButtonGroups[1].Current = rpc.ToggleButtons[(int)App.WorkMode];

            return rpc;
        }

        //Параметры
        internal static RibbonPanelConfig InitPanel1(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name1);

            _pulldownButtonDatas = new Dictionary<int, PulldownButtonData>
            {
                { 11, new PulldownButtonData("PullDownButton_11", PulldownButtonDatas.ParametersFill_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersFill_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersFill_32.ico", UriKind.RelativeOrAbsolute)),
                        
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
                { 11, new PushButtonData("PushButton_11", PushButtonDatas.ParametersAutoOLPAuto_Name_On, _thisAssemblyPath, typeof(TurnOnOff11).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPAutoOff_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPAutoOff_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ParametersAutoOLPAuto_DescriptionShort, 
                        LongDescription = PushButtonDatas.ParametersAutoOLPAuto_DescriptionLong,
                    }
                },
                { 12, new PushButtonData("PushButton_12", PushButtonDatas.ParametersAutoOLPManual_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPManual_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersAutoOLPManual_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ParametersAutoOLPManual_DescriptionShort,
                        LongDescription = PushButtonDatas.ParametersAutoOLPManual_DescriptionLong,
                    }
                },
                { 13, new PushButtonData("PushButton_13", PushButtonDatas.ParametersCustomer_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersCustomer_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersCustomer_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ParametersCustomer_DescriptionShort,
                        LongDescription = PushButtonDatas.ParametersCustomer_DescriptionLong,
                    }
                },

                { 15, new PushButtonData("PushButton_15", PushButtonDatas.ParametersNSection_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersNSection_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersNSection_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ParametersNSection_DescriptionShort,
                        LongDescription = PushButtonDatas.ParametersNSection_DescriptionLong,
                    }
                },
                { 16, new PushButtonData("PushButton_16", PushButtonDatas.ParametersElevation_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersElevation_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ParametersElevation_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ParametersElevation_DescriptionShort,
                        LongDescription = PushButtonDatas.ParametersElevation_DescriptionLong,
                    }
                },

            };



            rpc.PushButtons[11] = rpc.RibbonPanel.AddItem(_pushButtonDatas[11]) as PushButton;

            _ribbonItems = [.. rpc.RibbonPanel.AddStackedItems(_pushButtonDatas[12], _pulldownButtonDatas[11])];

            //rpc.PulldownButtons[12] = _ribbonItems[0] as PulldownButton;
            //rpc.PushButtons[11] = rpc.PulldownButtons[12].AddPushButton(_pushButtonDatas[11]);
            //rpc.PushButtons[12] = rpc.PulldownButtons[12].AddPushButton(_pushButtonDatas[12]);
            rpc.PushButtons[12] = _ribbonItems[0] as PushButton;
            rpc.PulldownButtons[11] = _ribbonItems[1] as PulldownButton;

            rpc.PushButtons[13] = rpc.PulldownButtons[11].AddPushButton(_pushButtonDatas[13]);
            rpc.PushButtons[15] = rpc.PulldownButtons[11].AddPushButton(_pushButtonDatas[15]);
            rpc.PushButtons[16] = rpc.PulldownButtons[11].AddPushButton(_pushButtonDatas[16]);

            return rpc;
        }

        //Менеджеры
        internal static RibbonPanelConfig InitPanel2(UIControlledApplication app, string tabName)
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
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageFamilies_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ManageFamilies_DescriptionShort,
                        LongDescription = PushButtonDatas.ManageFamilies_DescriptionLong,
                    }
                },
                { 22, new PushButtonData("PushButton_22", PushButtonDatas.ManageMaterials_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageMaterials_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageMaterials_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ManageMaterials_DescriptionShort,
                        LongDescription = PushButtonDatas.ManageMaterials_DescriptionLong,
                    }
                },
                { 23, new PushButtonData("PushButton_23", PushButtonDatas.ManageTask1_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageTask1_32.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageTask1_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ManageTask1_DescriptionShort,
                        LongDescription = PushButtonDatas.ManageTask1_DescriptionLong,
                    }
                },
                { 24, new PushButtonData("PushButton_24", PushButtonDatas.ManageTask2_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageTask2_32.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageTask2_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ManageTask2_DescriptionShort,
                        LongDescription = PushButtonDatas.ManageTask2_DescriptionLong,
                    }
                },
                { 25, new PushButtonData("PushButton_25", PushButtonDatas.ManageBrowseViews_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageBrowseViews_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ManageBrowseViews_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ManageBrowseViews_DescriptionShort,
                        LongDescription = PushButtonDatas.ManageBrowseViews_DescriptionLong,
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

        //Оформление
        internal static RibbonPanelConfig InitPanel3(UIControlledApplication app, string tabName)
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
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesUtils_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PulldownButtonDatas.SchedulesUtils_DescriptionShort,
                        LongDescription = PulldownButtonDatas.SchedulesUtils_DescriptionLong,
                    }
                },
                { 32, new PulldownButtonData("PulldownButton_32", PulldownButtonDatas.SheetsUtils_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsUtils_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsUtils_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PulldownButtonDatas.SheetsUtils_DescriptionShort,
                        LongDescription = PulldownButtonDatas.SheetsUtils_DescriptionLong,
                    }
                },
                { 33, new PulldownButtonData("PulldownButton_33", PulldownButtonDatas.ViewsUtils_Name)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsUtils_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsUtils_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PulldownButtonDatas.ViewsUtils_DescriptionShort,
                        LongDescription = PulldownButtonDatas.ViewsUtils_DescriptionLong,
                    }
                },
            };

            _pushButtonDatas = new Dictionary<int, PushButtonData>()
            {
                { 31, new PushButtonData("PushButton_31", PushButtonDatas.ViewsInsertSectionViewport_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsInsertSectionViewport_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsInsertSectionViewport_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ViewsInsertSectionViewport_DescriptionShort,
                        LongDescription = PushButtonDatas.ViewsInsertSectionViewport_DescriptionLong,
                    }
                },
                { 32, new PushButtonData("PushButton_32", PushButtonDatas.ViewsCopy_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsCopy_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsCopy_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ViewsCopy_DescriptionShort,
                        LongDescription = PushButtonDatas.ViewsCopy_DescriptionLong,
                    }
                },
                { 33, new PushButtonData("PushButton_33", PushButtonDatas.ViewsPaste_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsPaste_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsPaste_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ViewsPaste_DescriptionShort,
                        LongDescription = PushButtonDatas.ViewsPaste_DescriptionLong,
                    }
                },
                { 34, new PushButtonData("PushButton_34", PushButtonDatas.ViewsMultiCopier_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsMultiCopier_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsMultiCopier_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ViewsMultiCopier_DescriptionShort,
                        LongDescription = PushButtonDatas.ViewsMultiCopier_DescriptionLong,
                    }
                },
                { 35, new PushButtonData("PushButton_35", PushButtonDatas.ViewsRenamer_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsRenamer_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewsRenamer_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ViewsRenamer_DescriptionShort,
                        LongDescription = PushButtonDatas.ViewsRenamer_DescriptionLong,
                    }
                },
                { 36, new PushButtonData("PushButton_36", PushButtonDatas.ViewSetCreator_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewSetCreator_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ViewSetCreator_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ViewSetCreator_DescriptionShort,
                        LongDescription = PushButtonDatas.ViewSetCreator_DescriptionLong,
                    }
                },
                { 37, new PushButtonData("PushButton_37", PushButtonDatas.SheetsCopier_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsCopier_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsCopier_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.SheetsCopier_DescriptionShort,
                        LongDescription = PushButtonDatas.SheetsCopier_DescriptionLong,
                    }
                },
                { 38, new PushButtonData("PushButton_38", PushButtonDatas.SheetsEnumerator_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsEnumerator_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsEnumerator_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.SheetsEnumerator_DescriptionShort,
                        LongDescription = PushButtonDatas.SheetsEnumerator_DescriptionLong,
                    }
                },
                { 39, new PushButtonData("PushButton_39", PushButtonDatas.SheetsAddRevision_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsAddRevision_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SheetsAddRevision_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.SheetsAddRevision_DescriptionShort,
                        LongDescription = PushButtonDatas.SheetsAddRevision_DescriptionLong,
                    }
                },
                { 310, new PushButtonData("PushButton_310", PushButtonDatas.SchedulesColumnWidth_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesColumnWidth_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesColumnWidth_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.SchedulesColumnWidth_DescriptionShort,
                        LongDescription = PushButtonDatas.SchedulesColumnWidth_DescriptionLong,
                    }
                },
                { 311, new PushButtonData("PushButton_311", PushButtonDatas.SchedulesFilterReplacer_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesFilterReplacer_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "SchedulesFilterReplacer_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.SchedulesFilterReplacer_DescriptionShort,
                        LongDescription = PushButtonDatas.SchedulesFilterReplacer_DescriptionLong,
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
        internal static RibbonPanelConfig InitPanel4(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name4);

            _pushButtonDatas = new Dictionary<int, PushButtonData>
            {
                { 41, new PushButtonData("PushButton_41", PushButtonDatas.ImportLinks_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ImportLinks_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ImportLinks_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ImportLinks_DescriptionShort,
                        LongDescription = PushButtonDatas.ImportLinks_DescriptionLong,
                    }
                },
                { 42, new PushButtonData("PushButton_42", PushButtonDatas.ImportDWG_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ImportDWG_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ImportDWG_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ImportDWG_DescriptionShort,
                        LongDescription = PushButtonDatas.ImportDWG_DescriptionLong,
                    }
                },
                { 43, new PushButtonData("PushButton_43", PushButtonDatas.ExportPrint_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ExportPrint_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ExportPrint_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ExportPrint_DescriptionShort,
                        LongDescription = PushButtonDatas.ExportPrint_DescriptionLong,
                    }
                },
                { 44, new PushButtonData("PushButton_44", PushButtonDatas.ExportXLS_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ExportXLS_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ExportXLS_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ExportXLS_DescriptionShort,
                        LongDescription = PushButtonDatas.ExportXLS_DescriptionLong,
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
        internal static RibbonPanelConfig InitPanel5(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name5);

            _pushButtonDatas = new Dictionary<int, PushButtonData>
            {
                { 51, new PushButtonData("PushButton_51", PushButtonDatas.ModellingAutoJoin_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingAutoJoin_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingAutoJoin_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ModellingAutoJoin_DescriptionShort,
                        LongDescription = PushButtonDatas.ModellingAutoJoin_DescriptionLong,
                    }
                },
                { 52, new PushButtonData("PushButton_52", PushButtonDatas.ModellingConnectWallBeam_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingConnectWallBeam_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingConnectWallBeam_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ModellingConnectWallBeam_DescriptionShort,
                        LongDescription = PushButtonDatas.ModellingConnectWallBeam_DescriptionLong,
                    }
                },
                { 53, new PushButtonData("PushButton_53", PushButtonDatas.ModellingCutByVoids_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingCutByVoids_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "ModellingCutByVoids_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.ModellingCutByVoids_DescriptionShort,
                        LongDescription = PushButtonDatas.ModellingCutByVoids_DescriptionLong,
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
        internal static RibbonPanelConfig InitPanel6(UIControlledApplication app, string tabName)
        {
            RibbonPanelConfig rpc = new(app, tabName, RibbonPanelNames.Name6);

            _pushButtonDatas = new Dictionary<int, PushButtonData>
            {
                { 61, new PushButtonData("PushButton_61", PushButtonDatas.CheckModel_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckModel_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckModel_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.CheckModel_DescriptionShort,
                        LongDescription = PushButtonDatas.CheckModel_DescriptionLong,
                    }
                },
                { 62, new PushButtonData("PushButton_62", PushButtonDatas.CheckCollisions_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckCollisions_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckCollisions_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.CheckCollisions_DescriptionShort,
                        LongDescription = PushButtonDatas.CheckCollisions_DescriptionLong,
                    }
                },
                { 63, new PushButtonData("PushButton_63", PushButtonDatas.CheckParameters_Name, _thisAssemblyPath, typeof(EmptyCommands).FullName)
                    {
                        Image = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckParameters_16.ico", UriKind.RelativeOrAbsolute)),
                        LargeImage = new BitmapImage(new Uri("/OLPRibbonTab;component/Resources/Images/" + "CheckParameters_32.ico", UriKind.RelativeOrAbsolute)),
                        ToolTip = PushButtonDatas.CheckParameters_DescriptionShort,
                        LongDescription = PushButtonDatas.CheckParameters_DescriptionLong,
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
