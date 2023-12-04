using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.ResultDataObjects
{
    public class ShowTableEditorResultData
    {
        public bool IsModify { get; set; }
        public TableSpec Table { get; set; }
    }

}
