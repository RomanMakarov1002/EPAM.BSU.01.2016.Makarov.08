using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class CustomComparators
    {
    }

    public class IntComparerDec : IComparer<int>
    {
        public int Compare(int lhs, int rhs)
        {
            return lhs < rhs ? 1 : -1;
        }
    }

    public class StringComparerDec : IComparer<String>
    {
        public int Compare(string lhs, string rhs)
        {
            return String.Compare(lhs, rhs, StringComparison.InvariantCulture)*(-1);
        }
    }

    public class BooksComparer : IComparer<Book>
    {
        public int Compare(Book lhs, Book rhs)
        {
            return lhs.Year.CompareTo(rhs.Year);
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point lhs, Point rhs)
        {
            return (lhs.X + lhs.Y).CompareTo(rhs.X + rhs.Y);
        }
    }

}
