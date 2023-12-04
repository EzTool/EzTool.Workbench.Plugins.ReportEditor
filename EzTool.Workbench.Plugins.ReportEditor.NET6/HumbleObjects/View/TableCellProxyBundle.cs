using EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View
{
    public class TableCellProxyBundle :
        ITableCellProxyBundle
    {
        #region -- 變數宣告 ( Declarations ) --   

        private TableCellCollection l_objCells;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public TableCellProxyBundle(TableCellCollection pi_objCells)
        {
            this.l_objCells = pi_objCells;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static ITableCellProxyBundle Initial(TableCellCollection pi_objCells)
        {
            return new TableCellProxyBundle(pi_objCells);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [ITableCellProxyBundle] --

        public TableCellSpecBundle ParseAsSpec()
        {
            var objCells = new List<TableCellSpec>();

            foreach (TableCell objCell in l_objCells)
            {
                objCells.Add(TableCellProxy.Initial(objCell).ParseAsSpec());
            }
            return new TableCellSpecBundle() { Cells = objCells};
        }

        #endregion
    }

    public interface ITableCellProxyBundle
    {
        List<TableCellSpec> ParseAsSpec();
    }
}
