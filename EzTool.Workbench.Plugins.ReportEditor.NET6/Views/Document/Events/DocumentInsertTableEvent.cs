using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document.Events
{

    public class DocumentInsertTableEvent:
        BaseViewEvent<DocumentViewContext>
    {
        public override void PreExecute()
        {
            var objRequire = new ViewRequire()
            {
                Action = $@"ShowView",
                Operator = $@"TableEditor",
                Parameters = ViewContext.MaskHashCode
            };
            var objResult = ViewContext.Presenter.OnViewEvent(objRequire);

            MessageBox.Show(objResult.Result);
        }
        protected override void OnExecute()
        {
               

           
        }
    }
}
