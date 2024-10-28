using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dip_task;

namespace dip_task
{
    
        public class Student : IUser
        {
            public void BorrowBook(string bookTitle)
            {
                Console.WriteLine($"Student borrowed the book: {bookTitle}");
            }

            public void ReturnBook(string bookTitle)
            {
                Console.WriteLine($"Student returned the book: {bookTitle}");
            }
        }
        public class Teacher : IUser
        {
            public void BorrowBook(string bookTitle)
            {
                Console.WriteLine($"Teacher borrowed the book: {bookTitle}");
            }

            public void ReturnBook(string bookTitle)
            {
                Console.WriteLine($"Teacher returned the book: {bookTitle}");
            }

            public void ReserveBook(string bookTitle)
            {
                Console.WriteLine($"Teacher reserved the book: {bookTitle}");
            }
        }
        public class Librarian : IUser
        {
            public void BorrowBook(string bookTitle)
            {
                Console.WriteLine($"Librarian borrowed the book: {bookTitle}");
            }

            public void ReturnBook(string bookTitle)
            {
                Console.WriteLine($"Librarian returned the book: {bookTitle}");
            }

            public void AddBook(string bookTitle)
            {
                Console.WriteLine($"Librarian added the book: {bookTitle}");
            }

            public void RemoveBook(string bookTitle)
            {
                Console.WriteLine($"Librarian removed the book: {bookTitle}");
            }
        }

    }

