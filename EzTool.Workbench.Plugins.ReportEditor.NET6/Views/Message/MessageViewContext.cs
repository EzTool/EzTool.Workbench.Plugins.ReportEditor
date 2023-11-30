using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Message
{
    public class MessageViewContext :
        BaseViewContext
    {
        [SkipNotifyChanged]
        public IPresenter Presenter { get; set; }
        [SkipNotifyChanged]
        public string MaskHashCode { get; set; }

        public MessageBoxButtonType Result { get;set; }
        public bool IsShowOKButton { get; set; }
        public bool IsShowYesButton { get; set; }
        public bool IsShowNoButton { get; set; }
        public bool IsShowCancelButton { get; set; }
    }
}
