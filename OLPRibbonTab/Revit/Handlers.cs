using Autodesk.Revit.UI.Events;
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
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].RibbonPanel.Visible = true;
                    foreach (PulldownButton pdb in App.RibbonPanelConfigs[RibbonPanelNames.Name0].PulldownButtons.Values)
                        pdb.Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons.Values)
                        pb.Visible = true;

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
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PushButtons[36].Enabled = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PushButtons[34].Enabled = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PushButtons[35].Enabled = false;

                    //Импорт/Экспорт
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[41].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[43].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[44].Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[42].SetLargeSize(false);

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
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name0].PushButtons.Values)
                        pb.Visible = false;
                    foreach (PulldownButton pdb in App.RibbonPanelConfigs[RibbonPanelNames.Name0].PulldownButtons.Values)
                        pdb.Visible = false;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name0].RibbonPanel.Visible = false;

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
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[31].Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[31].GetItems())
                        pb.Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[32].Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name3].PulldownButtons[32].GetItems())
                        pb.Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PushButtons[36].Enabled = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PushButtons[34].Enabled = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name3].PushButtons[35].Enabled = true;

                    //Импорт/Экспорт
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[41].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[43].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[44].Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name4].PushButtons[42].SetStandardSize(false);

                    //Моделирование
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name5].PushButtons.Values)
                        pb.Visible = true;
                    App.RibbonPanelConfigs[RibbonPanelNames.Name5].RibbonPanel.Visible = true;

                    //Анализ/Проверка
                    App.RibbonPanelConfigs[RibbonPanelNames.Name6].RibbonPanel.Visible = true;
                    foreach (PushButton pb in App.RibbonPanelConfigs[RibbonPanelNames.Name6].PushButtons.Values)
                        pb.Visible = true;
                    break;
            }
        }
    }
}
