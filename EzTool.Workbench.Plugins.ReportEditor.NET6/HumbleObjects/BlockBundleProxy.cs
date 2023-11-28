using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects
{
    public class BlockBundleProxy :
        IBlockBundleProxy
    {
        #region -- 變數宣告 ( Declarations ) --   

        private BlockCollection l_objBlocks;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public BlockBundleProxy(BlockCollection pi_objBlocks)
        {
            this.l_objBlocks = pi_objBlocks;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IBlockBundleProxy Initial(BlockCollection pi_objBlocks)
        {
            return new BlockBundleProxy(pi_objBlocks);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IBlockBundleProxy] --

        public IBlockBundleProxy Append(UIElement pi_objTextBlock)
        {
            var objContainer = new InlineUIContainer(pi_objTextBlock);
            var objParagraph = new Paragraph();

            objParagraph.Inlines.Add(objContainer);
            l_objBlocks.Add(objParagraph);
            return this;
        }

        public IBlockBundleProxy Append(string pi_sText)
        {
            var objParagraph = new Paragraph();

            objParagraph.Inlines.Add(pi_sText);
            l_objBlocks.Add(objParagraph);
            return this;
        }

        #endregion
    }

    public interface IBlockBundleProxy
    {
        IBlockBundleProxy Append(UIElement pi_objTextBlock);
        IBlockBundleProxy Append(string pi_sText);
    }
}
