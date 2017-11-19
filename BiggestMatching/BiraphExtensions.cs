using System.Collections.Generic;
using System.Linq;
using GraphLibrary;

namespace BiggestMatching
{
    public static class BiraphExtensions
    {
        public static HashSet<Edge> GetBiggestMatching(this Bigraph graph)
        {
            var matching = new HashSet<Edge>();
            while (true)
            {
                var chain = graph.GetInterchangingChain(matching);
                if (chain == null)
                    return matching;
                var chainSet = GetEdgesFromChain(chain);
                matching.SymmetricExceptWith(chainSet);
                graph.DarkNodes.Add(chain[0]);
                graph.DarkNodes.Add(chain[chain.Count - 1]);
            }
        }

        private static HashSet<Edge> GetEdgesFromChain(List<Node> chain)
        {
            var result=new HashSet<Edge>();
            for (var i = 0; i < chain.Count - 1; i++)
                result.Add(chain[i].GetEdgeToNode(chain[i + 1]));
            return result;
        }

        private static List<Node> GetInterchangingChain(this Bigraph graph, HashSet<Edge> matching)
        {
            foreach (var xNode in graph.XPart.Where(x => !graph.DarkNodes.Contains(x)))
            {
                var chain = graph.GetChainFromNode(xNode, matching);
                if (chain != null)
                    return chain;
            }
            return null;
        }

        private static List<Node> GetChainFromNode(this Bigraph graph, Node start, HashSet<Edge> matching)
        {
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();
            var previous = new Dictionary<Node, Node>();
            visited.Add(start);
            foreach (var yNode in start.IncidentNodes)
            {
                previous[yNode] = start;
                if (!graph.DarkNodes.Contains(yNode))
                    return graph.BuildChain(start, yNode, previous);
                stack.Push(yNode);
            }
            while (stack.Any())
            {
                var current = stack.Pop();
                if (graph.YPart.Contains(current))
                {
                    var xNodes = current.Edges
                        .Where(edge => matching.Contains(edge))
                        .Select(edge => edge.AnotherNode(current));
                    foreach (var xNode in xNodes)
                    {
                        stack.Push(xNode);
                        previous[xNode] = current;
                    }
                }
                else
                {
                    var yNodes = current.Edges
                        .Where(edge => !matching.Contains(edge))
                        .Select(edge => edge.AnotherNode(current));
                    foreach (var yNode in yNodes)
                    {
                        previous[yNode] = current;
                        if (!graph.DarkNodes.Contains(yNode))
                            return graph.BuildChain(start, yNode, previous);
                        stack.Push(yNode);
                    }
                }
            }
            return null;

        }

        private static List<Node> BuildChain(this Bigraph graph, Node start, Node end, Dictionary<Node, Node> previous)
        {
            var chain = new List<Node> { end };
            previous.TryGetValue(end, out var parent);
            while (parent != null)
            {
                chain.Add(parent);
                previous.TryGetValue(parent, out parent);
            }
            //chain.Add(start);
            chain.Reverse();
            return chain;
        }
    }
}