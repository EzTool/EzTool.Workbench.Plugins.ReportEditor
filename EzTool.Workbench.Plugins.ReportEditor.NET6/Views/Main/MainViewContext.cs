using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main
{
    public class MainViewContext :
        BaseViewContext
    {

        [SkipNotifyChanged] 
        public IPresenter Presenter { get; set; }

        [SkipNotifyChanged]
        public string HashCode { get; set; }

        public double SliderValue { get; set; }
    }
}
