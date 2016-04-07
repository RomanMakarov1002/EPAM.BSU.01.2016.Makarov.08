using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Node<T>: IEquatable<T>
    {
        public T Data { get; }

        public Node(T data)
        {
            if (data == null)
                throw new ArgumentNullException();
            Data = data;
        }

        public Node() { }

        public bool Equals(Node<T> other)
        {
            return Data.Equals(other.Data);
        }

        public bool Equals(T other)
        {
            return Data.Equals(other);
        }
    }
}
