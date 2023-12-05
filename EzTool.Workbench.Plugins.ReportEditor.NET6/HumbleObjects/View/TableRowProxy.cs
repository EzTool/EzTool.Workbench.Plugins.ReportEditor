using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View
{
    public  class TableRowProxy:
        ITableRowProxy
    {
        #region -- 變數宣告 ( Declarations ) --   

        private TableRow l_objTableRow;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public TableRowProxy(TableRow pi_objTableRow)
        {
            this.l_objTableRow = pi_objTableRow;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static ITableRowProxy Initial(TableRow pi_objTableRow)
        {
            return new TableRowProxy(pi_objTableRow);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [ITableRowProxy] --


        #endregion

    }

    public interface ITableRowProxy
    {
    }
}
