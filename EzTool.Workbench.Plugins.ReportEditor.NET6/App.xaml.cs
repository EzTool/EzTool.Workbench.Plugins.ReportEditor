using EzTool.SDK.Infra.Router;
using EzTool.SDK.Infra.Router.HumbleObjects;
using EzTool.SDK.Infra.Router.Utilities;
using EzTool.SDK.Infra.Router.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVP;
using EzTool.SDK.WPF.Nerve.MVP.Utilities;
using EzTool.SDK.WPF.Nerve.MVP.Utilities.DefaultObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DefaultViewProvider.ViewSuffix = "ViewModel";
            var objMvpCore = AssemblyProxy.Initial(typeof(DefaultViewProvider).Assembly);
            var objMvp = AssemblyProxy.Initial(typeof(ShowViewHandler).Assembly);
            var objReportEditor = AssemblyProxy.Initial(typeof(MainViewModel).Assembly);
            var objAssemblyBundle = AssemblyBundle.Initial(objMvp, objMvpCore, objReportEditor);
            var objRequire = new Require()
            {
                Action = "ShowView",
                Operator = "Main"
            };

            var objResponse = ForemanAgent.Initial(objAssemblyBundle)
                                .Execute(objRequire);            
        }
    }
}
