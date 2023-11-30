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
using System.Windows.Media;

using static System.Net.Mime.MediaTypeNames;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    public class MainViewPocButtonClickEvent :
         BaseViewEvent<MainViewContext>
    {

        public override void PreExecute()
        {
            var objRequire = new ViewRequire()
            {
                Action = $@"ShowView",
                Operator = $@"Message",
                Parameters = new ShowMessageSendData()
                {
                    HashCode = ViewContext.MaskLayerHashCode
                }.Encode().ToString()
            };
            var objResult = ViewContext.Presenter.OnViewEvent(objRequire);
            var s = objResult.Result;
        }
        protected override void OnExecute()
        {

            //var objRegion = RegionBundle.GetSingleton().FindByHashCode(ViewContext.HashCode);
            //var objFilter = DocumentAnchorPointFilter.Initial();
            //var objAnchorPoint = objRegion?.GetAnchorPoint(objFilter);
            //var objComponent = (IAnchorComponent)objAnchorPoint?.AnchorComponent;
            //var objDocumentView = (DocumentView)objComponent?.Control;
            //var objRichTextBoxInstance = objDocumentView.MainBox;
            //var objFlowDocumentInstance = objRichTextBoxInstance.Document;

            //var objRichTextBox = RichTextBoxProxy.Initial(objRichTextBoxInstance);
            //var objFlowDocument = FlowDocumentProxy.Initial(objFlowDocumentInstance);

            //var objGrid = new Grid() { Width = 130, Height = 50 };

            //objFlowDocument.Blocks.Append(objGrid);

            ////var objDocument = objDocumentView.MainBox.Document;
            ////var objRichTextBox = RichTextBoxProxy.Initial(objDocumentView.MainBox);

            ////objRichTextBox.SetRef(EditableTabl());
        }


        private string EditableTabl()
        {
            StringBuilder tableRtf = new StringBuilder();
            tableRtf.Append(@"{");
            tableRtf.Append(@"\rtf1\ansi\deff0
\trowd
\cellx1000
\cellx2000
\cellx3000
\intbl cell 1\cell
\intbl cell 2\cell
\intbl cell 3\cell
\row");
            tableRtf.Append(@"}");

            string combined2 = tableRtf.ToString();
            return combined2;
        }

        private Table BuildTable()
        {
            Table t = new Table();
            //for (int i = 0; i < 7; i++)
            //{
            //    t.Columns.Add(new TableColumn());
            //}

            var rg = new TableRowGroup();

            for (int r = 0; r < 3; r++)
            {
                TableRow row = new TableRow();
                row.Background = Brushes.Silver;
                row.FontSize = 16;
                row.FontWeight = FontWeights.Bold;
                for (int i = 0; i < 7; i++)
                {
                    row.Cells.Add(new TableCell(new Paragraph(new Run($@"{r}-{i}"))));
                }
                //row.Cells[0].ColumnSpan = 6;
                rg.Rows.Add(row);
            }
            t.RowGroups.Add(rg);
            return t;
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
