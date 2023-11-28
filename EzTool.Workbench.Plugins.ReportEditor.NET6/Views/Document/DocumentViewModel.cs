using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
            var objContext = new DocumentViewContext()
            {
                ParentHashCode = objSendData.HashCode,
                Presenter = Presenter,
                FilePath = objSendData.FilePath,
                TabTitle = $@"New File"
            };
            var objView = new DocumentView() { DataContext = objContext };
            var objTabTitle = objContext.GetTabTitleControl();
           
            Control = objView;
            RegionBundle.GetSingleton()?
                .FindByHashCode(objSendData.HashCode)?
                .GetAnchorPoint(objTabTitle)?
                .Mount(this);
        }

        #endregion

    }
}
