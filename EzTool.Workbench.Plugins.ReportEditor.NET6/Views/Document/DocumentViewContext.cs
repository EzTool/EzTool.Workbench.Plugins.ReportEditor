using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document
{
    public class DocumentViewContext :
        BaseViewContext
    {
        [SkipNotifyChanged]
        public IPresenter Presenter { get; set; }
        [SkipNotifyChanged]
        public string ParentHashCode { get; set; }
        [SkipNotifyChanged]
        public string FilePath { get; set; }

        public string TabTitle { get; set; }
        public double SliderValue { get; set; } = 1;
        public double Width { get; set; } = 595;
        public double Height { get; set; } = 842;
        public double Zoom { get; set; } = 1;
    }
}
