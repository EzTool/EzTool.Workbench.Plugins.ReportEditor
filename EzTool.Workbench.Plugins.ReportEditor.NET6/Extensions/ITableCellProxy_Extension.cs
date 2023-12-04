using EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions
{
    public static class ITableCellProxy_Extension
    {
        public static TableCellSpec ParseAsSpec(this ITableCellProxy pi_objTableCell)
        {
            return new TableCellSpec()
            {
                Padding = pi_objTableCell.Padding,
                BordColor = pi_objTableCell.BordColor,
            };
        }
    }
}
