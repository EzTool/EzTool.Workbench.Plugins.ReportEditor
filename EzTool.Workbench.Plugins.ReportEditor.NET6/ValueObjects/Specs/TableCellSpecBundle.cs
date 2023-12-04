using System.Collections.Generic;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs
{
    public class TableCellSpecBundle
    {
        public TableCellSpec this[int nIndex] { get { return Cells[nIndex]; } }

        public List<TableCellSpec> Cells { get; set; }
    }
}
