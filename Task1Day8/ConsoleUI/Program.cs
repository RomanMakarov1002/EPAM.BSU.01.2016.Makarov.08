using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace ConsoleUI
{
    class Program
    {
        private static int sum(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Int16 a = 5;
            Int32 b = 10;
            dynamic t = a + b;
            Console.WriteLine(t.GetType());
            Console.ReadKey();
            
            int[,] squaremat = new int[3,3] { {1,2,3}, {1,2,3}, {1,2,3} };
            int[,] squaremat1 = new int[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            SquareMatrix<int> a1 = new SquareMatrix<int>(squaremat);
            SquareMatrix<int> a2 = new SquareMatrix<int>(squaremat1);
            SquareMatrix<int> a3 = a1.Add(a2, sum);
            Console.WriteLine(a3.GetType());
            Console.ReadKey();

            int[,] diagonal = new int[3,3] { {1,0,0}, {0,1,0}, {0,0,1} };
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(diagonal);
            dynamic tt = a3.Add(diagonalMatrix, sum);
            Console.WriteLine(tt.GetType());
            Console.ReadKey();

            int[,] array1 = new int[2,2] { { 1, 2 }, { 3, 4 } };
            int[,] array2 = new int[2,2] { { 6, 7 }, { 8, 9 } };
            Matrix<int> matrix1 = new Matrix<int>(array1,sum);
            Matrix<int> matrix2 = new Matrix<int>(array2,sum);
            int[,] symmaray = new int[3,3] { {1,2,3}, {2,4,5}, {3, 5, 6} };
            int[,] symmaray1 = new int[3, 3] { { 1, 2, 3 }, { 2, 4, 5 }, { 3, 5, 6 } }; 
            SymmetricMatrix<int> sumMatrix  = new SymmetricMatrix<int>(symmaray);
            int[,] symmaray5 = new int[3, 3] { { 1, 0, 0 }, { 0, 4, 0 }, { 0, 0, 6 } };
            DiagonalMatrix<int> dimMatrix = new DiagonalMatrix<int>(symmaray5);
            dimMatrix[1, 1] = 2;
           
            int[,] symmaray2 = new int[2,3];
           
            SymmetricMatrix<int> sumMatrix2 = new SymmetricMatrix<int>(symmaray1);
           
            Console.ReadKey();
            matrix2[1, 1] = 0;
            Console.ReadKey();
            Matrix<int> matrix3 = matrix1.Add(matrix2,sum);
            for (int i=0; i<2; i++)
                for (int j=0; j<2; j++)
                    Console.WriteLine(matrix3[i,j]);
            Matrix<int> someMatrix = new Matrix<int>(symmaray2);
            Console.ReadKey();
        }
    }
}
