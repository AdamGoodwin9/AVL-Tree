namespace AVLBST
{
    public class AVLTree
    {
        internal TreeNode head;

        public int Size { get; private set; }

        public AVLTree()
        {
            head = null;
            Size = 0;
        }

        internal TreeNode Search(int key)
        {
            TreeNode temp = head;
            while (temp != null && temp.Key != key)
            {
                if (key < temp.Key)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return temp;
        }

        public void Insert(int key)
        {
            if (IsEmpty())
            {
                head = new TreeNode(key);
                Size++;
            }
            else
            {
                TreeNode temp = head;
                while (temp != null)
                {
                    if (key < temp.Key)
                    {
                        if (temp.Left == null)
                        {
                            temp.Left = new TreeNode(key, temp);
                            Size++;
                            break;
                        }
                        temp = temp.Left;
                    }
                    else
                    {
                        if (temp.Right == null)
                        {
                            temp.Right = new TreeNode(key, temp);
                            Size++;
                            break;
                        }
                        temp = temp.Right;
                    }
                }
                FixTree(temp);
            }
        }

        private void FixTree(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            int rightHeight = node.Right == null ? 0 : node.Right.Height;
            int leftHeight = node.Left == null ? 0 : node.Left.Height;

            node.Height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
            node.Balance = rightHeight - leftHeight;

            TreeNode next = node.Parent;

            if (node.Balance > 1)
            {
                if (node.Right?.Balance < 0)
                {
                    RotateRight(node.Right);
                }
                RotateLeft(node);
            }
            else if (node.Balance < -1)
            {
                if (node.Left?.Balance > 0)
                {
                    RotateLeft(node.Left);
                }
                RotateRight(node);
            }

            FixTree(next);

            rightHeight = node.Right == null ? 0 : node.Right.Height;
            leftHeight = node.Left == null ? 0 : node.Left.Height;

            node.Height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
            node.Balance = rightHeight - leftHeight;
        }

        private void RotateLeft(TreeNode node)
        {
            if (node?.Right == null)
            {
                return;
            }

            TreeNode parent = node.Parent;
            TreeNode right = node.Right;

            if (head == node)
            {
                head = node.Right;
            }
            else if (node.IsRightChild())
            {
                parent.Right = right;
            }
            else
            {
                parent.Left = right;
            }

            right.Parent = parent;
            node.Parent = right;
            node.Right = right.Left;
            right.Left = node;
            if (node.Right != null)
            {
                node.Right.Parent = node;
            }
        }

        private void RotateRight(TreeNode node)
        {
            if (node?.Left == null)
            {
                return;
            }

            TreeNode parent = node.Parent;
            TreeNode left = node.Left;

            if (head == node)
            {
                head = node.Left;
            }
            else if (node.IsRightChild())
            {
                node.Parent.Right = node.Left;
            }
            else
            {
                node.Parent.Left = node.Left;
            }

            left.Parent = parent;
            node.Parent = left;
            node.Left = left.Right;
            left.Right = node;
            if (node.Left != null)
            {
                node.Left.Parent = node;
            }
        }

        public bool Delete(int key)
        {
            return Delete(Search(key));
        }

        private bool Delete(TreeNode nodeD)
        {
            if (IsEmpty() || nodeD == null)
            {
                return false;
            }

            int nodeDChildCount = nodeD.ChildCount();

            if (nodeDChildCount == 2)
            {
                TreeNode temp = nodeD.Left;
                while (temp.Right != null)
                {
                    temp = temp.Right;
                }
                nodeD.Key = temp.Key;
                Delete(temp);
            }
            else
            {
                bool nodeDIsHead = nodeD == head;
                if (nodeDChildCount == 1)
                {
                    if (nodeD.Left != null)
                    {
                        if (nodeDIsHead)
                        {
                            head = head.Left;
                            head.Parent = null;
                        }
                        else
                        {
                            nodeD.MakeLeft();
                        }
                    }
                    else
                    {
                        if (nodeDIsHead)
                        {
                            head = head.Right;
                            head.Parent = null;
                        }
                        else
                        {
                            nodeD.MakeRight();
                        }
                    }
                }
                else
                {
                    if (nodeDIsHead)
                    {
                        head = null;
                    }
                    else
                    {
                        nodeD.Nullify();
                    }
                }
                Size--;
            }
            FixTree(Minimum());
            return true;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        internal TreeNode Minimum()
        {
            TreeNode temp = head;
            while (temp.Left != null)
            {
                temp = temp.Left;
            }
            return temp;
        }

        internal TreeNode Maximum()
        {
            TreeNode temp = head;
            while (temp.Right != null)
            {
                temp = temp.Right;
            }
            return temp;
        }

        public bool IsLeftChild(int key)
        {
            if (IsEmpty() || key == head.Key)
            {
                return false;
            }

            TreeNode temp = head;
            while (temp != null)
            {
                if (key < temp.Key)
                {
                    temp = temp.Left;
                    if (temp != null && temp.Key == key)
                    {
                        return true;
                    }
                }
                else
                {
                    temp = temp.Right;
                    if (temp != null && temp.Key == key)
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public bool IsRightChild(int key)
        {
            if (IsEmpty() || key == head.Key)
            {
                return false;
            }

            TreeNode temp = head;
            while (temp != null)
            {
                if (key < temp.Key)
                {
                    temp = temp.Left;
                    if (temp != null && temp.Key == key)
                    {
                        return false;
                    }
                }
                else
                {
                    temp = temp.Right;
                    if (temp != null && temp.Key == key)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {

            return base.ToString();
        }
    }
}