using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BiggestMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph=new BigraphParser("in.txt").ParseGraph();
            var matching = graph.GetBiggestMatching();
            var result = new List<int>();
            foreach (var xNode in graph.XPart)
            {
                var darkEdge = matching.FirstOrDefault(edge => edge.IsIncident(xNode));
                if (darkEdge==null)
                    result.Add(0);
                else
                    result.Add(darkEdge.AnotherNode(xNode).NodeNumber-graph.XCount);
            }
            File.WriteAllText("out.txt", string.Join(" ", result));
        }
    }
}
