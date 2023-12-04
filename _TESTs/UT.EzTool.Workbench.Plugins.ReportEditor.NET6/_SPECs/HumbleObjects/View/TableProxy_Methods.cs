using EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects.View;
using EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace UT.EzTool.Workbench.Plugins.ReportEditor.NET6._SPECs.HumbleObjects.View
{
    [TestClass]
    public class TableProxy_Methods
    {
        [TestMethod]
        public void S01()
        {
            //Arrange
            var objCell = new TableCell()
            {
                Padding = new System.Windows.Thickness(1, 2, 3, 4),
                BorderBrush = new SolidColorBrush(Color.FromRgb(125, 125, 125))
            };

            //Action
            var objProxy = TableCellProxy.Initial(objCell);
            var objActualPadding = objProxy.Padding;
            var objActualBordColor = objProxy.BordColor;

            //Assert
            Assert.IsNotNull(objActualPadding);
            Assert.IsNotNull(objActualBordColor);
            Assert.AreEqual(1, objActualPadding.Left);
            Assert.AreEqual(2, objActualPadding.Top);
            Assert.AreEqual(3, objActualPadding.Right);
            Assert.AreEqual(4, objActualPadding.Bottom);
        }
    }
}
