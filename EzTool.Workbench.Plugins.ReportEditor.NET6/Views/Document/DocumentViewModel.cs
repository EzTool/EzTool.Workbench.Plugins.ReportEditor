using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document
{
    public class DocumentViewModel :
        IView, IAnchorComponent
    {

        #region -- 介面實做 ( Implements ) - [IView] --

        public object Control { get; set; }
        public IAnchorPoint AnchorPoint { get; set; }
        public void OnComponetCleaned() { }

        #endregion

        #region -- 介面實做 ( Implements ) - [IView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ShowView()
        {
            var objSendData = DTO.Decode<ShowDocumentSendData>();
            var objContext = new DocumentViewContext();
            var objView = new DocumentView() { DataContext = objContext };
            var sTabTitle = Path.GetFileName(objSendData.FilePath);

            sTabTitle = string.IsNullOrEmpty(sTabTitle) ? "New File" : sTabTitle;
            if (string.IsNullOrEmpty(objSendData.FilePath) == false)
            {
                var objDocument = objView.MainBox.Document;
                var objTextRange = new TextRange(objDocument.ContentStart, objDocument.ContentEnd);

                using (FileStream objFileStream = new FileStream(objSendData.FilePath, FileMode.Open))
                {
                    objTextRange.Load(objFileStream, DataFormats.XamlPackage);
                }
            }
            Control = objView;
            RegionBundle.GetSingleton()?
                .FindByHashCode(objSendData.HashCode)?
                .GetAnchorPoint(sTabTitle)?
                .Mount(this);
        }

        #endregion

    }
}
