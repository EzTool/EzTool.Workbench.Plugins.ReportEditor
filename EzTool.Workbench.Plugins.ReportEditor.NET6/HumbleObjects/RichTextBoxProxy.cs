using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects
{
    public class RichTextBoxProxy :
        IRichTextBoxProxy
    {
        #region -- 變數宣告 ( Declarations ) --   

        private RichTextBox l_objRichTextBox;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private RichTextBoxProxy(RichTextBox pi_objRichTextBox)
        {
            this.l_objRichTextBox = pi_objRichTextBox;
        }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --
        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IRichTextBoxProxy Initial(RichTextBox pi_objRichTextBox)
        {
            return new RichTextBoxProxy(pi_objRichTextBox);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IRichTextBoxProxy] --

        public void Append(IBitMapImageProxy pi_objImage)
        {
            Paragraph p = new Paragraph();
            TextBlock objText = new TextBlock() { Text = "Text\r\n2nd row" };
            InlineUIContainer b1Image = pi_objImage.ToContainer();
            InlineUIContainer b2Text = new InlineUIContainer(objText);

            b1Image.BaselineAlignment = BaselineAlignment.Center;
            p.Inlines.Add(b1Image);
            p.Inlines.Add(b2Text);
            l_objRichTextBox.Document.Blocks.Add(p);
        }

        public IFlowDocumentProxy Document
        {
            get
            {
                return FlowDocumentProxy.Initial(l_objRichTextBox.Document);
            }
        }

        #endregion

    }

    public interface IRichTextBoxProxy
    {
        IFlowDocumentProxy Document { get; }        
        void Append(IBitMapImageProxy pi_objImage);
    }
}
