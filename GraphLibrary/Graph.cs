using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
    public class Graph
    {
        private List<Node> nodes;
        public Node Start { get; set; }
        public Node Finish { get; set; }
        public int NodesCount { get; }

        public Graph(int nodesCount)
        {
            nodes = new List<Node>();
            for (var i = 0; i < nodesCount; i++)
                nodes.Add(new Node(i + 1));
            NodesCount = nodesCount;
        }

        public IEnumerable<Node> Nodes => nodes;

        public Node this[int number] => nodes[number - 1];

        public Edge Connect(Node node1, Node node2, int weight = 0)
        {
            return Node.Connect(node1, node2, weight, this);
        }
    }

    public class Graph<T> : Graph where T:IComparable<T>
    {
        private List<Node<T>> nodes;
        public Graph(int nodesCount) : base(nodesCount)
        {
            nodes=new List<Node<T>>();
            for (var i=0;i<nodesCount;i++)
                nodes.Add(new Node<T>(i+1));
        }

        public new IEnumerable<Node<T>> Nodes => nodes;

        public Node this[T value] => nodes.Single(x => x.Value.Equals(value));

        public new Node<T> this[int number] => nodes[number - 1];
    }
}
