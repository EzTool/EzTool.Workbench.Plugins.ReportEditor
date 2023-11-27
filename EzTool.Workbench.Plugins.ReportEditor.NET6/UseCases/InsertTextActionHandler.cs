using EzTool.SDK.Infra.Router.Interfaces;
using EzTool.SDK.Infra.Router.ValueObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.UseCases
{
    public class InsertTextActionHandler :
        IActionHandler
    {
        public IRequireResponse Execute(IRequire pi_objRequire)
        {
            var objFilter = DocumentAnchorPointFilter.Initial();
            var objRegion = RegionBundle.GetSingleton().FindByHashCode(pi_objRequire.Parameters);
            var objAnchorPoint = objRegion.GetAnchorPoint(objFilter);

            if (objAnchorPoint.AnchorComponent is DocumentViewModel objDocument)
            {
                objDocument.InsertText();
            }
            return new RequireResponse();
        }
    }
}
