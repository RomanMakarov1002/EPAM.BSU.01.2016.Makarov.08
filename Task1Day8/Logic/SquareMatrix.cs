using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SquareMatrix<T> : SquareAbsMatrix<T>
    {              
        public SquareMatrix(T[,] array) :base (array) { } 
        
        public SquareMatrix(T[] array) : base (array) { }       
        
        protected override T GetValue(int i, int j)
        {           
            return Matrix[i + j*(int)Math.Sqrt(Length)];
        }

        protected override void SetValue(int i, int j, T value)
        {
            Matrix[i + j* (int)Math.Sqrt(Length)] = value;
        }
    }
}
