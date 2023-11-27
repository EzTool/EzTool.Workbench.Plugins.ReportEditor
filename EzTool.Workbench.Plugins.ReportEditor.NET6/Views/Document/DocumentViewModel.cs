using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using System;
using System.Windows;
using System.Windows.Controls;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document
{
    public class DocumentViewModel :
        IView, IAnchorComponent
    {

        #region -- 介面實做 ( Implements ) - [IView] --

        public object Control { get; set; }
        public IAnchorPoint AnchorPoint { get; set; }
        public void OnComponetCleaned()
        {

        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ShowView()
        {
            var objContext = new DocumentViewContext();
            var objSendData = DTO.Decode<ShowDocumentSendData>();
            var sTabTitle = "NewFile";

            Control = new DocumentView()
            {
                DataContext = objContext
            };
            RegionBundle.GetSingleton()?
                .FindByHashCode(objSendData.HashCode)?
                .GetAnchorPoint(sTabTitle)?
                .Mount(this);
        }

        internal void InsertText()
        {
        }

        #endregion

    }
}
