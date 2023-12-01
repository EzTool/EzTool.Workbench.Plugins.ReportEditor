using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document
{
    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class DocumentView : UserControl
    {
        public DocumentView()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var objTable = new Table();
            //var objRowGroup = new TableRowGroup();
            //var objRow1 = new TableRow();
            //var objCell11 = new TableCell()
            //{
            //    BorderBrush = new SolidColorBrush() { Color = Colors.Gray },
            //    BorderThickness = new Thickness(1, 1, 1, 1)
            //};
            //var objCell12 = new TableCell()
            //{
            //    BorderBrush = new SolidColorBrush() { Color = Colors.Gray },
            //    BorderThickness = new Thickness(1, 1, 1, 1)
            //};
            //objRow1.Cells.Add(objCell11);
            //objRow1.Cells.Add(objCell12);
            //objRowGroup.Rows.Add(objRow1);
            //objTable.RowGroups.Add(objRowGroup);

            //var objCaretPosition = MainBox.CaretPosition;

            //if (objCaretPosition?.Paragraph?.Parent is TableCell objTableCell)
            //{
            //    //處理表格內，已有文字
            //    objTableCell.Blocks.InsertBefore(objCaretPosition?.Paragraph, objTable);
            //}
            //else if (objCaretPosition?.Paragraph?.Parent is ListItem objListItem)
            //{
            //    //處理清單項，已有文字
            //    objListItem.Blocks.InsertBefore(objCaretPosition?.Paragraph, objTable);
            //}
            //else if (objCaretPosition?.Paragraph != null)
            //{
            //    //處理有文字
            //    MainBox.Document.Blocks.InsertBefore(objCaretPosition.Paragraph, objTable);
            //}
            //else if (objCaretPosition.Parent is TableCell objEmptyTableCell)
            //{
            //    //表格內
            //    objEmptyTableCell.Blocks.Add(objTable);
            //}
            //else if (objCaretPosition.Parent is TableRow objTableRow)
            //{
            //    //在表格段落的後面的外邊
            //    var objTableOfCarePosition = ((TableRowGroup)objTableRow.Parent).Parent;

            //    if (objTableOfCarePosition is Block objTableBlock)
            //    {
            //        MainBox.Document.Blocks.InsertAfter(objTableBlock, objTable);
            //    }
            //}
            //else if (objCaretPosition.Parent is FlowDocument objDocument)
            //{
            //    //在表格段落的最前面的外邊
            //    MainBox.Document.Blocks.InsertBefore(MainBox.Document.Blocks.FirstBlock, objTable);
            //}
        }
    }
}
