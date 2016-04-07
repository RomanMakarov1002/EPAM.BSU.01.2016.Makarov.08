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
            BinarySearchTree<int> bt= new BinarySearchTree<int>();
            bt.Add(5);
            bt.Add(7);
            bt.Add(9);
            bt.Add(2);
            bt.Add(12);
            bt.Add(8);
            bt.Add(6);
            bt.Add(10);
            bt.Add(15);
            bt.Add(1);
            bt.Add(0);
            Console.WriteLine(bt.Contains(15));
            Console.WriteLine(bt.Contains(16));
            Console.WriteLine(bt.MaxElement());
            Console.WriteLine(bt.MinElement());
            Console.WriteLine("default comparator");
            foreach (var item in bt)
            {
                Console.WriteLine(item);
            }
            BinarySearchTree<int> bt1 = new BinarySearchTree<int>(new IntComparerDec());
            bt1.Add(5);
            bt1.Add(7);
            bt1.Add(9);
            bt1.Add(2);
            bt1.Add(12);
            bt1.Add(8);
            bt1.Add(6);
            bt1.Add(10);
            bt1.Add(15);
            bt1.Add(1);
            bt1.Add(0);
            Console.WriteLine("custom comparator");
            foreach (var item in bt1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("preorder");
            foreach (var item in bt.Preorder())
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
            Console.WriteLine("Postorder");
            foreach (var item in bt.PostOrder())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Inorder");
            foreach (var item in bt.InOrder())
            {
                Console.WriteLine(item);
            }
            bt.Remove(20);
            Console.WriteLine();
            Console.WriteLine("Removed 9");
            foreach (var item in bt.InOrder())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            BinarySearchTree<string> strTree = new BinarySearchTree<string>();
            strTree.Add("Hello");
            strTree.Add("Heya");
            strTree.Add("Hi");
            strTree.Add("Yo");
            strTree.Add("Good day");
            foreach (var item in strTree)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();


            BinarySearchTree<Book> book = new BinarySearchTree<Book>();
            book.Add(new Book("Azbyka", 100, "fsfs", "fsfbc", "fsfs", 1895));
            book.Add(new Book("SomeBook", 110, "Remark", "England", "history", 1960));
            book.Add(new Book("Crime and Justice", 800, "Dostoevskiy", "Moscow", "story", 1970));
            book.Add(new Book("CLR via C# 4.5", 896, "Richter", "Petersburgh", "technical", 2013));
            book.Add(new Book("Pro .Net Perfomance", 361, "Goldshtein", "Moscow", "technical", 2014));
            Console.WriteLine("default comparator");
            foreach (var item in book)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            book = new BinarySearchTree<Book>(new BooksComparer());
            book.Add(new Book("Azbyka", 100, "fsfs", "fsfbc", "fsfs", 1895));
            book.Add(new Book("SomeBook", 110, "Remark", "England", "history", 1960));
            book.Add(new Book("Crime and Justice", 800, "Dostoevskiy", "Moscow", "story", 1970));
            book.Add(new Book("CLR via C# 4.5", 896, "Richter", "Petersburgh", "technical", 2013));
            book.Add(new Book("Pro .Net Perfomance", 361, "Goldshtein", "Moscow", "technical", 2014));
            Console.WriteLine("custom comparator");
            foreach (var item in book)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

            BinarySearchTree<Point> pointTree = new BinarySearchTree<Point>();
            try
            {
                pointTree.Add(new Point(5,5));
                pointTree.Add(new Point(5, 7));
            }
            catch (Exception)
            {
                
                Console.WriteLine("Default comparer exception");
            }
            pointTree = new BinarySearchTree<Point>(new PointComparer());
            pointTree.Add(new Point(5, 5));
            pointTree.Add(new Point(6, 6));
            pointTree.Add(new Point(7, 7));
            pointTree.Add(new Point(1, 1));
            Console.WriteLine("Custom comparer");
            foreach (var item in pointTree)
            {
                Console.WriteLine("{0}, {1}",item.X, item.Y);
            }
            Console.ReadKey();
        }
    }
}
