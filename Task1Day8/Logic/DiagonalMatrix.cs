using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DiagonalMatrix<T> :SquareMatrix<T>
    {
        public DiagonalMatrix(T[,] array) : base(array)
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
                for (int j = 0; j < _matrix.GetLength(1); j++)
                    if (i!=j)
                        if (!(_matrix[i,j].Equals(default (T))))
                            throw new ArgumentException("Diagonal matrix must have default elements besides diagonal");
                            
        }

        public DiagonalMatrix(T[,] array, Func<T, T, T> plusFunc) : this(array)
        {
            _plusFunc = plusFunc;
        }

    }
}
