using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.SDK.WPF.Nerve.MVVM.Tags;
using EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View;

using System.Windows;

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
        public string MaskHashCode { get; set; }
        [SkipNotifyChanged]
        public string FilePath { get; set; }
        [SkipNotifyChanged]
        public IRichTextBoxProxy RIchTextBox { get; set; }

        public string TabTitle { get; set; }
        public double SliderValue { get; set; } = 1;
        public double Width { get; set; } = 816;
        public double Height { get; set; } = 1056;
        public Thickness Padding { get; set; } = new Thickness(96,96,96,96);
        public double Zoom { get; set; } = 1;
        public bool IsShowMask { get; set; }
    }
}
