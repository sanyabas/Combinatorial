using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphLibrary;

namespace PayToExit
{
    public class RoomParser : GraphParser
    {
        public int CostLimit { get; set; }
        public Dictionary<Edge, int> EdgeNumbers { get; }
        public RoomParser(string fileName) : base(fileName)
        {
            EdgeNumbers= new Dictionary<Edge, int>();
        }

        public override Graph ParseGraph()
        {
            var lines = File.ReadAllLines("in.txt").Select(line => line.Split().Select(int.Parse).ToArray()).ToArray();
            var counts = lines[0];
            var n = counts[0];
            var m = counts[1];
            var start = counts[2];
            var sum = counts[3];
            CostLimit = sum;
            var graph = new Graph(n + 1);
            var costs = lines.Skip(n + 1).SelectMany(x => x).ToArray();
            var addedRooms = new HashSet<int>();
            for (var roomNumber = 1; roomNumber <= n; roomNumber++)
            {
                var numbers = lines[roomNumber];
                for (var doorIndex = 1; doorIndex < numbers.Length; doorIndex++)
                {
                    if (addedRooms.Contains(numbers[doorIndex]))
                        continue;
                    var added = false;
                    for (var secondRoom = roomNumber + 1; secondRoom <= n; secondRoom++)
                    {
                        if (lines[secondRoom].Skip(1).Contains(numbers[doorIndex]))
                        {
                            var edge=graph.Connect(graph[roomNumber], graph[secondRoom], costs[numbers[doorIndex] - 1]);
                            addedRooms.Add(numbers[doorIndex]);
                            EdgeNumbers[edge] = numbers[doorIndex];
                            added = true;
                        }
                    }
                    if (!added)
                    {
                        var edge=  graph.Connect(graph[roomNumber], graph[n + 1], costs[numbers[doorIndex] - 1]);
                        EdgeNumbers[edge] = numbers[doorIndex];
                    }
                }
            }
            //foreach (var exit in lines[n].Where(room => !addedRooms.Contains(room)))
            //{
            //    graph.Connect(graph[n], graph[n + 1], costs[exit - 1]);
            //}
            
            graph.Start = graph[start];
            graph.Finish = graph[n + 1];
            return graph;
        }
    }
}