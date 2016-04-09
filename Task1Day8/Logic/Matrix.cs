using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class SquareAbsMatrix<T> 
    {
        private readonly Changing _change = new Changing();
        public int Length { get; protected set; }
        public T[] Matrix { get; protected set; }
    
        protected SquareAbsMatrix()
        {
            _change.Temp += Connect;
        } 

        protected SquareAbsMatrix(T[] array) :this ()
        {
            if (array == null)
                throw new ArgumentNullException();
            Length = array.Length;
            Matrix = new T[Length];
            Array.Copy(array, Matrix, Length);
        } 

        protected SquareAbsMatrix(T[,] array) : this()
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException("Square matrix has the same amount of elements in both dimensions");
            Length = array.Length;
            Matrix = new T[Length];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    Matrix[i + j * array.GetLength(0)] = array[i, j];
        }                
   
        public T this[int index1, int index2]
        {           
            get
            {
                return GetValue(index1, index2);
            }
            set
            {
                SetValue(index1, index2, value);
                _change.OnChange(new CustomEvent(index1, index2));
            }
        }

        protected abstract T GetValue(int i, int j);
        protected abstract void SetValue(int i, int j, T value);
        
        protected virtual void Connect(object sender, CustomEvent e)
        {
            Console.WriteLine("{0} Element changed at {1},{2}",this ,e.Index1,e.Index2);
        }       
    }
}
