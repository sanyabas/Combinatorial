using System;

namespace GraphLibrary
{
    public class Edge
    {
        public readonly Node First;
        public readonly Node Second;

        public Edge(Node first, Node second)
        {
            First = first;
            Second = second;
        }

        public bool IsIncident(Node node)
        {
            return First.Equals(node) || Second.Equals(node);
        }

        public Node AnotherNode(Node node)
        {
            if (!IsIncident(node))
                throw new ArgumentException("Node is not incident");
            return node.Equals(First) ? Second : First;
        }

        public override string ToString()
        {
            return $"Edge {First}<->{Second}";
        }
    }
}