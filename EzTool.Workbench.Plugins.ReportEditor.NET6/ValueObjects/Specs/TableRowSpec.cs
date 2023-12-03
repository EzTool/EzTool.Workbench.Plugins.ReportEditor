using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs
{
    public class TableRowSpec
    {
        public TableCellSpecBundle Cells { get; set; }

        public TableRow Instance { get
            {
                var objTableRow = new TableRow();

                return objTableRow;
            } }
    }
}
