using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;

using static HarmonyLib.Code;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects
{
    public class ParagraphProxyBundle :
       IParagraphProxyBundle
    {
        #region -- 變數宣告 ( Declarations ) --   

        private List<Paragraph> l_objParagraphs;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public ParagraphProxyBundle(List<Paragraph> pi_objParagraphs)
        {
            this.l_objParagraphs = pi_objParagraphs;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IParagraphProxyBundle Initial(List<Paragraph> pi_objParagraphs)
        {
            return new ParagraphProxyBundle(pi_objParagraphs);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IParagraphProxyBundle] --
       
        public IParagraphProxyBundle Append(TextBlock pi_objTextBlock)
        {
            var objParagraph = new Paragraph();
            var objContainer = new InlineUIContainer(pi_objTextBlock);

            objParagraph.Inlines.Add(objContainer);
            l_objParagraphs.Add(objParagraph);
            return this;
        }

        public string AllText
        {
            get
            {
                var objStringBuilder = new StringBuilder();

                foreach (var paragraph in l_objParagraphs)
                {
                    objStringBuilder.AppendLine(new TextRange(paragraph.ContentStart, paragraph.ContentEnd).Text);
                }
                return objStringBuilder.ToString();
            }
        }

        #endregion

    }

    public interface IParagraphProxyBundle
    {
        string AllText { get; }
        IParagraphProxyBundle Append(TextBlock pi_objTextBlock);        
    }
}
