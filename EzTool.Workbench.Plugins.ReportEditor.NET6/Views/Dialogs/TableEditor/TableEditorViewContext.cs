using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Dialogs.TableEditor
{
    public class TableEditorViewContext :
        BaseViewContext
    {
        [SkipNotifyChanged]
        public IPresenter Presenter { get; set; }
        [SkipNotifyChanged]
        public DialogResultType ResultType { get; set; }
        [SkipNotifyChanged]
        public string ParentHashCode { get; set; }

        public int ColumnNumber { get; set; } = 1;
        public int RowNumber { get; set; } = 1;
    }
}
