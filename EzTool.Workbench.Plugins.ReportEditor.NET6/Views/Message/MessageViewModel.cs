using EzTool.SDK.Infra.Enigma.Extension;
using EzTool.SDK.WPF.Nerve.MVP.Interfaces;
using EzTool.SDK.WPF.Surface;
using EzTool.SDK.WPF.Surface.Interfaces;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects;

using Mono.Cecil;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Message
{

    public class MessageViewModel :
        IDialogView, IAnchorComponent
    {

        #region -- 介面實做 ( Implements ) - [IAnchorComponent] --

        public object Control { get; set; }
        public IAnchorPoint AnchorPoint { get; set; }
        public void OnComponetCleaned()
        {
            var objView = (MessageView )Control;
            var objContext = (MessageViewContext)objView.DataContext;

            DTO = objContext.Result.ToString();
            ViewClosed.Invoke();
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IDialogView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }
        public event Action ViewClosed;
        public void ShowView()
        {
            var objSendData = DTO.Decode<ShowMessageSendData>();
            var objContext = new MessageViewContext()
            {
                Presenter = Presenter,
                MaskHashCode = objSendData.HashCode,
                IsShowCancelButton = objSendData.MessageBoxType == Enums.MessageBoxType.YesNoCancel,
                IsShowNoButton = objSendData.MessageBoxType != Enums.MessageBoxType.Ok,
                IsShowYesButton = objSendData.MessageBoxType != Enums.MessageBoxType.Ok,
                IsShowOKButton = objSendData.MessageBoxType == Enums.MessageBoxType.Ok
            };
            var objView = new MessageView()
            {
                DataContext = objContext
            };

            Control = objView;
            RegionBundle.GetSingleton()?
                .FindByHashCode(objSendData.HashCode)?
                .GetAnchorPoint("test")?
                .Mount(this);
        }

        #endregion
    }
}
