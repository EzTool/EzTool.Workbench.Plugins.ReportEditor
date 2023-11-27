using EzTool.SDK.Infra.Router.Interfaces;
using EzTool.SDK.Infra.Router.ValueObjects;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.SDK.WPF.Surface;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;
using System.Windows.Documents;
using System;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.UseCases
{
    public class EditingCommandHandler :
        IActionHandler
    {
        public IRequireResponse Execute(IRequire pi_objRequire)
        {
            var objReturn = new RequireResponse();
            var objFilter = DocumentAnchorPointFilter.Initial();
            var objRegion = RegionBundle.GetSingleton().FindByHashCode(pi_objRequire.Operator);
            var objAnchorPoint = objRegion?.GetAnchorPoint(objFilter);

            if (objAnchorPoint?.AnchorComponent is IAnchorComponent objComponent)
            {
                var objView = (DocumentView)objComponent.Control;

                if (Enum.TryParse(pi_objRequire.Parameters, out EditingCommandType nType))
                {
                    switch (nType)
                    {
                        case EditingCommandType.BulletedList:
                            EditingCommands.ToggleBullets.Execute(null, objView.MainBox);
                            break;
                        case EditingCommandType.Numbering:
                            EditingCommands.ToggleNumbering.Execute(null, objView.MainBox);
                            break;
                    }
                }
            }

            return objReturn;
        }
    }
}
