using System.Collections.Generic;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs
{
    /// <summary>
    /// 定義表格規格資料
    /// </summary>
    public class TableSpec
    {
        public List<TableRowGroupSpec> RowGroups { get; set; }
    }
}
