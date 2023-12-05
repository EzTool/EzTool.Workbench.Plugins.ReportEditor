using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Sheet;

using System.Windows;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.SheetEditor.Events
{
    public class ClickButtonEvent :
        BaseViewEvent<SheetEditorViewContext>
    {
        protected override void OnExecute()
        {
            MessageBox.Show("hi");
        }
    }
}
