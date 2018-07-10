namespace ExtendHealth.Ssc.Framework.Converters.NodeExpressions
{
    public class AndNodeFactory : IOperatorNodeFactory
    {
        public Node Create()
        {
            return new Node(x => (bool)x.Left.Evaluate() && (bool)x.Right.Evaluate(), NodeType.Operator, NodePriority.AndOr);
        }
    }
}
