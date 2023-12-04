using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View
{
    public class TableCellProxy :
        ITableCellProxy
    {

        #region -- 變數宣告 ( Declarations ) --   

        private TableCell l_objTableCell;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public TableCellProxy(TableCell pi_objTableCell)
        {
            this.l_objTableCell = pi_objTableCell;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static ITableCellProxy Initial(TableCell pi_objTableCell)
        {
            return new TableCellProxy(pi_objTableCell);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [ITableCellProxy] --

        public ThicknessSepc Padding
        {
            get
            {
                return ThicknessSepc.Initial(
                    l_objTableCell.Padding.Left,
                    l_objTableCell.Padding.Top,
                    l_objTableCell.Padding.Right,
                    l_objTableCell.Padding.Bottom);
            }
        }

        public RgbFormColorSpec BordColor
        {
            get
            {
                var objReturn = default(RgbFormColorSpec);

                if (l_objTableCell.BorderBrush is SolidColorBrush objColor)
                {
                    objReturn = new RgbFormColorSpec()
                    {
                        R = objColor.Color.R,
                        G = objColor.Color.G,
                        B = objColor.Color.B
                    };
                }
                return objReturn;
            }
        }

        #endregion


    }

    public interface ITableCellProxy
    {
        ThicknessSepc Padding { get; }
        RgbFormColorSpec BordColor { get; }
    }
}
