using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class ExtensionClass
    {
        public static dynamic Add<T>(this SquareAbsMatrix<T> lhs, SquareAbsMatrix<T> rhs)
        {
            if(lhs == null || rhs == null)
                throw new ArgumentNullException();
            if (lhs.Length != rhs.Length)
                throw new ArgumentException();
            dynamic _lhs=lhs;
            dynamic _rhs= rhs;         
            return AddM(_lhs, _rhs);
        }

        private static DiagonalMatrix<T> AddM<T>(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            return new DiagonalMatrix<T>(Sum(lhs, rhs));
        }

        private static SquareMatrix<T> AddM<T>(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            return new SquareMatrix<T>(Sum(lhs,rhs));
        }

        private static SymmetricMatrix<T> AddM<T>(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            return new SymmetricMatrix<T>(Sum(lhs, rhs));
        }

        private static SquareMatrix<T> AddM<T>(SquareAbsMatrix<T> lhs, SquareAbsMatrix<T> rhs)
        {
            return new SquareMatrix<T>(Sum(lhs,rhs));
        } 
            
        private static T[] Sum<T>(SquareAbsMatrix<T> lhs, SquareAbsMatrix<T> rhs)
        {
            var first = Expression.Parameter(typeof(T));          
            var second = Expression.Parameter(typeof (T));
            /*
            var binExpr = Expression.Add(first, second);
            var expr = Expression.Lambda<Func<T, T, T>>(binExpr, first, second);
            var func = expr.Compile();
            */
            MethodInfo concatMethod = null;
            if (typeof(T) == typeof(String))
                concatMethod = typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string) });
            
            Func<T, T, T> add =
                (x, y) => Expression.Lambda<Func<T, T, T>>(Expression.Add(first,
                    second, concatMethod), first, second).Compile().Invoke(x,y);
                     
            T[] resultedArray = new T[lhs.Matrix.Length];
            for (int i = 0; i < resultedArray.Length; i++)
                resultedArray[i] = add(lhs.Matrix[i], rhs.Matrix[i]);                                                     
            return resultedArray;
        }
    }
    
}
