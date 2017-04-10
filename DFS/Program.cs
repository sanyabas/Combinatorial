using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new MazeParser("in.txt");
            var maze = parser.ParseGraph();
            var path = maze.FindPath();
            var result = new List<string>();
            if (path == null)
                result.Add("N");
            else
            {
                result.Add("Y");
                result.AddRange(path.Select(cell => $"{cell.Row} {cell.Column}"));
            }
            File.WriteAllLines("out.txt", result);
        }
    }
}
