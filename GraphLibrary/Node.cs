using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
    public class Node
    {
        public readonly int NodeNumber;
        public List<Edge> Edges;

        public Node(int nodeNumber)
        {
            NodeNumber = nodeNumber;
        }

        public IEnumerable<Node> IncidentNodes => Edges.Select(edge => edge.AnotherNode(this));

        public static Edge Connect(Node node1, Node node2, Graph graph)
        {
            if (!graph.Nodes.Contains(node1) || !graph.Nodes.Contains(node2))
                throw new ArgumentException("Nodes don't belong to graph");
            var edge = new Edge(node1, node2);
            node1.Edges.Add(edge);
            node2.Edges.Add(edge);
            return edge;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Node))
                return false;
            var another = (Node) obj;
            return NodeNumber == another.NodeNumber;
        }

        public override int GetHashCode()
        {
            return NodeNumber;
        }
    }
}