using EzTool.SDK.WPF.Nerve.MVP.Interfaces;

using System;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main
{
    public class MainViewModle :
        IView
    {
       
        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ShowView()
        {
           new MainWindow().ShowDialog();
        }
    }
}
