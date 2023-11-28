using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    public class MainViewPocButtonClickEvent :
         BaseViewEvent<MainViewContext>
    {

        protected override void OnExecute()
        {
            var objRegion = RegionBundle.GetSingleton().FindByHashCode(ViewContext.HashCode);
            var objFilter = DocumentAnchorPointFilter.Initial();
            var objAnchorPoint = objRegion?.GetAnchorPoint(objFilter);
            var objComponent = (IAnchorComponent)objAnchorPoint?.AnchorComponent;
            var objDocumentView = (DocumentView)objComponent?.Control;
            var objDocument = objDocumentView.MainBox.Document;

            var objButton = new TextBlock() { Width = 125, Height = 25, Text = "DEMO" };
            var objFlowDowument = FlowDocumentProxy.Initial(objDocument);

            objFlowDowument.Blocks.Append(objButton);
        }

        private void SetBulletedAsBox()
        {
            var objRegion = RegionBundle.GetSingleton().FindByHashCode(ViewContext.HashCode);
            var objFilter = DocumentAnchorPointFilter.Initial();
            var objAnchorPoint = objRegion?.GetAnchorPoint(objFilter);
            var objComponent = (IAnchorComponent)objAnchorPoint?.AnchorComponent;
            var objDocumentView = (DocumentView)objComponent?.Control;
            var objRunObject = objDocumentView.MainBox.CaretPosition.Parent as Run;

            if (objRunObject != null)
            {
                var objListItem = objRunObject.Parent as ListItem;

                if (objListItem == null)
                {
                    var objP = objRunObject.Parent as Paragraph;

                    if (objP != null) //頂層物件，沒有母段落
                    {
                        var objListItemA = objP.Parent as ListItem;

                        if (objListItemA != null)
                        {
                            var objListA1 = objListItemA.Parent as List;

                            if (objListA1 != null) { objListA1.MarkerStyle = TextMarkerStyle.Box; }
                        }
                        else
                        {
                            //尚未標示為清單項目
                            EditingCommands.ToggleBullets.Execute(null, objDocumentView.MainBox);
                            var objAfterBulledtParagraph = objDocumentView.MainBox.CaretPosition.Paragraph as Paragraph;
                            var objAfterListItem = objAfterBulledtParagraph?.Parent as ListItem;
                            var objAFterList = objAfterListItem?.Parent as List;

                            if (objAFterList != null)
                            {
                                objAFterList.MarkerStyle = TextMarkerStyle.Box;
                            }
                        }
                    }
                }
            }
            else
            {
                var objParagraph = objDocumentView.MainBox.CaretPosition.Parent as Paragraph;

                if (objParagraph != null)
                {

                }
                else
                {
                    //選取表格
                    var objTabCellObject = objDocumentView.MainBox.CaretPosition.Parent as TableCell;

                }
            }
        }
    }
}
