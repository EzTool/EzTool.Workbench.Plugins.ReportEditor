using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Utilities;

using System;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main
{
    public class MainViewModel :
        IView
    {


        public IPresenter Presenter { get; set; }

        public string DTO { get; set; }

        public void ShowView()
        {
            var objView = new MainWindow();
            var objContext = new MainViewContext()
            {
                Presenter = Presenter ,
                HashCode = TabRegion.Initial(objView.MainTab)
            };
             
            objView.DataContext = objContext;           
            objView.ShowDialog();
        }
    }
}
