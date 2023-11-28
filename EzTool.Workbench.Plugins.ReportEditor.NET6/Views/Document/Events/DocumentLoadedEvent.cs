using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View;

using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document.Events
{
    public class DocumentLoadedEvent :
        BaseViewEvent<DocumentViewContext>
    {
        protected override void OnExecute()
        {
            if (string.IsNullOrEmpty(ViewContext.FilePath) == false)
            {
                var objRegion = RegionBundle.GetSingleton().FindByHashCode(ViewContext.ParentHashCode);
                var objFilter = DocumentAnchorPointFilter.Initial();
                var objAnchorPoint = objRegion?.GetAnchorPoint(objFilter);
                var objAnchorComponent = objAnchorPoint?.AnchorComponent;

                if (objAnchorComponent != null)
                {
                    var objDocumentView = (DocumentView)((IAnchorComponent)objAnchorComponent).Control;
                    var objDocument = objDocumentView.MainBox.Document;
                    var objTextRange = new TextRange(objDocument.ContentStart, objDocument.ContentEnd);

                    using (FileStream objFileStream = new FileStream(ViewContext.FilePath, FileMode.Open))
                    {
                        objTextRange.Load(objFileStream, DataFormats.XamlPackage);
                    }
                    ViewContext.TabTitle = Path.GetFileName(ViewContext.FilePath);
                }
            }
        }
    }
}
