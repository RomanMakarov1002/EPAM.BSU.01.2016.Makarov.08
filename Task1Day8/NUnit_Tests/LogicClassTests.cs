using System;
using System.Collections.Generic;
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
        public string StringsSum(string lhs, string rhs)
        {
            return lhs + rhs;
        }

        public int IntsSum(int lhs, int rhs)
        {
            return lhs + rhs;
        }
        [Test]
        public void Matrix_Test()
        {
            string[,] arrayStrings = new string[2,2] { {"Hello", "Heya"}, {"Heya", "Hello"} };
            string[,] arrayStrings1 = new string[2, 2] { { "Hello", "Heya" }, { "Heya", "Hello" } };
            Matrix<string> matrix = new Matrix<string>(arrayStrings, StringsSum);
            Matrix<string> matrix1 = new Matrix<string>(arrayStrings1);
            Matrix<string> resultmatrix = matrix.Add(matrix1, StringsSum);
            string[,] resStrings = new string[2, 2] { { "HelloHello", "HeyaHeya" }, { "HeyaHeya", "HelloHello" } };
            Matrix<string> res = new Matrix<string>(resStrings);
            for (int i=0; i<2; i++)
                for (int j=0; j<2; j++)
            Assert.AreEqual(res[i,j],resultmatrix[i,j]);
            int[,] arrayInts = new int[3,3]  { {1,2,3}, {2,4,5}, {3,5,9} };
            int[,] arrayInts2 = new int[3,3] { {5,4,3}, {5, 8, 2}, {1, 0 , 8} };
            Matrix<int> matrixofints1= new Matrix<int>(arrayInts,IntsSum);
            Matrix<int> matrixofints2 = new Matrix<int>(arrayInts2);
            Matrix<int> resintMatrix = matrixofints1.Add(matrixofints2, IntsSum);
            int[,] ress = new int[3,3] { {6,6,6}, {7,12,7}, {4,5,17} };
            for (int i=0 ; i < 3; i++)
                for (int j=0 ; j < 3; j++)
                    Assert.AreEqual(resintMatrix[i,j], ress[i,j]);            
        }


        [Test]
        public void SymmetricMatrix_Test()
        {
            int[,] arrayInts = new int[3,3] { {1,2,3}, {2,5,8}, {3,8,4} };
            int[,] arrayInts2 = new int[3,3] { {1,4,5}, {4,3,2}, {5,2,6} };
            int[,] resArray =new int[3,3] { {2,6,8}, {6,8,10}, {8, 10, 10 }};
            SymmetricMatrix<int> symMatrix = new SymmetricMatrix<int>(arrayInts);
            SymmetricMatrix<int> symMatrix2 = new SymmetricMatrix<int>(arrayInts2);
            SymmetricMatrix<int> reSymmetricMatrix = symMatrix.Add(symMatrix2, IntsSum);
            for (int i=0; i< 3; i++)
                for (int j=0; j< 3; j++)
                    Assert.AreEqual(resArray[i,j],reSymmetricMatrix[i,j]);
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
                    Assert.AreEqual(resArray[i, j], resMatrix[i, j]);
        }

        [Test]
        public void Sum_Test()
        {
            int[,] arrayInts = new int[3, 3] { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 4 } };
            int[,] arrayInts2 = new int[3, 3] { { 1, 2, 3 }, { 4, 3, 8 }, { 1, 0, 6 } };
            int[,] resArray = new int[3, 3] { { 2, 2, 3 }, { 4, 8, 8 }, { 1, 0, 10 } };
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(arrayInts);
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(arrayInts2);
            SquareMatrix<int> resMatrix = diagonalMatrix.Add(squareMatrix, IntsSum);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(resArray[i, j], resMatrix[i, j]);
        }
    }
}
