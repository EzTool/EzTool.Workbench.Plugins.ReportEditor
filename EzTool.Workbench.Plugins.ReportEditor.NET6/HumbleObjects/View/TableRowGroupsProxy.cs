using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View
{
    public class TableRowGroupsProxy :
        ITableRowGroupsProxy
    {
        #region -- 變數宣告 ( Declarations ) --   

        private TableRowGroupCollection l_objRowGroups;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private TableRowGroupsProxy(TableRowGroupCollection pi_objRowGroups)
        {
            this.l_objRowGroups = pi_objRowGroups;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static ITableRowGroupsProxy Initial(TableRowGroupCollection pi_objRowGroups)
        {
            return new TableRowGroupsProxy(pi_objRowGroups);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [ITableRowGroupsProxy] --

        #endregion

    }

    public interface ITableRowGroupsProxy
    {
        //TableRowGroupBundleSpec
    }
}
