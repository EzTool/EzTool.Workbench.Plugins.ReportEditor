using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Surface;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Message.Events
{
    public class MessageViewButtonClickEvent:
        BaseViewEvent<MessageViewContext>
    {
        public MessageBoxButtonType ButtonType { get; set; }

        protected override void OnExecute()
        {
            ViewContext.Result = ButtonType;
            RegionBundle.GetSingleton().FindByHashCode(ViewContext.MaskHashCode).GetAnchorPoint().Clean();
        }
    }
}
