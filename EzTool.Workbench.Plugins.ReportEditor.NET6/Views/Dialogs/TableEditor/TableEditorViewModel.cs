using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.SDK.WPF.Surface;

using System;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Dialogs.TableEditor
{
    public class TableEditorViewModel :
   IDialogView, IAnchorComponent
    {

        #region -- 介面實做 ( Implements ) - [IAnchorComponent] --

        public IAnchorPoint AnchorPoint { get; set; }

        public event Action ViewClosed;

        public void OnComponetCleaned()
        {
            DTO = ((TableEditorViewContext)((TableEditorView)Control).DataContext).ResultType.ToString();
            ViewClosed?.Invoke();
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IDialogView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }
        public object Control { get; set; }

        public void ShowView()
        {
            var objContext = new TableEditorViewContext()
            {
                Presenter = Presenter,
                ParentHashCode = DTO
            };
            var objView = new TableEditorView()
            {
                DataContext = objContext
            };

            Control = objView;
            RegionBundle.GetAnchorPoint(DTO).Mount(this);
        }

        #endregion
    }

    public class TableEditorViewContext :
        BaseViewContext
    {
        [SkipNotifyChanged]
        public IPresenter Presenter { get; set; }
        [SkipNotifyChanged]
        public DialogResultType ResultType { get; set; }
        [SkipNotifyChanged]
        public string ParentHashCode { get; set; }
    }
}
