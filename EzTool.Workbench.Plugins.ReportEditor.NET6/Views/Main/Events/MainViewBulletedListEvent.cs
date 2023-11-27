using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    public class MainViewBulletedListEvent :
        BaseViewEvent<MainViewContext>
    {
        protected override void OnExecute()
        {
            var objRequire = new ViewRequire()
            {
                Action = $@"EditingCommand",
                Operator = ViewContext.HashCode,
                Parameters = EditingCommandType.BulletedList.ToString()
            };

            var objResult = ViewContext.Presenter.OnViewEvent(objRequire);
        }
    }
}
