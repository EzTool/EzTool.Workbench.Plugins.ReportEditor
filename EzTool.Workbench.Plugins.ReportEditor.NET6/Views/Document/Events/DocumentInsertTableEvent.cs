using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document.Events
{

    public class DocumentInsertTableEvent :
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
            //System.Threading.Thread.Sleep(2000);
            //var objRequire2 = new ViewRequire()
            //{
            //    Action = $@"ShowView",
            //    Operator = $@"Message",
            //    Parameters = new ShowMessageSendData()
            //    {
            //        HashCode = ViewContext.MaskHashCode,
            //        MessageBoxType = Enums.MessageBoxType.Ok
            //    }.Encode().ToString()
            //};
            //var objResult2 = ViewContext.Presenter.OnViewEvent(objRequire2);            
        }
    }
}
