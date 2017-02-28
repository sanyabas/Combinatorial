using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser=new GraphParser(@"in.txt");
            var graph = parser.ParseGraph();
        }
    }
}
