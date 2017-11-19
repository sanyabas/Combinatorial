using System;

namespace GraphLibrary
{
    public class Edge
    {
        public readonly Node First;
        public readonly Node Second;
        public readonly int Weight;

        public Edge(Node first, Node second,int weight=0)
        {
            First = first;
            Second = second;
            Weight = weight;
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
            return $"Edge {First}->{Second}";
        }

        protected bool Equals(Edge other)
        {
            return (Equals(First, other.First) && Equals(Second, other.Second))||
                Equals(First,other.Second) && Equals(Second, other.First);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Edge) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((First != null ? First.GetHashCode() : 0) * 397) ^ (Second != null ? Second.GetHashCode() : 0);
            }
        }
    }
}