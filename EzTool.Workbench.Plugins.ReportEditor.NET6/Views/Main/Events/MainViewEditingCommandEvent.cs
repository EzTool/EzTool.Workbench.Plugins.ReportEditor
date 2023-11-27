using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    public class MainViewEditingCommandEvent :
        BaseViewEvent<MainViewContext>
    {
        public string Command { get; set; }

        protected override void OnExecute()
        {
            var objRequire = new ViewRequire()
            {
                Action = $@"EditingCommand",
                Operator = ViewContext.HashCode,
                Parameters = Command
            };

            var objResult = ViewContext.Presenter.OnViewEvent(objRequire);
        }
    }

}
