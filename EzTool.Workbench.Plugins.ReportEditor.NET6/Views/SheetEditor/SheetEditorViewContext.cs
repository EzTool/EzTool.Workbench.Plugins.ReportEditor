using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Sheet
{
    public class SheetEditorViewContext :
        BaseViewContext
    {
        public int Width { get; set; } = 100;
        public int Cell11 { get; set; } = 0;
        public int Cell12 { get; set; } = 0;
        public int Cell13 { get; set; } = 10;
    }
}
