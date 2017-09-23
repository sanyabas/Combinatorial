using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace MinTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new CoordinatesParser<Point>("in.txt").ParseGraph();
            var tree = graph.GetMinTree();
            File.WriteAllText("out.txt", PrepareOutput(graph, tree));
        }

        static string PrepareOutput(Graph graph, HashSet<Edge> tree)
        {
            var weight = tree.Sum(edge => edge.Weight);
            var output = "";
            foreach (var node in graph.Nodes)
            {
                var incidents = tree.Where(edge => edge.IsIncident(node)).Select(edge => edge.AnotherNode(node).NodeNumber).OrderBy(n => n);
                output += string.Join(" ", incidents);
                output += " 0\n";
            }
            output += weight;
            return output;
        }
    }
}
