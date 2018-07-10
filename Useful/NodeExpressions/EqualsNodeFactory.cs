namespace ExtendHealth.Ssc.Framework.Converters.NodeExpressions
{
    public class EqualsNodeFactory : IOperatorNodeFactory
    {
        public Node Create()
        {
            return new Node(x => x.Left.Evaluate().Equals(x.Right.Evaluate()), NodeType.Operator, NodePriority.Equals);
        }
    }
}
