using System.Globalization;
using System.Windows.Data;

namespace ExtendHealth.Ssc.Framework.Converters.NodeExpressions
{
    public class ConvertWithNodeFactory : IOperatorNodeFactory
    {
        public Node Create()
        {
            return new Node(x => ((IValueConverter) x.Right.Evaluate()).Convert(x.Left.Evaluate(), null, null, CultureInfo.CurrentCulture), NodeType.Operator, NodePriority.Convert);
        }
    }
}
