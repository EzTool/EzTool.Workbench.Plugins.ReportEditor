using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document;

using System;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    [RunOnMainThread]
    public class MainViewEditingCommandEvent :
        BaseViewEvent<MainViewContext>
    {
        public string Command { get; set; }

        protected override void OnExecute()
        {
            var objFilter = DocumentAnchorPointFilter.Initial();
            var objAnchorPoint = ViewContext.MainAnchorRegion?.GetAnchorPoint(objFilter);

            if (objAnchorPoint?.AnchorComponent is IAnchorComponent objComponent &&
                Enum.TryParse(Command, out EditingCommandType nType))
            {
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    switch (nType)
                    {
                        case EditingCommandType.BulletedList:
                            EditingCommands.ToggleBullets.Execute(null, ((DocumentView)objComponent.Control).MainBox);
                            break;
                        case EditingCommandType.Numbering:
                            EditingCommands.ToggleNumbering.Execute(null, ((DocumentView)objComponent.Control).MainBox);
                            break;
                    }
                }));
            }
        }
    }

}
