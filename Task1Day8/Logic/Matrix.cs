using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Matrix<T> 
    {
        public T[,] _matrix { get; }
        protected static Func<T, T, T> _plusFunc;
        private readonly Changing _change = new Changing();
        public int Size => _matrix.Length;

        public Matrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            _matrix = array;
            Array.Copy(_matrix,_matrix,_matrix.Length);
            _change.Temp += Connect;
        }

        public Matrix(T[,] array, Func<T, T, T> plusFunc) : this (array)
        {
            if (plusFunc == null)
                throw new ArgumentNullException();
            _plusFunc = plusFunc;
        }
   
        public T this[int index1, int index2]
        {
            get { return _matrix[index1, index2]; }
            set
            {
                _matrix[index1, index2] = value;
                _change.OnChange(new CustomEvent(index1,index2));
            }
        }

        protected virtual void Connect(object sender, CustomEvent e)
        {
            Console.WriteLine("{0} Element changed at {1},{2}",this ,e.Index1,e.Index2);
        }       
    }
}
