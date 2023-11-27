using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects
{
    public class ParagraphProxy :
       IParagraphProxy
    {
        #region -- 變數宣告 ( Declarations ) --   

        private Paragraph l_objParagraph;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public ParagraphProxy(Paragraph pi_objParagraph)
        {
            this.l_objParagraph = pi_objParagraph;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IParagraphProxy Initial(Paragraph pi_objParagraph)
        {
            return new ParagraphProxy(pi_objParagraph);
        }

        #endregion              
    }

    public interface IParagraphProxy
    {
    }
}
