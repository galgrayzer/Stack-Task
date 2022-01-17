namespace Task
{
    class Node<T>
    {
        private T value;
        private Node<T> next;
        public Node(T value, Node<T> next = null)
        {
            this.value = value;
            this.next = next;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public T GetValue()
        {
            return this.value;
        }
        public Node<T> GetNext()
        {
            return this.next;
        }
        public bool HasNext()
        {
            return this.next == null;
        }
        public override string ToString()
        {
            string str = "";
            Node<T> temp = this;
            while (temp.HasNext()) { str += $"{temp.GetValue()}, "; }
            return (str += this.value);
        }
    }
}