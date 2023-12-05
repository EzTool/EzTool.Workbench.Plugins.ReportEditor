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

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Views.SheetEditor
{
    /// <summary>
    /// Interaction logic for SheetEditorView.xaml
    /// </summary>
    public partial class SheetEditorView : UserControl
    {
        public SheetEditorView()
        {
            InitializeComponent();
        }

        private void Run_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
