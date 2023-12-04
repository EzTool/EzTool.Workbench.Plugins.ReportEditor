using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View
{
    public class TableProxy
    {
        public static Table Parse(TableSpec pi_objTableSpec)
        {
            var objTable = new Table();
            var objRowGroup = new TableRowGroup();
            
            objTable.RowGroups.Add(objRowGroup);
            objTable.Name = $@"BalanceSheet";
            objTable.Tag = DateTime.Now;
            return objTable;
        }

        public static TableSpec Parse(Table pi_objTable)
        {            
            return new TableSpec();
        }
    }
}
