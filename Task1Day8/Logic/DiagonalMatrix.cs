using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DiagonalMatrix<T> :SquareAbsMatrix<T>
    {      
        public DiagonalMatrix(T[,] array) : base (array) { } 
      
        public DiagonalMatrix(T[] array) : base(array) { }
       
        protected override T GetValue(int i, int j)
        {
            return i == j ? Matrix[i + j * (int)Math.Sqrt(Length)] : default(T);
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i == j)
                Matrix[i + j * (int)Math.Sqrt(Length)] = value;
            else
                if (!(value.Equals(default(T))))
                    throw new ArgumentException();
        }
    }
}
