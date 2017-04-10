using System.Collections.Generic;
using System.Linq;

namespace DFS
{
    public class Maze
    {
        private Cell[,] nodes;
        public int Width { get; }
        public int Height { get; }
        public Cell Start { get; set; }
        public Cell Finish { get; set; }

        public Maze(int rows, int columns)
        {
            nodes = new Cell[rows, columns];
            Width = columns;
            Height = rows;
        }

        public Cell this[int row, int column]
        {
            get => nodes[row - 1, column - 1];
            set => nodes[row - 1, column - 1] = value;
        }

        public List<Cell> FindPath()
        {
            var visited = new HashSet<Cell>();
            var open = new Stack<Cell>();
            var parents = new Dictionary<Cell, Cell>();
            open.Push(Start);
            while (open.Any())
            {
                var current = open.Pop();
                if (current.Equals(Finish))
                    return MakePath(parents);
                foreach (var cell in current.IncidentNodes.Where(cell => !visited.Contains(cell)))
                {
                    open.Push(cell);
                    parents[cell] = current;
                }
                visited.Add(current);
            }
            return null;
        }

        private List<Cell> MakePath(Dictionary<Cell, Cell> parents)
        {
            var path = new List<Cell> { Finish };
            var parent = parents[Finish];
            while (parent != null)
            {
                path.Add(parent);
                var result = parents.TryGetValue(parent, out parent);
                if (!result)
                    break;
            }
            path.Reverse();
            return path;
        }
    }
}
