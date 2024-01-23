using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RH_Scripts.Classes
{
    public class Book
    {
        public bool RecycledBook = true;

        public Book(bool recycledBook)
        {
            RecycledBook = recycledBook;
        }
    }
}
