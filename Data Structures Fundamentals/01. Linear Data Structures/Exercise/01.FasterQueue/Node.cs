namespace Problem01.FasterQueue
{
    public class Node<T>
    {
        public Node()
        {

        }

        public Node(T item, Node<T> next)
        {
            this.Item = item;
            this.Next = next;
        }

        public T Item { get; set; }

        public Node<T> Next { get; set; }
    }
}