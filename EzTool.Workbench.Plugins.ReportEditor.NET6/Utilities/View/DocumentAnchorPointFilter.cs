using EzTool.SDK.WPF.Surface.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Utilities.View
{
    public class DocumentAnchorPointFilter :
        IAnchorPointFilter
    {

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private DocumentAnchorPointFilter()
        {
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IAnchorPointFilter Initial()
        {
            return new DocumentAnchorPointFilter();
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IAnchorPointFilter] --

        public bool IsTarget(IAnchorPoint pi_objAnchorPoint)
        {
            var bReturn = false;

            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                bReturn = pi_objAnchorPoint is ITabItemAbility objTabItem ? objTabItem.IsSelected : false;
            }));
            return bReturn;
        }

        #endregion
    }
}
