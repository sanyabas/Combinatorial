using System.IO;
using System.Linq;
using GraphLibrary;

namespace Dijkstra
{
    public class ListParser : GraphParser
    {
        public ListParser(string fileName) : base(fileName)
        {
        }

        public override Graph ParseGraph()
        {
            var lines = File.ReadAllLines(fileName);
            var nodesCount = int.Parse(lines[0]);
            var graph = new Graph(nodesCount);
            for (var i = 1; i <= nodesCount; i++)
            {
                var splittedLine = lines[i].Split(' ').Select(int.Parse).ToArray();
                for (var j = 0; j < splittedLine.Length - 1; j += 2)
                {
                    var (neighbourCount, weight) = (splittedLine[j], splittedLine[j + 1]);
                    graph.Connect(graph[i], graph[neighbourCount], weight);
                }
            }
            var startNumber = int.Parse(lines[lines.Length - 2]);
            var finishNumber = int.Parse(lines[lines.Length - 1]);
            graph.Start = graph[startNumber];
            graph.Finish = graph[finishNumber];
            return graph;
        }
    }
}