﻿using EzTool.Workbench.Plugins.ReportEditor.NET6.Enums;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.SendDataObjects
{
    public class ShowMessageSendData
    {
        public string HashCode { get; set; }
        public MessageBoxType MessageBoxType { get; set; }
    }
}
