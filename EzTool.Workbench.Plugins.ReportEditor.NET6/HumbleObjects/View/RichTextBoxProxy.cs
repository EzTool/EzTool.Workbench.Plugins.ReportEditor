using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using static HarmonyLib.Code;
using System.Windows.Shapes;
using System.Windows.Automation.Text;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View
{
    public class RichTextBoxProxy :
        IRichTextBoxProxy
    {
        #region -- 變數宣告 ( Declarations ) --   

        private RichTextBox l_objRichTextBox;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private RichTextBoxProxy(RichTextBox pi_objRichTextBox)
        {
            l_objRichTextBox = pi_objRichTextBox;
        }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --
        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IRichTextBoxProxy Initial(RichTextBox pi_objRichTextBox)
        {
            return new RichTextBoxProxy(pi_objRichTextBox);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IRichTextBoxProxy] --

        public void Insert(TableSpec pi_objTable)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                Insert(pi_objTable.Parse());
            });
        }

        public TableSpec GetSelectedTableSpec()
        {
            var objCaretPosition = l_objRichTextBox.CaretPosition;
            var objTableCell =
                objCaretPosition?.Paragraph?.Parent is TableCell objPParent ? objPParent :
                objCaretPosition?.Parent is TableCell objParent ? objParent : null;

            var objRow = objTableCell != null ? (TableRow)objTableCell.Parent : null;
            var objRowGroup = objRow != null ? (TableRowGroup)objRow.Parent : null;
            var objTable = objRowGroup != null ? (Table)objRowGroup.Parent : null;

            //return TableProxy.Parse(objTable);
            return new TableSpec();
        }

        public bool IsSelectedTable
        {
            get
            {
                var objCaretPosition = l_objRichTextBox.CaretPosition;

                return objCaretPosition?.Paragraph?.Parent is TableCell ||
                       objCaretPosition?.Parent is TableCell;

            }
        }

        public void SetRef(string pi_sRTF)
        {
            MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(pi_sRTF));
            l_objRichTextBox.Selection.Load(stream, DataFormats.Rtf);
        }

        public void BulletedList()
        {
            EditingCommands.ToggleBullets.Execute(null, l_objRichTextBox);
        }

        public void Append(IBitMapImageProxy pi_objImage)
        {
            Paragraph p = new Paragraph();
            TextBlock objText = new TextBlock() { Text = "Text\r\n2nd row" };
            InlineUIContainer b1Image = pi_objImage.ToContainer();
            InlineUIContainer b2Text = new InlineUIContainer(objText);

            b1Image.BaselineAlignment = BaselineAlignment.Center;
            p.Inlines.Add(b1Image);
            p.Inlines.Add(b2Text);
            l_objRichTextBox.Document.Blocks.Add(p);
        }

        public IFlowDocumentProxy Document
        {
            get
            {
                return FlowDocumentProxy.Initial(l_objRichTextBox.Document);
            }
        }

        #endregion

        #region -- 私有函式 ( Private Method) --

        private void Insert(Table pi_objTable)
        {
            var objCaretPosition = l_objRichTextBox.CaretPosition;

            if (objCaretPosition?.Paragraph?.Parent is TableCell objTableCell)
            {
                //處理表格內，已有文字
                objTableCell.Blocks.InsertBefore(objCaretPosition?.Paragraph, pi_objTable);
            }
            else if (objCaretPosition?.Paragraph?.Parent is ListItem objListItem)
            {
                //處理清單項，已有文字
                objListItem.Blocks.InsertBefore(objCaretPosition?.Paragraph, pi_objTable);
            }
            else if (objCaretPosition?.Paragraph != null)
            {
                //處理有文字
                l_objRichTextBox.Document.Blocks.InsertBefore(objCaretPosition.Paragraph, pi_objTable);
            }
            else if (objCaretPosition.Parent is TableCell objEmptyTableCell)
            {
                //表格內
                objEmptyTableCell.Blocks.Add(pi_objTable);
            }
            else if (objCaretPosition.Parent is TableRow objTableRow)
            {
                //在表格段落的後面的外邊
                var objTableOfCarePosition = ((TableRowGroup)objTableRow.Parent).Parent;

                if (objTableOfCarePosition is Block objTableBlock)
                {
                    l_objRichTextBox.Document.Blocks.InsertAfter(objTableBlock, pi_objTable);
                }
            }
            else if (objCaretPosition.Parent is FlowDocument objDocument)
            {
                //在表格段落的最前面的外邊
                l_objRichTextBox.Document.Blocks.InsertBefore(l_objRichTextBox.Document.Blocks.FirstBlock, pi_objTable);
            }
        }

        #endregion

    }

    public interface IRichTextBoxProxy
    {
        void SetRef(string pi_sRTF);
        void BulletedList();
        IFlowDocumentProxy Document { get; }

        void Append(IBitMapImageProxy pi_objImage);
        void Insert(TableSpec table);
        TableSpec GetSelectedTableSpec();
        bool IsSelectedTable { get; }
    }
}
