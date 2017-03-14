using System.Collections.Generic;
using System.Linq;
using GraphLibrary;

namespace BFS
{
    public static class GraphExtensions
    {
        public static HashSet<Node> FindCycles(this Graph graph)
        {
            foreach (var node in graph.Nodes)
            {
                var cycle = graph.FindCycleFromNode(node);
                if (cycle != null)
                    return cycle;
            }
            return null;
        }

        private static HashSet<Node> FindCycleFromNode(this Graph graph, Node start)
        {
            var open = new Queue<Node>();
            var visited = new HashSet<Node>();
            var parents = new Dictionary<Node, Node>();
            open.Enqueue(start);
            while (open.Any())
            {
                var current = open.Dequeue();
                visited.Add(current);
                foreach (var neighbour in current.IncidentNodes.Where(node => !visited.Contains(node)))
                {
                    if (open.Contains(neighbour))
                        return graph.GetCycle(neighbour, current, parents);
                    parents[neighbour] = current;
                    open.Enqueue(neighbour);
                }
            }
            return null;
        }

        private static HashSet<Node> GetCycle(this Graph graph, Node start, Node secondNode, Dictionary<Node, Node> parents)
        {
            var firstPath = new List<Node>();
            var secondPath = new List<Node>();
            firstPath.Add(start);
            secondPath.Add(secondNode);
            while (!firstPath.Last().Equals(secondPath.Last()))
            {
                if (parents.ContainsKey(start))
                    start = parents[start];
                if (parents.ContainsKey(secondNode))
                    secondNode = parents[secondNode];
                firstPath.Add(start);
                secondPath.Add(secondNode);
            }
            return new HashSet<Node>(firstPath.Union(secondPath));
        }
    }
}