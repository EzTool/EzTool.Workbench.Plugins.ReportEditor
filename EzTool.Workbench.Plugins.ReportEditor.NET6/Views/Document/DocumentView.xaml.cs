using EzTool.SDK.WPF.Nerve.MVVM.AbstractObjects;
using EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.Document
{
    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class DocumentView : UserControl
    {
        private List<ParagraphContext> l_objParagraphs = new List<ParagraphContext>();
        public DocumentView()
        {
            InitializeComponent();
        }

        private void InsertTextButton_Click(object sender, RoutedEventArgs e)
        {
            var objTextBlock = new TextBlock();
            var objContext = new ParagraphContext();
            var objBinding = new Binding()
            {
                Path = new PropertyPath(nameof(ParagraphContext.ShowText)),
                Source = objContext
            };

            l_objParagraphs.Add(objContext);
            BindingOperations.SetBinding(objTextBlock, TextBlock.TextProperty, objBinding);
            RichTextBoxProxy.Initial(MainBox).Document.Blocks.Append(objTextBlock);
        }

        private void UpdateTextButton_Click(object sender, RoutedEventArgs e)
        {
            l_objParagraphs.ForEach((objP) =>
            {
                objP.ShowText = DateTime.Now.ToString("G");
            });
        }
    }

    public class ParagraphContext :
        BaseViewContext
    {
        public string ShowText { get; set; } = "Show Text";
    }
}
