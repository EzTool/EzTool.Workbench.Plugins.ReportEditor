using System.Collections.Generic;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs
{
    public class TableRowSpecBundle
    {

        public TableRowSpec this[int nIndex] { get { return Rows[nIndex]; } }

        public List<TableRowSpec> Rows { get; set; }
    }
}
