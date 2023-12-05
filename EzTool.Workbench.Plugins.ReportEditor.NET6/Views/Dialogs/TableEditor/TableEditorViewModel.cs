using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.SDK.WPF.Surface;

using System;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;
using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.ResultDataObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;
using System.Collections.Generic;

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
            var objContext = (TableEditorViewContext)((TableEditorView)Control).DataContext;
            var objRowSpecs = new List<TableRowSpec>();

            for (int nRowIndex = 0; nRowIndex < objContext.RowNumber; nRowIndex++)
            {
                var objNewRowSpec = new TableRowSpec() { Cells = new List<TableCellSpec>() };

                for (int nColumnIndex = 0; nColumnIndex < objContext.ColumnNumber; nColumnIndex++)
                {
                    objNewRowSpec.Cells.Add(new TableCellSpec());
                }
                objRowSpecs.Add(objNewRowSpec);
            }

            var nResult = ((TableEditorViewContext)((TableEditorView)Control).DataContext).ResultType;
            var objResultData = new ShowTableEditorResultData()
            {
                IsModify = nResult == DialogResultType.Confirm,
                Table = new TableSpec()
                {
                    RowGroups = new List<TableRowGroupSpec>()
                    {
                        new TableRowGroupSpec()
                        {
                            Rows = objRowSpecs
                        }
                    }
                }
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
}
