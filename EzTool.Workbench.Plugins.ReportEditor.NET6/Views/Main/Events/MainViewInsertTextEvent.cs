using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.Workbench.Plugins.ReportEditor.NET6.UseCases;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    public class MainViewInsertTextEvent :
        BaseViewEvent<MainViewContext>
    {
        protected override void OnExecute()
        {
            var objRequire = new ViewRequire()
            {
                Action = $@"InsertText",
                Operator = ViewContext.HashCode,
                Parameters = $@"[text inserted]"
            };

            var objResult = ViewContext.Presenter.OnViewEvent(objRequire);


        }
    }
}
