using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.Extensions
{
    public static class DependencyObjectExtensions
    {
        public static IEnumerable<DependencyObject> Descendants(this DependencyObject root)
        {
            if (root == null)
                yield break;
            yield return root;
            foreach (var child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
                foreach (var descendent in child.Descendants())
                    yield return descendent;
        }
    }
}
