using System.Collections.Generic;

namespace GraphLibrary
{
    public class Graph
    {
        private List<Node> nodes;

        public Graph(int nodesCount)
        {
            nodes = new List<Node>();
            for (var i = 0; i < nodesCount; i++)
                nodes.Add(new Node(i + 1));
        }

        public IEnumerable<Node> Nodes => nodes;

        public Node this[int number] => nodes[number - 1];

        public Edge Connect(Node node1, Node node2)
        {
            return Node.Connect(node1, node2, this);
        }
    }
}
