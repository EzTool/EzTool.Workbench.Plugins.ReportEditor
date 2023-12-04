using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions;
using EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using Microsoft.Win32;

using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document
{
    public class DocumentViewModel :
        IView, IAnchorComponent, IDocumentEditor
    {
        #region -- 介面實做 ( Implements ) - [IDocumentEditor] --

        public void SaveDocument()
        {
            var objSaveFileDialog1 = new SaveFileDialog()
            {
                Title = $@"Save File",
                Filter = $@"xamlpackage|*.xamlpackage",
            };

            objSaveFileDialog1.ShowDialog();
            if (string.IsNullOrEmpty(objSaveFileDialog1.FileName) == false)
            {
                var objDocumentView = (DocumentView)this.Control;
                var objDocument = objDocumentView.MainBox.Document;
                var objTextRange = new TextRange(objDocument.ContentStart, objDocument.ContentEnd);

                using (FileStream objFileStream = new FileStream(objSaveFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    objTextRange.Save(objFileStream, DataFormats.XamlPackage);
                }
                ((DocumentViewContext)objDocumentView.DataContext).FilePath = objSaveFileDialog1.FileName;
                ((DocumentViewContext)objDocumentView.DataContext).TabTitle = Path.GetFileNameWithoutExtension(objSaveFileDialog1.FileName);
            }
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IAnchorComponent] --

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
            var objContext = new DocumentViewContext()
            {
                ParentHashCode = objSendData.HashCode,
                Presenter = Presenter,
                FilePath = objSendData.FilePath,
                TabTitle = $@"新建檔案"                
            };
            var objView = new DocumentView() { DataContext = objContext };
            var objTabTitle = objContext.GetTabTitleControl();
            var objRichTextBox = RichTextBoxProxy.Initial(objView.MainBox);

            objContext.RIchTextBox = objRichTextBox;
            objContext.MaskHashCode = objView.MainMask.GetHashCode().ToString();
            if (string.IsNullOrEmpty(objSendData.FilePath) == false)
            {
                var objDocumentView = objView;
                var objDocument = objDocumentView.MainBox.Document;
                var objTextRange = new TextRange(objDocument.ContentStart, objDocument.ContentEnd);

                using (FileStream objFileStream = new FileStream(objSendData.FilePath, FileMode.Open))
                {
                    objTextRange.Load(objFileStream, DataFormats.XamlPackage);
                }
                objContext.TabTitle = Path.GetFileNameWithoutExtension(objSendData.FilePath);
            }
            Control = objView;
            RegionBundle.GetSingleton()?
                .FindByHashCode(objSendData.HashCode)?
                .GetAnchorPoint(objTabTitle)?
                .Mount(this);            
        }

        #endregion

    }

    public interface IDocumentEditor
    {
        void SaveDocument();
    }
}
