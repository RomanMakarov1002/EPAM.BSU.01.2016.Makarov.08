using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class ExtensionClass
    {
        public static dynamic Add<T>(this Matrix<T> lhs, Matrix<T> rhs, Func<T, T, T> sumFunc)
        {
            if(lhs == null || rhs == null)
                throw new ArgumentNullException();
            if (lhs.Size!= rhs.Size)
                throw new InvalidOperationException();
            dynamic _lhs=lhs;
            dynamic _rhs= rhs;         
            return AddM(_lhs, _rhs, sumFunc);
        }

        private static DiagonalMatrix<T> AddM<T>(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs, Func<T, T, T> sumFunc)
        {
            return new DiagonalMatrix<T>(CalculateSum(lhs, rhs, sumFunc));
        }

        private static SquareMatrix<T> AddM<T>(SquareMatrix<T> lhs, SquareMatrix<T> rhs, Func<T, T, T> sumFunc)
        {
            return new SquareMatrix<T>(CalculateSum(lhs, rhs, sumFunc));
        }

        private static SymmetricMatrix<T> AddM<T>(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs, Func<T, T, T> sumFunc)
        {
            return new SymmetricMatrix<T>(CalculateSum(lhs, rhs, sumFunc));
        }

        private static Matrix<T> AddM<T>(Matrix<T> lhs, Matrix<T> rhs, Func<T, T, T> sumFunc)
        {
            return new Matrix<T>(CalculateSum(lhs, rhs, sumFunc));
        } 

        private static T[,] CalculateSum<T>(Matrix<T> lhs, Matrix<T> rhs, Func<T,T,T> sumFunc)
        {
            if (lhs == null || rhs == null)
                throw new ArgumentNullException();
            if (lhs.Size != rhs.Size)
                throw new InvalidOperationException();
            T[,] resArray = new T[lhs._matrix.GetLength(0),lhs._matrix.GetLength(1)];            
            for (int i = 0; i < resArray.GetLength(0); i++)
                for (int j = 0; j < resArray.GetLength(1); j++)
                    resArray[i, j] = sumFunc(lhs._matrix[i, j], rhs._matrix[i, j]);
            return resArray;
        } 

    }
    
}
