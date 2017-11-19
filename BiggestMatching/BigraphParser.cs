using System.IO;
using System.Linq;
using GraphLibrary;

namespace BiggestMatching
{
    public class BigraphParser : GraphParser
    {
        public BigraphParser(string fileName) : base(fileName)
        {
        }

        public new Bigraph ParseGraph()
        {
            var input = File.ReadAllLines(fileName);
            var counts = input[0].Split().Select(int.Parse).ToArray();
            var k = counts[0];
            var l = counts[1];
            var graph = new Bigraph(k, l);
            for (var i = 1; i < input.Length; i++)
            {
                var incidents = input[i].Split().Select(int.Parse).ToArray();
                for (var j = 0; j < incidents.Length - 1; j++)
                    graph.Connect(i, incidents[j]);
            }
            return graph;
        }
    }
}