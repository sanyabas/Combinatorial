using System;
using System.IO;
using System.Linq;
using GraphLibrary;

namespace MinTree
{
    public class CoordinatesParser : GraphParser
    {
        public CoordinatesParser(string fileName) : base(fileName)
        {

        }

        public override Graph ParseGraph()
        {
            Func<Point, Point, int> metrics = (p1, p2) => Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
            var lines = File.ReadAllLines(fileName);
            var nodesCount = int.Parse(lines[0]);
            var graph = new Graph<Point>(nodesCount);
            for (var i = 1; i <= nodesCount; i++)
            {
                var splittedLine = lines[i].Split(' ').Select(int.Parse).ToArray();
                var cur = graph[i];
                cur.Value = new Point(splittedLine[0], splittedLine[1]);
            }
            for (var i = 1; i <= nodesCount - 1; i++)
            {
                for (var j = i+1; j <= nodesCount; j++)
                {
                    var first = graph[i];
                    var second = graph[j];
                    graph.Connect(first, second, metrics(first.Value, second.Value));
                    graph.Connect(second, first, metrics(first.Value, second.Value));
                }
            }
            return graph;
        }
    }
}