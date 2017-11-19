using System.Collections.Generic;
using GraphLibrary;

namespace BiggestMatching
{
    public class Bigraph : Graph
    {
        private List<Node> xPart;
        private List<Node> yPart;
        public HashSet<Node> DarkNodes=new HashSet<Node>();
        public int XCount => xPart.Count;
        public int YCount => yPart.Count;

        public Bigraph(int nodesCount) : base(nodesCount)
        {
        }

        public Bigraph(int xCount, int yCount) : base(xCount + yCount)
        {
            xPart = new List<Node>(xCount);
            yPart = new List<Node>(yCount);
            for (var i = 0; i < xCount; i++)
                xPart.Add(new Node(i + 1));
            for (var i = 0; i < yCount; i++)
                yPart.Add(new Node(xCount + i + 1));
        }

        public Edge Connect(int number1, int number2, int weight = 0)
        {
            return Connect(XNode(number1), YNode(number2), weight);
        }


        public IEnumerable<Node> XPart => xPart;
        public IEnumerable<Node> YPart => yPart;

        public Node XNode(int number) => xPart[number - 1];
        public Node YNode(int number) => yPart[number - 1];
    }
}