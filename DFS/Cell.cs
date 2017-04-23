using System.Collections.Generic;
using System.Linq;
using GraphLibrary;

namespace DFS
{
    public class Cell : Node
    {
        public int Row { get; }
        public int Column { get; }
        private Maze maze;
        public Cell(int row, int column, Maze maze) : base(row * maze.Width + column)
        {
            this.Row = row;
            this.Column = column;
            this.maze = maze;
        }

        public new IEnumerable<Cell> IncidentNodes
        {
            get
            {
                var cells = new[]
                {
                    (Column!=1)?maze[Row, Column - 1]:null,
                    (Column!=maze.Width) ? maze[Row, Column + 1]: null,
                    (Row!=1) ? maze[Row - 1, Column] : null,
                    (Row != maze.Height) ? maze[Row + 1, Column] : null
                };
                cells=cells.Reverse().ToArray();
                foreach (var cell in cells)
                    if (cell != null)
                        yield return cell;

            }
        }

        public override string ToString()
        {
            return $"Node {Row}:{Column}";
        }
    }
}
