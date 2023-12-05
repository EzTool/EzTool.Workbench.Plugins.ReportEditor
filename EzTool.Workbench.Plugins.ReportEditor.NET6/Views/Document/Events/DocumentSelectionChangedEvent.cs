using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document.Events
{
    public class DocumentSelectionChangedEvent :
        BaseViewEvent<DocumentViewContext>
    {
        public override void PreExecute()
        {
            ViewContext.IsShowMask = ViewContext.RIchTextBox.IsSelectedTable;
        }

        protected override void OnExecute()
        {
            //if (ViewContext.RIchTextBox.IsSelectedTable)
            //{
            //    var objTableSpec = ViewContext.RIchTextBox.GetSelectedTableSpec();
            //    var objRequire = new ViewRequire()
            //    {
            //        Action = $@"ShowView",
            //        Operator = $@"TableEditor",
            //        Parameters = new ShowTableEditorSendData()
            //        {
            //            HashCode = ViewContext.MaskHashCode,
            //            Table = objTableSpec
            //        }.Encode().ToString()
            //    };
            //    var objResponse = ViewContext.Presenter.OnViewEvent(objRequire);
            //}
        }

        public override void DisplayResponse()
        {
            ViewContext.IsShowMask = false;
        }
    }
}
