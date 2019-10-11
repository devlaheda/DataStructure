
public class DoublyLinkedList<T> : IEnumerable
    {
        private int _size = 0;
        private Node<T> head = null;
        private Node<T> tail = null;

        private class Node<T>
        {
            public T data;
            public Node<T> next, prev;

            public Node(T data, Node<T> Prev, Node<T> Next)
            {
                this.data = data;
                this.next = Next;
                this.prev = Prev;
            }

            public override string ToString()
            {
                return data.ToString();
            }
        }

        public int Size => this._size;
        public bool IsEmpty => this._size == 0;

        public void AddLast(T element)
        {
            if (IsEmpty)
            {
                tail = head = new Node<T>(element, null, null);
            }
            else
            {
                tail.next = new Node<T>(element, tail, null);
                tail = tail.next;
            }

            _size++;
        }

        public void Add(T element)
        {
            AddLast(element);
        }

        public void AddFirst(T element)
        {
            if (IsEmpty)
            {
                tail = head = new Node<T>(element, null, null);
            }
            else
            {
                head.prev = new Node<T>(element, null, head);
                head = head.prev;
            }

            _size++;
        }

        public T PeekFirst() => (IsEmpty) ? throw new Exception("Empty List") : head.data;
        public T PeekLast() => (IsEmpty) ? throw new Exception("Empty List") : tail.data;

        public T RemoveFirst()
        {
            if (IsEmpty)
                throw new Exception("List is Empty");
            T data = head.data;
            if (head == tail)
            {
                head = tail = null;
                _size = 0;
            }
            else
            {
                head = head.next;
                head.prev = null;
                _size--;
            }

            return data;
        }

        public T RemoveLast()
        {
            if (IsEmpty)
                throw new Exception("List is Empty");
            T data = tail.data;
            if (head == tail)
            {
                head = tail = null;
                _size = 0;
            }
            else
            {
                tail = tail.prev;
                head.next = null;
                _size--;
            }

            return data;
        }

        private T RemoveInternal(Node<T> node)
        {
            if (node.next == null) return RemoveLast();
            if (node.prev == null) return RemoveFirst();
            node.next.prev = node.prev;
            node.prev.next = node.next;
            T data = node.data;
            node = null;
            _size--;
            return data;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException();

            Node<T> trav;
            int i;
            if (index < _size / 2)
            {
                for (i = 0, trav = head; i != index; i++)
                {
                    trav = trav.next;
                }
            }
            else
            {
                for (i = 0, trav = tail; i != index; i++)
                {
                    trav = trav.prev;
                }
            }

            return RemoveInternal(trav);
        }

        protected bool Remove(Node<T> node)
        {
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
