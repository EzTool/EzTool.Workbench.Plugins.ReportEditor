using System.Collections.Generic;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs
{
    public class TableRowSpecBundle
    {
        private List<TableRowSpec> l_objRows = new List<TableRowSpec>();

        public TableRowSpec this[int nIndex] { get { return l_objRows[nIndex]; } }
    }
}
