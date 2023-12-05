using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.SheetEditor;

using System;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Sheet
{
    public class SheetEditorViewModel :
        IView, IAnchorComponent
    {

        #region -- 介面實做 ( Implements ) - [IView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ShowView()
        {
            var objContext = new SheetEditorViewContext();
            var objSendData = DTO.Decode<ShowSheetEditorSendData>();
            var objView = new SheetEditorView() { DataContext = objContext };

            Control = objView;
            RegionBundle.GetAnchorPoint(objSendData.RegiontHashCode).Mount(this);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IAnchorComponent] --

        public object Control { get; set; }
        public IAnchorPoint AnchorPoint { get; set; }
        public void OnComponetCleaned()
        {
        }

        #endregion

    }
}
