using System.IO;
using GraphLibrary;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new GraphParser(@"in.txt");
            var graph = parser.ParseGraph();
            var result = graph.ContainsCycles() ? "N" : "A";
            File.WriteAllText(@"out.txt", result);
        }
    }
}
