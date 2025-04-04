using Autodesk.Revit.UI;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OLPRibbonTab.Customs
{
    public static class RibbonExtensions
    {
        public static Autodesk.Revit.UI.RibbonItem SetStandardSize(this Autodesk.Revit.UI.RibbonItem ribbonItem, bool disableText)
        {
            Autodesk.Windows.RibbonItem ribbonItem1 = (Autodesk.Windows.RibbonItem)((object)ribbonItem).GetType().GetMethod("getRibbonItem", BindingFlags.Instance | BindingFlags.NonPublic).Invoke((object)ribbonItem, (object[])null);
            ribbonItem1.Size = RibbonItemSize.Standard;
            if (ribbonItem1 is Autodesk.Windows.RibbonButton ribbonButton)
                ribbonButton.Orientation = Orientation.Horizontal;
            ribbonItem1.ShowText = !disableText;
            return ribbonItem;
        }

        public static Autodesk.Revit.UI.RibbonItem SetLargeSize(this Autodesk.Revit.UI.RibbonItem ribbonItem, bool disableText = true)
        {
            Autodesk.Windows.RibbonItem internalRibbonItem = (Autodesk.Windows.RibbonItem)((object)ribbonItem).GetType().GetMethod("getRibbonItem", BindingFlags.Instance | BindingFlags.NonPublic).Invoke((object)ribbonItem, (object[])null);
            internalRibbonItem.Size = RibbonItemSize.Large;
            if (internalRibbonItem is Autodesk.Windows.RibbonButton ribbonButton)
                ribbonButton.Orientation = Orientation.Vertical;
            internalRibbonItem.ShowText = !disableText;
            return ribbonItem;
        }
    }
}
