namespace AVLBST
{
    internal class TreeNode
    {
        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode Parent { get; set; }

        public int Balance { get; set; }

        public int Height { get; set; }

        public int Key { get; set; }

        public TreeNode(int key) : this(key, null) { }

        public TreeNode(int key, TreeNode parent)
        {
            Key = key;
            Left = null;
            Right = null;
            Parent = parent;
            Height = 1;
            Balance = 0;
        }

        public bool IsRightChild()
        {
            return this == Parent?.Right;
        }

        public void Nullify()
        {
            if (Parent == null)
            {
                return;
            }

            if (IsRightChild())
            {
                Parent.Right = null;
            }
            else
            {
                Parent.Left = null;
            }
        }

        public void MakeLeft()
        {
            if (Parent == null)
            {
                return;
            }

            Left.Parent = Parent;

            if (IsRightChild())
            {
                Parent.Right = Left;
            }
            else
            {
                Parent.Left = Left;
            }
        }

        public void MakeRight()
        {
            if (Parent == null)
            {
                return;
            }

            Right.Parent = Parent;

            if (IsRightChild())
            {
                Parent.Right = Right;
            }
            else
            {
                Parent.Left = Right;
            }
        }

        public int ChildCount()
        {
            int childCount = 0;
            if (Left != null)
            {
                childCount += 1;
            }
            if (Right != null)
            {
                childCount += 1;
            }
            return childCount;
        }

        public override string ToString() => $"TreeNode: Key: {Key}, ChildCount: {ChildCount()}, Height: {Height}, Balance: {Balance}";
    }
}
