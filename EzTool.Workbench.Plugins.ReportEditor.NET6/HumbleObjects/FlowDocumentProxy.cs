using EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions;

using System.Linq;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects
{
    public class FlowDocumentProxy :
      IFlowDocumentProxy
    {

        #region -- 變數宣告 ( Declarations ) --   

        private FlowDocument l_objFlowDocument;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public FlowDocumentProxy(FlowDocument pi_objFlowDocument)
        {
            this.l_objFlowDocument = pi_objFlowDocument;
        }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --
        #endregion

        #region -- 靜態方法 (Shared Method ) --
        public static IFlowDocumentProxy Initial(FlowDocument pi_objFlowDocument)
        {
            return new FlowDocumentProxy(pi_objFlowDocument);
        }
        #endregion

        #region -- 介面實做 ( Implements ) - [IFlowDocumentProxy] --

        public IBlockBundleProxy Blocks
        {
            get
            {
                return BlockBundleProxy.Initial(l_objFlowDocument.Blocks);
            }
        }
        public IParagraphProxyBundle Paragraphs
        {
            get
            {
                return ParagraphProxyBundle.Initial(l_objFlowDocument.Descendants().OfType<Paragraph>().ToList());
            }
        }

        #endregion

    }

    public interface IFlowDocumentProxy
    {
        IParagraphProxyBundle Paragraphs { get; }
        IBlockBundleProxy Blocks { get; }
    }
}
