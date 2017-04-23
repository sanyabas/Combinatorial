using System.IO;
using System.Linq;

namespace GraphLibrary
{
    public class GraphParser
    {
        protected readonly string fileName;

        public GraphParser(string fileName)
        {
            this.fileName = fileName;
        }

        public virtual Graph ParseGraph()
        {
            var lines = File.ReadAllLines(fileName);
            var nodesCount = int.Parse(lines[0]);
            var graph = new Graph(nodesCount);
            for (var i = 1; i < lines.Length; i++)
            {
                var incidents = lines[i].Split(' ').Select(int.Parse).ToArray();
                for (var j = i - 1; j < incidents.Length; j++)
                    if (incidents[j] == 1)
                        graph.Connect(graph[i], graph[j + 1]);
            }
            return graph;
        }
    }
}