using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.ValueObjects;
using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Main.Events
{
    public class MainViewOpenFileEvent :
        BaseViewEvent<MainViewContext>
    {
        protected override void OnExecute()
        {
            //取得檔案路徑
            var sFilePath = string.Empty;
            var objOpenFileDialog = new Microsoft.Win32.OpenFileDialog();

            objOpenFileDialog.Multiselect = false;
            objOpenFileDialog.Filter = "XAML Packages(*.xamlpackage)|*.xamlpackage";
            if (objOpenFileDialog.ShowDialog() == true)
            {
                sFilePath = objOpenFileDialog.FileName;
            }
            //開啟檔案
            var objRequire = new ViewRequire()
            {
                Action = $@"ShowView",
                Operator = $@"Document",
                Parameters = new ShowDocumentSendData()
                {
                    HashCode = ViewContext.HashCode,
                    FilePath = sFilePath
                }.Encode().ToString()
            };
            var objResult = ViewContext.Presenter.OnViewEvent(objRequire);
        }
    }
}
