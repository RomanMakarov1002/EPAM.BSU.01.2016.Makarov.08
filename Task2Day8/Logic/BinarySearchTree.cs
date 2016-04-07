using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private BinaryNode<T> _root;
        private BinaryNode<T> _root1;
        private BinaryNode<T> _tempParent;
        private readonly IComparer<T> _comparer; 
        
        public BinarySearchTree() :this(Comparer<T>.Default) { }
        
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();
            _root = new BinaryNode<T>();
            _root1 = _root;
            _comparer = comparer;
        }
        
        public BinaryNode<T> Root { get { return _root; } }

        public virtual void Clear()
        {
            _root = null;
        }

        public void Add(T data)
        {
            BinaryNode<T> newNode = new BinaryNode<T>(data);
            if (_root.Data == null || _root.Data.Equals(default(T)))               
                _root = newNode;
            else
            {
                _root1 = _root;
                while (true)
                {
                    _tempParent = _root1;
                    if (_comparer.Compare(newNode.Data, _root1.Data) == 0)                    
                        return;
                    if (_comparer.Compare(newNode.Data, _root1.Data) < 0)
                    {
                        _root1 = _root1.Left;
                        if (_root1 == null)
                        {
                            _tempParent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {                        
                        _root1 = _root1.Right;
                        if (_root1 == null)
                        {
                            _tempParent.Right = newNode;
                            break;
                        }
                    }
                }
            }        
        }

        public void Remove(T item)
        {
            if (item == null)
                throw  new ArgumentNullException();
            if (_root != null)
                Remove(_root, item);
                    
        }
               
        public bool Contains(T item)
        {
            return Contains(_root, item);
        }

        public T MinElement()
        {
            return MinElement(_root);
        }

        public T MaxElement()
        {
            return MaxElement(_root);
        }

        public IEnumerator<T> GetEnumerator()
        {
             return Preorder(_root).GetEnumerator();
        }

        public IEnumerable<T> Preorder()
        {
            return Preorder(_root);
        }

        public IEnumerable<T> PostOrder()
        {
            return PostOrder(_root);
        }

        public IEnumerable<T> InOrder()
        {
            return InOrder(_root);
        }

        private IEnumerable<T> Preorder(BinaryNode<T> node)
        {
            if (node == null)
                yield break;
            yield return node.Data;
            foreach (var item in Preorder(node.Left))
                yield return item;

            foreach (var item in Preorder(node.Right))
                yield return item;
        }

        private IEnumerable<T> PostOrder(BinaryNode<T> node)
        {
            if (node == null)
                yield break;
            
            foreach (var item in Preorder(node.Left))
                yield return item;

            foreach (var item in Preorder(node.Right))
                yield return item;
            yield return node.Data;
        }

        private IEnumerable<T> InOrder(BinaryNode<T> node)
        {
            if (node == null)
                yield break;

            foreach (var item in Preorder(node.Left))
                yield return item;
            yield return node.Data;
            foreach (var item in Preorder(node.Right))
                yield return item;            
        }

        private bool Contains(BinaryNode<T> node, T item)
        {
            if (node == null)
                return false;
            if (item.Equals(node.Data))
                return true;
            if (_comparer.Compare(item, node.Data) < 0)
                return Contains(node.Left, item);
            return Contains(node.Right, item);
        }

        private BinaryNode<T> Find(BinaryNode<T> node, T item)
        {
            if (node == null)
                return node;
            if (item.Equals(node.Data))
                return node;
            if (_comparer.Compare(item, node.Data) < 0)
                return Find(node.Left, item);
            return Find(node.Right, item);
        }

        private T MinElement(BinaryNode<T> node)
        {
            if (node.Left == null)
                return node.Data;
            return MinElement(node.Left);
        }

        private T MaxElement(BinaryNode<T> node)
        {
            if (node.Right == null)
                return node.Data;
            return MaxElement(node.Right);
        }

        private BinaryNode<T> Remove(BinaryNode<T> node, T item)
        {
            if (node == null)
                return node;
            if (_comparer.Compare(item, node.Data) < 0)
                node.Left = Remove(node.Left, item);
            else if (_comparer.Compare(item, node.Data) > 0)
                node.Right = Remove(node.Right, item);
            else if (node.Left != null && node.Right != null)
            {
                node.Data = MinElement(node.Right);
                node.Right = Remove(node.Right, node.Data);
            }
            else
            if (node.Left != null)
                node = node.Left;
            else
                node = node.Right;            
            return node;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
