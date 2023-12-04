using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

using System;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View
{
    public class TableProxy :
        ITableProxy
    {
        #region -- 變數宣告 ( Declarations ) --   

        private Table l_objTable;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private TableProxy(Table pi_objTable)
        {
            this.l_objTable = pi_objTable;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static ITableProxy Initial(Table pi_objTable)
        {
            return new TableProxy(pi_objTable);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [ITableProxy] --
        public TableSpec ParseAsSpec()
        {
            return new TableSpec();
        }

        #endregion

    }

    public interface ITableProxy
    {
        TableSpec ParseAsSpec();
    }
}
