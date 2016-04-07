using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(T[,] array) : base (array)
        {
            if (_matrix.GetLength(0) != _matrix.GetLength(1))
                throw new ArgumentException("Square Matrix must have same amount of rows and columns");
        }

        public SquareMatrix(T[,] array, Func<T, T, T> plusFunc) : this(array)
        {
            _plusFunc = plusFunc;
        }       
    }
}
