using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Surface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Message.Events
{
    public class MessageViewCloseEvent:
        BaseViewEvent<MessageViewContext>
    {
        protected override void OnExecute()
        {
            RegionBundle.GetSingleton().FindByHashCode(ViewContext.MaskHashCode).GetAnchorPoint().Clean();
        }
    }
}
