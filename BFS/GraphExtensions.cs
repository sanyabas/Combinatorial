using System.Collections.Generic;
using System.Linq;
using GraphLibrary;

namespace BFS
{
    public static class GraphExtensions
    {
        public static bool ContainsCycles(this Graph graph)
        {
            return graph.Nodes.Any(graph.ContainsCycleFromNode);
        }

        private static bool ContainsCycleFromNode(this Graph graph, Node start)
        {
            var open = new Queue<Node>();
            var visited = new HashSet<Node>();
            open.Enqueue(start);
            while (open.Any())
            {
                var current = open.Dequeue();
                visited.Add(current);
                foreach (var neighbour in current.IncidentNodes.Where(node => !visited.Contains(node)))
                {
                    if (open.Contains(neighbour))
                        return true;
                    open.Enqueue(neighbour);
                }
            }
            return false;
        }
    }
}