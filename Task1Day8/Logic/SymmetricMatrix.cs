using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(T[,] array) : base(array)
        {
            for (int i=0; i<_matrix.GetLength(0); i++)
                for (int j=0; j<_matrix.GetLength(1); j++)
                    if (!(_matrix[i,j].Equals(_matrix[j,i])))
                            throw new ArgumentException("Symmetric matrix must have symmetric arguments across main diagonal");
        }

        public SymmetricMatrix(T[,] array, Func<T, T, T> plusFunc) : this(array)
        {
            _plusFunc = plusFunc;
        }
    }
}
