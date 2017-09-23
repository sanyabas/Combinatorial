using System;
using System.Collections.Generic;
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
            var graph=new CoordinatesParser("in.txt").ParseGraph();
            Console.WriteLine("aaa");
        }
    }
}
