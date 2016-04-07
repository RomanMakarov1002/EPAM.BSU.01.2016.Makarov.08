using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BinaryNode<T>
    {
        public T Data { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }

        public BinaryNode() { }   

        public BinaryNode(T data) :this (data, null, null) { }
        
        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right )
        {
            Data = data;
            Left = left;
            Right = right;
        }        
    }
}
