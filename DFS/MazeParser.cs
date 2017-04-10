using System.IO;
using System.Linq;

namespace DFS
{
    public class MazeParser
    {
        private readonly string fileName;

        public MazeParser(string fileName)
        {
            this.fileName = fileName;
        }

        public Maze ParseGraph()
        {
            var lines = File.ReadAllLines(fileName);
            var rowsCount = int.Parse(lines[0]);
            var columnsCount = int.Parse(lines[1]);
            var maze = new Maze(rowsCount, columnsCount);
            lines = lines.Skip(2).ToArray();
            for (var i = 0; i < rowsCount; i++)
            {
                var line = lines[i].Split(' ');
                for (var j = 0; j < columnsCount; j++)
                    if (line[j] == "0")
                        maze[i + 1, j + 1] = new Cell(i + 1, j + 1, maze);
            }
            var startLine = lines[lines.Length - 2].Split(' ').Select(int.Parse).ToArray();
            var start = new Cell(startLine[0], startLine[1], maze);
            var endLine = lines[lines.Length - 1].Split(' ').Select(int.Parse).ToArray();
            var finish = new Cell(endLine[0], endLine[1], maze);
            maze.Start = start;
            maze.Finish = finish;
            return maze;

        }


    }
}
