using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    [RunOnMainThread]
    public class MainViewSaveFileEvent :
        BaseViewEvent<MainViewContext>
    {

        protected override void OnExecute()
        {
            var objRegion = RegionBundle.GetSingleton().FindByHashCode(ViewContext.HashCode);
            var objFilter = DocumentAnchorPointFilter.Initial();
            var objAnchorPoint = objRegion?.GetAnchorPoint(objFilter);

            if (objAnchorPoint != null)
            {
                ((IDocumentEditor)(IAnchorComponent)objAnchorPoint.AnchorComponent).SaveDocument();
            }
        }
    }
}
