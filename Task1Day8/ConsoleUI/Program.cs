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
        static void Main(string[] args)
        {           
            int[,] sym = new int[5,5] { {9,2,3,4,5}, {2,9,5,1,3}, {3,5,9,2,4}, {4,1,2,9,2}, {5,3,4,2,9} };
            int[,] sym1 = new int[5,5] { {1,1,1,1,1}, {1,1,1,1,1}, {1,1,1,1,1}, {1,1,1,1,1}, {1,1,1,1,1} };
            SymmetricMatrix<int> sMatrix = new SymmetricMatrix<int>(sym);
            SymmetricMatrix<int> Smatrix2 = new SymmetricMatrix<int>(sym1);
            SymmetricMatrix<int> Smatrix3 ;           
            for (int i=0; i<5; i++)
            { for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0} ", sMatrix[i,j]);
                }
            Console.WriteLine();
            }         
            Smatrix3 = sMatrix.Add(Smatrix2);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0} ", Smatrix3[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            Smatrix3[2, 1] = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0} ", Smatrix3[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            int[,] squaremat = new int[3,3] { {1,2,3}, {1,2,3}, {1,2,3} };
            int[,] squaremat1 = new int[3, 3] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            SquareMatrix<int> a1 = new SquareMatrix<int>(squaremat);
            SquareMatrix<int> a2 = new SquareMatrix<int>(squaremat1);
            SquareMatrix<int> a3 = a1.Add(a2);
            Console.WriteLine(a3.GetType());
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0} ", a3[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            int[,] diagonal = new int[3,3] { {1,0,0}, {0,1,0}, {0,0,1} };
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(diagonal);
            dynamic tt = a3.Add(diagonalMatrix);
            Console.WriteLine(tt.GetType());
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0} ", tt[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("int check finished");
            Console.ReadKey();

            
            string[,] stringsArray = new string[4,4] {
                {"one", "two", "three", "four"}, {"five", "six", "seven", "eight"}, {"nine", "ten", "eleven", "twelve"},
                {"thirteen", "fourteen", "fifteen", "sixteen" }};
            string[,] stringsArray2 = new string[4,4] {
                {"Hello", "Heya", "Hi", "Yo"}, { "Hello", "Heya", "Hi", "Yo" },
                {"Hello", "Heya", "Hi", "Yo"},{"Hello", "Heya", "Hi", "Yo"}};
            SquareMatrix<string> matrix1 = new SquareMatrix<string>(stringsArray);
            SquareMatrix<string> matrix2 = new SquareMatrix<string>(stringsArray2);
            var res = matrix1.Add(matrix2);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0} ", res[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            double[,] symDouble = new double[5, 5] { { 9.0, 2.1, 3.1, 4.2, 5.1 }, { 2.3, 9, 5.6, 7.1, 3 }, { 3, 5.1, 9.4, 2.6, 4 }, 
                { 4, 1.3, 2.7, 9.8, 2 }, { 5, 3.1, 4.4, 2, 9.2 } };
            double[,] sym1Double = new double[5, 5] { { 1.3, 1.5, 2.1, 1, 3.1 }, { 1, 4.1, 1, 1.1, 2.1 }, { 1, 3.1, 4.1, 5.1, 1 },
                { 3.7, 2.1, 1, 1.4, 1 }, { 1.5, 1, 1.9, 8.1, 1 } };
            SquareMatrix<double> squareDoubleMatrix1 = new SquareMatrix<double>(symDouble);
            SquareMatrix<double> squareDoubleMatrix2 = new SquareMatrix<double>(sym1Double);
            SquareMatrix<double> squareDoubleMatrix3 = squareDoubleMatrix1.Add(squareDoubleMatrix2);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0} ", squareDoubleMatrix3[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
