using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions
{
    public static class DocumentViewContextExtension
    {
        public static TextBlock GetTabTitleControl(this DocumentViewContext pi_objContext)
        {
            var objTabTitle = new TextBlock() { Margin = new Thickness() { Left = 10, Right = 10 } };
            var objBinding = new Binding(nameof(DocumentViewContext.TabTitle)) { Source = pi_objContext };
            BindingOperations.SetBinding(objTabTitle, TextBlock.TextProperty, objBinding);

            return objTabTitle;
        }
    }
}
