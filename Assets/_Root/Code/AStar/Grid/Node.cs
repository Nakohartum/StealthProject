namespace _Root.Code.AStar.Grid
{
    public class Node
    {
        public Node(int x, int y, bool isWalkable)
        {
            X = x;
            Y = y;
            IsWalkable = isWalkable;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Node Parent { get; set; }
        public bool IsWalkable { get; set; }
        public int GCost { get; set; }
        public int HCost { get; set; }

        public int FCost => GCost + HCost;

    }
}