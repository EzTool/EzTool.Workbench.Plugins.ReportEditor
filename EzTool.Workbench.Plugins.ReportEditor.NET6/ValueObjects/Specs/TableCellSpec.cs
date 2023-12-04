using EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View;

using System.Security.AccessControl;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs
{
    public class TableCellSpec
    {

        #region -- 靜態方法 (Shared Method ) --

        public static TableCellSpec Initial(ITableCellProxy pi_objTableCell)
        {
            return  new TableCellSpec()
            {
                Padding = pi_objTableCell.Padding,
                BordColor = pi_objTableCell.BordColor
            };
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        public ThicknessSepc Padding { get; set; }
        public RgbFormColorSpec BordColor { get; set; }

        #endregion

    }
}
