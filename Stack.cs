namespace Task
{
    class Stack<T>
    {
        private Node<T> head;

        public Stack()
        {
            this.head = null;
        }

        public void Push(T x)
        {
            Node<T> temp = new Node<T>(x);
            temp.SetNext(head);
            head = temp;
        }

        public T Pop()
        {
            T x = head.GetValue();
            head = head.GetNext();
            return x;
        }

        public T Top()
        {
            return head.GetValue();
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public override string ToString()
        {
            return this.ToString(this.head);

        }
        private string ToString(Node<T> node)
        {
            if (node == null)
                return "\n";
            return node.GetValue().ToString() + " | " + ToString(node.GetNext());
        }
    }
}
