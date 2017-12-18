using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra;
using GraphLibrary;

namespace PayToExit
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new RoomParser("in.txt");
            var graph = parser.ParseGraph();
            var dijkstra = graph.FindDijkstraPath(graph.Start, graph.Finish);
            var result = PrepareOutput(dijkstra, parser.CostLimit, parser.EdgeNumbers);
            File.WriteAllText("out.txt", result);
        }

        static string PrepareOutput((List<Node>, int) dijkstraResult, int costLimit, Dictionary<Edge, int> edgeNumbers)
        {
            var (path, cost) = dijkstraResult;
            var result = new List<string>();
            var doors = new List<string>();
            for (var i = 0; i < path.Count - 1; i++)
            {
                var i1 = i;
                doors.Add(edgeNumbers[
                    path[i].Edges.First(edge => edge.AnotherNode(path[i1]).Equals(path[i1 + 1]))].ToString());
            }
            if (cost > costLimit)
            {
                result.Add("N");
            }
            else
            {
                result.Add("Y");
                result.Add(cost.ToString());
                result.Add(string.Join(" ", doors));
            }
            return string.Join("\n", result);
        }
    }
}
