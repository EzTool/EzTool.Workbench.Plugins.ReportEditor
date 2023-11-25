using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.Infra.Router.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    public class MainViewNewDocumentEvent:
        BaseViewEvent<MainViewContext>
    {
        protected override void OnExecute()
        {
            var objRequire = new ViewRequire()
            {
                Action = $@"ShowView",
                Operator = $@"Document",
                Parameters = new ShowDocumentSendData()
                {
                    HashCode = ViewContext.HashCode
                }.Encode().ToString()
            };

            var objResult = ViewContext.Presenter.OnViewEvent(objRequire);
        }
    }
}
