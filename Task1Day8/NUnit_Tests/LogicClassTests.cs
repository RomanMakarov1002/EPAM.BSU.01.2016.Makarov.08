using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Logic;

namespace NUnit_Tests
{    
    [TestFixture]
    public class LogicClassTests
    {                          
        [Test]
        public void SymmetricMatrix_Test1()
        {
            int[,] arrayInts = new int[3,3] { { 1, 2, 3 }, { 2, 5, 8 }, { 3, 8, 4 } };
            int[,] arrayInts2 = new int[3,3] { { 1, 4, 5 }, { 4, 3, 2 }, { 5, 2, 6 } };
            int[,] resArray =new int[3,3] { { 2, 6, 8 }, { 6, 8, 10 }, { 8, 10, 10 }};
            SymmetricMatrix<int> symMatrix = new SymmetricMatrix<int>(arrayInts);
            SymmetricMatrix<int> symMatrix2 = new SymmetricMatrix<int>(arrayInts2);
            SymmetricMatrix<int> reSymmetricMatrix = symMatrix.Add(symMatrix2);
            for (int i=0; i< 3; i++)
                for (int j=0; j< 3; j++)
                    Assert.AreEqual(resArray[i,j],reSymmetricMatrix[i,j]);
        }

        [Test]
        public void SymmetricMatrix_Test2()
        {
            int[,] sym = new int[5, 5] { { 9, 2, 3, 4, 5 }, { 2, 9, 5, 1, 3 }, { 3, 5, 9, 2, 4 }, { 4, 1, 2, 9, 2 }, { 5, 3, 4, 2, 9 } };
            int[,] sym1 = new int[5, 5] { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } };
            int[,] resArray = new int[5,5] { { 10 , 3, 4, 5, 6 }, { 3, 10, 6, 2, 4 }, { 4, 6, 10, 3, 5 }, { 5, 2, 3, 10, 3 }, { 6, 4, 5, 3, 10 } };
            SymmetricMatrix<int> sMatrix = new SymmetricMatrix<int>(sym);
            SymmetricMatrix<int> sMatrix2 = new SymmetricMatrix<int>(sym1);
            SymmetricMatrix<int> sMatrix3 = sMatrix.Add(sMatrix2);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    Assert.AreEqual(resArray[i, j], sMatrix3[i, j]);
        }

        [Test]
        public void DiagonalMatrix_Test()
        {
            int[,] arrayInts = new int[3, 3] { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 4 } };
            int[,] arrayInts2 = new int[3, 3] { { 1, 0, 0 }, { 0, 3, 0 }, { 0, 0, 6 } };
            int[,] resArray = new int[3, 3] { { 2, 0, 0 }, { 0, 8, 0 }, { 0, 0, 10 } };
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(arrayInts);
            DiagonalMatrix<int> diagonalMatrix1 = new DiagonalMatrix<int>(arrayInts2);
            DiagonalMatrix<int> resMatrix = new DiagonalMatrix<int>(resArray);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(resArray[i, j], resMatrix[i, j]);
                   // Debug.Write(resMatrix[i,j]);
                }
        }

        [Test]
        public void SumInt_Test()
        {
            int[,] arrayInts = new int[3, 3] { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 4 } };
            int[,] arrayInts2 = new int[3, 3] { { 1, 2, 3 }, { 4, 3, 8 }, { 1, 0, 6 } };
            int[,] resArray = new int[3, 3] { { 2, 2, 3 }, { 4, 8, 8 }, { 1, 0, 10 } };
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(arrayInts);
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(arrayInts2);
            SquareMatrix<int> resMatrix = diagonalMatrix.Add(squareMatrix);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(resArray[i, j], resMatrix[i, j]);
        }

        [Test]
        public void SumString_Test()
        {
            string[,] stringsArray = new string[4, 4] {
                {"one", "two", "three", "four"}, {"five", "six", "seven", "eight"}, {"nine", "ten", "eleven", "twelve"},
                {"thirteen", "fourteen", "fifteen", "sixteen" }};
            string[,] stringsArray2 = new string[4, 4] {
                {"Hello", "Heya", "Hi", "Yo"}, { "Hello", "Heya", "Hi", "Yo" },
                {"Hello", "Heya", "Hi", "Yo"},{"Hello", "Heya", "Hi", "Yo"}};
            string[,] resArray = new string[4,4] { { "oneHello", "twoHeya", "threeHi", "fourYo" }, { "fiveHello", "sixHeya",
                    "sevenHi", "eightYo" }, {"nineHello", "tenHeya", "elevenHi", "twelveYo"},
                {"thirteenHello", "fourteenHeya", "fifteenHi", "sixteenYo" }};
            SquareMatrix<string> matrix1 = new SquareMatrix<string>(stringsArray);
            SquareMatrix<string> matrix2 = new SquareMatrix<string>(stringsArray2);
            var resMatrix = matrix1.Add(matrix2);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Assert.AreEqual(resArray[i, j], resMatrix[i, j]);
        }

        [Test]
        public void SumDouble_Test()
        {
            double[,] symDouble = new double[5, 5] { { 9.0, 2.1, 3.1, 4.2, 5.1 }, { 2.3, 9, 5.6, 7.1, 3 }, { 3, 5.1, 9.4, 2.6, 4 },
                { 4, 1.3, 2.7, 9.8, 2 }, { 5, 3.1, 4.4, 2, 9.2 } };
            double[,] sym1Double = new double[5, 5] { { 1.3, 1.5, 2.1, 1, 3.1 }, { 1, 4.1, 1, 1.1, 2.1 }, { 1, 3.1, 4.1, 5.1, 1 },
                { 3.7, 2.1, 1, 1.4, 1 }, { 1.5, 1, 1.9, 8.1, 1 } };
            SquareMatrix<double> squareDoubleMatrix1 = new SquareMatrix<double>(symDouble);
            SquareMatrix<double> squareDoubleMatrix2 = new SquareMatrix<double>(sym1Double);
            SquareMatrix<double> resMatrix = squareDoubleMatrix1.Add(squareDoubleMatrix2);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Debug.Write(resMatrix[i, j], " ");
                Debug.WriteLine(" ");
            }
        }
    }
}
