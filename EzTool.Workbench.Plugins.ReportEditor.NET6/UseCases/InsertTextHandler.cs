using EzTool.SDK.Infra.Router.Interfaces;
using EzTool.SDK.Infra.Router.ValueObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document;

using System.Windows.Controls;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.UseCases
{
    public class InsertTextHandler :
        IActionHandler
    {
        public IRequireResponse Execute(IRequire pi_objRequire)
        {
            var objFilter = DocumentAnchorPointFilter.Initial();
            var objRegion = RegionBundle.GetSingleton().FindByHashCode(pi_objRequire.Operator);
            var objAnchorPoint = objRegion?.GetAnchorPoint(objFilter);

            if (objAnchorPoint?.AnchorComponent is IAnchorComponent objComponent)
            {
                var objView = (DocumentView)objComponent.Control;

                RichTextBoxProxy.Initial(objView.MainBox)
                    .Document.Blocks.Append(pi_objRequire.Parameters);
            }
            return new RequireResponse();
        }
    }
}
