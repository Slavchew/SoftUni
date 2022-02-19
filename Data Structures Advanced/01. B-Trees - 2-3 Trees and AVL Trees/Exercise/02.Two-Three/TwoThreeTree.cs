namespace _02.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T key)
        {
            root = Insert(root, key);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T key)
        {
            if (node == null)
            {
                return new TreeNode<T>(key);
            }

            TreeNode<T> returnNode;

            if (node.IsLeaf())
            {
                return Merge(node, new TreeNode<T>(key));
            }

            if (key.CompareTo(node.LeftKey) < 0)
            {
                returnNode = Insert(node.LeftChild, key);
                if (returnNode == node.LeftChild)
                {
                    return node;
                }
                else
                {
                    return Merge(node, returnNode);
                }
            }
            else if (node.IsTwoNode() || key.CompareTo(node.RightKey) < 0)
            {
                returnNode = Insert(node.MiddleChild, key);
                if (returnNode == node.MiddleChild)
                {
                    return node;
                }
                else
                {
                    return Merge(node, returnNode);
                }
            }
            else
            {
                returnNode = Insert(node.RightChild, key);
                if (returnNode == node.RightChild)
                {
                    return node;
                }
                else
                {
                    return Merge(node, returnNode);
                }
            }
        }

        private TreeNode<T> Merge(TreeNode<T> current, TreeNode<T> node)
        {
            if (current.RightKey == null)
            {
                if (current.LeftKey.CompareTo(node.LeftKey) < 0)
                {
                    current.RightKey = node.LeftKey;
                    current.MiddleChild = node.LeftChild;
                    current.RightChild = node.MiddleChild;
                }
                else
                {
                    current.RightKey = current.LeftKey;
                    current.RightChild = current.MiddleChild;
                    current.LeftKey = node.LeftKey;
                    current.MiddleChild = node.MiddleChild;
                    current.LeftChild = node.LeftChild; // Fix
                }

                return current;
            }
            else if (current.LeftKey.CompareTo(node.LeftKey) >= 0)
            {
                TreeNode<T> mergeNode = new TreeNode<T>(current.LeftKey)
                {
                    LeftChild = node,
                    MiddleChild = current
                };
                node.LeftChild = current.LeftChild;
                current.LeftChild = current.MiddleChild;
                current.MiddleChild = current.RightChild;
                current.RightChild = null;
                current.LeftKey = current.RightKey;
                current.RightKey = default(T);

                return mergeNode;
            }
            else if (current.RightKey.CompareTo(node.LeftKey) >= 0)
            {
                node.MiddleChild = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = node.MiddleChild,
                    MiddleChild = current.RightChild
                };
                node.LeftChild = current;
                current.RightKey = default(T);
                current.RightChild = null;

                return node;
            }
            else
            {
                TreeNode<T> mergedNode = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = current,
                    MiddleChild = node
                };
                // node.LeftChild = current.RightChild; --- Fix
                current.RightChild = null;
                current.RightKey = default(T);

                return mergedNode;
            }
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
