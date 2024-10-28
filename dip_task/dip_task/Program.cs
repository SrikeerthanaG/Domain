// See https://aka.ms/new-console-template for more information
using dip_task;


// Program.cs

public class Program
{
    public static void Main()
    {
        LibrarySystem librarySystem = new LibrarySystem();

        IUser student = new Student();
        IUser teacher = new Teacher();
        IUser librarian = new Librarian();

        librarySystem.PerformBorrowBook(student, "Introduction to C#");
        librarySystem.PerformReturnBook(teacher, "Data Structures");
        librarySystem.PerformReserveBook(teacher, "Artificial Intelligence");
        librarySystem.PerformAddBook(librarian, "New Book on Machine Learning");
        librarySystem.PerformRemoveBook(librarian, "Outdated Book on Java");
    }
}

