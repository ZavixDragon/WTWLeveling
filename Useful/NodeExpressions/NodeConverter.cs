using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace ExtendHealth.Ssc.Framework.Converters.NodeExpressions
{
    public class NodeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var closures = new Stack<Node>();
            var baseNode = new Node(x => x.Left.Evaluate(), NodeType.Value, NodePriority.Value);
            closures.Push(baseNode);
            foreach (var value in values)
            {
                var nodeFactory = value as IOperatorNodeFactory;
                if (nodeFactory != null)
                {
                    var operatorNode = nodeFactory.Create();
                    closures.Peek().AddNode(operatorNode);
                }
                else if (value is OpenClosure)
                {
                    var closureNode = new Node(x => x.Left.Evaluate(), NodeType.Value, NodePriority.Value);
                    closures.Peek().AddNode(closureNode);
                    closures.Push(closureNode);
                }
                else if (value is CloseClosure)
                {
                    closures.Pop();
                }
                else
                {
                    var valueNode = new Node(x => value, NodeType.Value, NodePriority.Value);
                    closures.Peek().AddNode(valueNode);
                }
            }
            return baseNode.Evaluate();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
