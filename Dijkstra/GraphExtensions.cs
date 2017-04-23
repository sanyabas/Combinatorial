using System.Collections.Generic;
using System.Linq;
using GraphLibrary;

namespace Dijkstra
{
    public static class GraphExtensions
    {
        public static (List<Node>, int) FindDijkstraPath(this Graph graph, Node start, Node finish)
        {
            var visited = new HashSet<Node>();
            var parents = new Dictionary<Node, Node>();
            var distance = new Dictionary<Node, int>();
            foreach (var node in graph.Nodes)
                distance[node] = int.MaxValue;
            distance[start] = 0;
            foreach (var _ in graph.Nodes)
            {
                var minNode = graph.Nodes.Where(n => !visited.Contains(n)).MinElement(n => distance[n]);
                if (minNode == null)
                    continue;
                visited.Add(minNode);
                foreach (var edge in minNode.Edges)
                {
                    var anotherNode = edge.AnotherNode(minNode);
                    var currentWeight = distance[anotherNode];
                    var newWeight = distance[minNode] + edge.Weight;
                    if (newWeight < currentWeight)
                    {
                        distance[anotherNode] = newWeight;
                        parents[anotherNode] = minNode;
                    }
                }
            }
            return (BuildPath(start, finish, parents), distance[finish]);
        }

        private static List<Node> BuildPath(Node start, Node finish, Dictionary<Node, Node> parents)
        {
            var path = new List<Node> { finish };
            if (!parents.ContainsKey(finish))
                return null;
            var parent = parents[finish];
            while (parent != null)
            {
                path.Add(parent);
                var result = parents.TryGetValue(parent, out parent);
                if (!result)
                    break;
            }
            path.Reverse();
            if (path.Contains(finish) && path.Contains(start))
                return path;
            else
                return null;
        }
    }
}