namespace ExtendHealth.Ssc.Framework.Converters.NodeExpressions
{
    public class NotEqualsNodeFactory : IOperatorNodeFactory
    {
        public Node Create()
        {
            return new Node(x => !x.Left.Evaluate().Equals(x.Right.Evaluate()), NodeType.Operator, NodePriority.Equals);
        }
    }
}
