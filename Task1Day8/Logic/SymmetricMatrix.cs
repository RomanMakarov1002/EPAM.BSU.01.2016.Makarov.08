using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SymmetricMatrix<T> : SquareAbsMatrix<T>
    {             
        public SymmetricMatrix(T[,] array) : base (array) { }

        public SymmetricMatrix(T[] array) :base (array) { }
             
        protected override T GetValue(int i, int j)
        {
            return Matrix[i + j*(int) Math.Sqrt(Length)];         
        }
        
        protected override void SetValue(int i, int j, T value)
        {            
            Matrix[i + j * (int)Math.Sqrt(Length)] = value;
            Matrix[j + i * (int)Math.Sqrt(Length)] = value;
        }
    }
}
