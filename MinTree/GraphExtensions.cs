using System;
using System.Collections.Generic;
using GraphLibrary;

namespace MinTree
{
    static class GraphExtensions
    {
        public static HashSet<Edge> GetMinTree<T>(this Graph<T> graph) where T : IComparable<T>
        {
            var tree = new HashSet<Edge>();
            var includedNodes = new HashSet<Node<T>>();
            var restNodes = new HashSet<Node<T>>();
            var closestNodes = new Dictionary<Node<T>, Node<T>>();
            var distances = new Dictionary<Node<T>, int>();
            Func<IEnumerable<Node<T>>, Node<T>> getClosestNode = (nodes) =>
            {
                Node<T> closest = null;
                var leastDistance = int.MaxValue;
                foreach (var node in nodes)
                {
                    if (distances[node] < leastDistance)
                    {
                        leastDistance = distances[node];
                        closest = node;
                    }
                }
                if (closest == null)
                    throw new ArgumentNullException();
                return closest;
            };
            includedNodes.Add(graph[1]);
            foreach (var node in graph.Nodes)
            {
                restNodes.Add(node);
            }
            restNodes.Remove(graph[1]);
            foreach (var node in restNodes)
            {
                closestNodes[node] = graph[1];
                distances[node] = node.GetDistanceToNode(graph[1]);
            }
            while (includedNodes.Count < graph.NodesCount)
            {
                var currentClosest = getClosestNode(restNodes);
                tree.Add(currentClosest.GetEdgeToNode(closestNodes[currentClosest]));
                includedNodes.Add(currentClosest);
                restNodes.Remove(currentClosest);
                foreach (var node in restNodes)
                {
                    var distanceToCur = node.GetDistanceToNode(currentClosest);
                    if (distanceToCur < distances[node])
                    {
                        closestNodes[node] = currentClosest;
                        distances[node] = distanceToCur;
                    }
                }
            }
            return tree;
        }
    }
}