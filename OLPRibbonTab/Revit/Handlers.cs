﻿using Autodesk.Revit.UI.Events;
using OLPRibbonTab.Resources;
using Autodesk.Revit.UI;
using OLPRibbonTab.Customs;
using System.Linq;

namespace OLPRibbonTab.Revit
{
    internal class Handlers
    {
        internal static void SwitchRibbonTabMode(object sender, ViewActivatedEventArgs e)
        {
            switch (e.Document.IsFamilyDocument)
            {
                //Семейство
                case true:
                    //BIM
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[1].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[2].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[3].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[4].Visible = false;

                    //Параметры
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name1].PushButtons.Values)
                        pb.Visible = false;
                    foreach (PulldownButton pdb in App.RibbonPanelConfigs[RibbonPanelNames.Name1].PulldownButtons.Values)
                        pdb.Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name1].RibbonPanel.Visible = false;

                    //Менеджеры
                    App.RibbonPanelConfigs[RibbonPanelNames.Name2].SplitButtons[21].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name2].PushButtons[23].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name2].PushButtons[24].Visible = false;

                    //Виды/Листы
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[31].Visible = false;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[31].GetItems())
                        pb.Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[32].Visible = false;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[32].GetItems())
                        pb.Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[33].Visible = false;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[33].GetItems())
                        pb.Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].RibbonPanel.Visible = false;

                    //Импорт/Экспорт
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[41].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[42].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[43].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[44].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].RibbonPanel.Visible = false;


                    //Моделирование
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name5].PushButtons.Values)
                        pb.Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name5].RibbonPanel.Visible = false;

                    //Анализ/Проверка
                    App.RibbonPanelConfigs[RibbonPanelNames.Name6].RibbonPanel.Visible = false;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name6].PushButtons.Values)
                        pb.Visible = false;
                    break;

                //Проект
                case false:
                    //BIM
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[1].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[2].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[3].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[4].Visible = true;

                    //Параметры
                    App.RibbonPanelConfigs[RibbonPanelNames.Name1].RibbonPanel.Visible = true;
                    foreach (PulldownButton pdb in App.RibbonPanelConfigs[RibbonPanelNames.Name1].PulldownButtons.Values)
                        pdb.Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name1].PushButtons.Values)
                        pb.Visible = true;

                    //Менеджеры
                    App.RibbonPanelConfigs[RibbonPanelNames.Name2].SplitButtons[21].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name2].PushButtons[23].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name2].PushButtons[24].Visible = true;

                    //Виды/Листы
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].RibbonPanel.Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[31].Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[31].GetItems())
                        pb.Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[32].Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[32].GetItems())
                        pb.Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[33].Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[33].GetItems())
                        pb.Visible = true;

                    //Импорт/Экспорт
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].RibbonPanel.Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[41].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[42].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[43].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[44].Visible = true;


                    //Моделирование
                    App.RibbonPanelConfigs[RibbonPanelNames.Name5].RibbonPanel.Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name5].PushButtons.Values)
                        pb.Visible = true;
                    

                    //Анализ/Проверка
                    App.RibbonPanelConfigs[RibbonPanelNames.Name6].RibbonPanel.Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name6].PushButtons.Values)
                        pb.Visible = true;
                    break;
            }
        }

        internal static void SetRibbonTabDisciplineConfiguration(WorkMode workMode)
        {
            switch (workMode)
            {
                case WorkMode.OIS:
                    App.RibbonPanelConfigs[RibbonPanelNames.Name5].RibbonPanel.Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[4].Visible = false;
                    break;
                default:
                    App.RibbonPanelConfigs[RibbonPanelNames.Name5].RibbonPanel.Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons[4].Visible = true;
                    break;
            }
        }
    }
}
