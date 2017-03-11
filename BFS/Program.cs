using System.IO;
using GraphLibrary;
using System.Linq;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new GraphParser(@"in.txt");
            var graph = parser.ParseGraph();
            var result = graph.FindCycles();
            var state = result == null ? "A" : "N";
            var cycle = string.Join(" ", result.OrderBy(n => n.NodeNumber).Select(n=>n.NodeNumber));
            File.WriteAllLines(@"out.txt", new[] { state, cycle });
        }
    }
}
