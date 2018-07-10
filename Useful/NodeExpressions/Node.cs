using System;

namespace ExtendHealth.Ssc.Framework.Converters.NodeExpressions
{
    public class Node
    {
        public static Node Empty = new Node(x => null, NodeType.None, NodePriority.Value);

        private readonly Func<object> _evaluate;

        public Node Left { get; set; } = Empty;
        public Node Right { get; set; } = Empty;
        public NodeType Type { get; }
        public NodePriority Priority { get; }

        public Node(Func<Node, object> evaluateNode, NodeType type, NodePriority priority)
        {
            _evaluate = () => evaluateNode(this);
            Type = type;
            Priority = priority;
        }

        public object Evaluate()
        {
            return _evaluate();
        }

        public void AddNode(Node node)
        {
            if (Left == Empty)
            {
                Left = node;
            }
            else if (node.Type == NodeType.Value)
            {
                if (Left.Type == NodeType.Operator && Left.CanAddValueNode())
                {
                    Left.AddNode(node);
                }
                else if (Right == Empty)
                {
                    Right = node;
                }
                else if (Right.Type == NodeType.Operator && Right.CanAddValueNode())
                {
                    Right.AddNode(node);
                }
            }
            else if (node.Type == NodeType.Operator)
            {
                if (Right != Empty)
                {
                    if (node.Priority >= Right.Priority)
                    {
                        node.AddNode(Right);
                        Right = node;
                    }
                    else
                    {
                        Right.AddNode(node);
                    }
                }
                else if (Left != Empty)
                {
                    if (node.Priority >= Left.Priority)
                    {
                        node.AddNode(Left);
                        Left = node;
                    }
                    else
                    {
                        Left.AddNode(node);
                    }
                }
            }
        }

        private bool CanAddValueNode()
        {
            return Left.Type == NodeType.None
                   || Right.Type == NodeType.None
                   || (Left.Type == NodeType.Operator && Left.CanAddValueNode())
                   || (Right.Type == NodeType.Operator && Right.CanAddValueNode());
        }
    }
}
