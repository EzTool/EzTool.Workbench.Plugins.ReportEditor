using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document.Events
{
    public class DocumentViewSliderValueChangedEvent :
        BaseViewEvent<DocumentViewContext>
    {
        protected override void OnExecute()
        {
            if (ViewContext.SliderValue < 1)
            {
                ViewContext.Zoom = ViewContext.SliderValue;
            }
            else
            {
                ViewContext.Zoom = 1 + ((ViewContext.SliderValue - 1) * (8 / 4));
            }
        }
    }
}
