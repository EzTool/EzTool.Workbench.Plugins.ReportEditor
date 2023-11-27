using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document
{
    public class DocumentViewContext :
        BaseViewContext
    {
        public double SliderValue { get; set; } = 1;
        public double Width { get; set; } = 595;
        public double Height { get; set; } = 842;
        public double Zoom { get; set; } = 1;
    }
}
