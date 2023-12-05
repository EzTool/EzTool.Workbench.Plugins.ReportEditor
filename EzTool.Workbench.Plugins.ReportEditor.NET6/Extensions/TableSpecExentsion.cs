using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions
{
    public static class TableSpecExentsion
    {
        public static Table Parse(this TableSpec pi_objTableSepc)
        {
            var objTable = new Table() {                
                BorderThickness = new Thickness(1),
                BorderBrush = new SolidColorBrush(Color.FromRgb(125, 125, 125)),
                CellSpacing = 0};
            var objColumn = new TableColumn() { Width = new GridLength(200) };

            objTable.Columns.Add(objColumn);
            foreach (TableRowGroupSpec objRowGroupSpec in pi_objTableSepc.RowGroups)
            {
                var objTableRowGroup = new TableRowGroup();

                foreach (TableRowSpec objRowSpec in objRowGroupSpec.Rows)
                {
                    var objTableRow = new TableRow();

                    foreach (TableCellSpec objCellSpec in objRowSpec.Cells)
                    {
                        objTableRow.Cells.Add(new TableCell()
                        {    
                            Padding = new Thickness(0),
                            BorderThickness = new Thickness(1),
                            BorderBrush = new SolidColorBrush(Color.FromRgb(125, 125, 125)),                            
                        }) ;
                    }
                    objTableRowGroup.Rows.Add(objTableRow);
                }
                objTable.RowGroups.Add(objTableRowGroup);
            }

            return objTable;
        }
    }
}
