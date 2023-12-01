using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Dialogs.TableEditor.Events
{
    public  class TableEditorCloseEvent:
        BaseViewEvent<TableEditorViewContext>
    {
        public DialogResultType ResultType { get; set; }

        protected override void OnExecute()
        {
            ViewContext.ResultType = ResultType;
            RegionBundle.GetAnchorPoint(ViewContext.ParentHashCode).Clean();
        }
    }
}
