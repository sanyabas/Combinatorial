using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new ListParser("in.txt").ParseGraph();
            var (path, length) = graph.FindDijkstraPath(graph.Start, graph.Finish);
            Console.WriteLine("calculated");
            var result = new List<string>();
            if (path == null)
                result.Add("N");
            else
            {
                result.Add("Y");
                result.Add(string.Join(" ",path.Select(node => node.NodeNumber)));
                result.Add(length.ToString());
            }
            File.WriteAllLines("out.txt", result);
        }
    }
}