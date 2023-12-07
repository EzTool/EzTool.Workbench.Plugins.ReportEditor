using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.Interfaces.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.ResultDataObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document.Events
{

    public class DocumentInsertTableEvent :
        BaseViewEvent<DocumentViewContext>
    {

        public override void PreExecute()
        {
            ViewContext.IsShowMask = true;
        }

        protected override void OnExecute()
        {
            var objResponse = ShowTableEditor();
            var objResult = objResponse.IsSuccess ?
                objResponse.Result.Decode<ShowTableEditorResultData>() :
                new ShowTableEditorResultData() { IsModify = false };

            if (objResult != null && objResult.IsModify)
            {
                ViewContext.RichTextBox.Insert(objResult.Table);
                //var sHashCode = ViewContext.RichTextBox.GetAnchorPoint();
                //ShowSheetEditor(sHashCode);
            }
        }

        public override void DisplayResponse()
        {
            ViewContext.IsShowMask = false;
        }

        private void ShowSheetEditor(string pi_sHashCode)
        {
            var objRequire = new ViewRequire()
            {
                Action = $@"ShowView",
                Operator = $@"SheetEditor",
                Parameters = new ShowSheetEditorSendData()
                {
                    RegiontHashCode = pi_sHashCode
                }.Encode().ToString()
            };
            var objResponse = ViewContext.Presenter.OnViewEvent(objRequire);
        }

        private IModelResponse ShowTableEditor()
        {
            var objTableSpec = new TableSpec();
            var objRequire = new ViewRequire()
            {
                Action = $@"ShowView",
                Operator = $@"TableEditor",
                Parameters = new ShowTableEditorSendData()
                {
                    Table = objTableSpec,
                    HashCode = ViewContext.MaskHashCode
                }.Encode().ToString()
            };
            var objResponse = ViewContext.Presenter.OnViewEvent(objRequire);

            return objResponse;
        }

    }
}
