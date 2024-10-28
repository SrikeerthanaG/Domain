using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dip_task;


namespace dip_task
{
    public class LibrarySystem
    {
        public void PerformBorrowBook(IUser user, string bookTitle)
        {
            user.BorrowBook(bookTitle);
        }

        public void PerformReturnBook(IUser user, string bookTitle)
        {
            user.ReturnBook(bookTitle);
        }

        public void PerformReserveBook(IUser user, string bookTitle)
        {
            user.ReserveBook(bookTitle);
        }

        public void PerformAddBook(IUser user, string bookTitle)
        {
            user.AddBook(bookTitle);
        }

        public void PerformRemoveBook(IUser user, string bookTitle)
        {
            user.RemoveBook(bookTitle);
        }
    }

}
