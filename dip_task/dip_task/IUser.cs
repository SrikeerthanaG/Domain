using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dip_task
{
        public interface IUser
        {
            void BorrowBook(string bookTitle);
            void ReturnBook(string bookTitle);


            void ReserveBook(string bookTitle) { }
            void AddBook(string bookTitle) { }
            void RemoveBook(string bookTitle) { }
        }


    }
