using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Sheet;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.SheetEditor.Events
{
    public  class ValueChangedEvent:
        BaseViewEvent<SheetEditorViewContext>
    {
        protected override void OnExecute()
        {
            ViewContext.Cell13 = ViewContext.Cell11 + ViewContext.Cell12;
        }
    }
}
