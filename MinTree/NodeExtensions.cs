using System.Linq;
using GraphLibrary;

namespace MinTree
{
    public static class NodeExtensions
    {
        public static int GetDistanceToNode(this Node cur, Node node)
        {
            return cur.GetEdgeToNode(node).Weight;
        }

        public static Edge GetEdgeToNode(this Node cur, Node node)
        {
            return cur.Edges.Single(x => x.AnotherNode(cur).Equals(node));
        }
    }
}