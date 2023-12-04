using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.SDK.WPF.Surface;

using System;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;
using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.ResultDataObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

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
            var nResult = ((TableEditorViewContext)((TableEditorView)Control).DataContext).ResultType;
            var objResultData = new ShowTableEditorResultData()
            {
                IsModify = nResult == DialogResultType.Confirm,
                Table = new TableSpec()
            };

            DTO = objResultData.Encode().ToString();
            ViewClosed?.Invoke();
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IDialogView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }
        public object Control { get; set; }

        public void ShowView()
        {
            var objSendData = DTO.Decode<ShowTableEditorSendData>();
            var objContext = new TableEditorViewContext()
            {
                Presenter = Presenter,
                ParentHashCode = objSendData.HashCode
            };
            var objView = new TableEditorView()
            {
                DataContext = objContext
            };

            Control = objView;
            RegionBundle.GetAnchorPoint(objSendData.HashCode).Mount(this);
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
