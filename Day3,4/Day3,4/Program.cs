// See https://aka.ms/new-console-template for more information

// TASK 11
/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
namespace Day3_Day4_Tasks

{
        // Author class
        public class Author
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Nationality { get; set; }
        }

        // Book class
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int AuthorId { get; set; }
            public string Genre { get; set; }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Hardcoded data for Authors
                List<Author> authors = new List<Author>
            {
                new Author { Id = 1, Name = "J.K. Rowling", Nationality = "British" },
                new Author { Id = 2, Name = "George R.R. Martin", Nationality = "American" },
                new Author { Id = 3, Name = "J.R.R. Tolkien", Nationality = "British" },
                new Author { Id = 4, Name = "Agatha Christie", Nationality = "British" },
                new Author { Id = 5, Name = "Isaac Asimov", Nationality = "American" }
            };

                // Hardcoded data for Books
                List<Book> books = new List<Book>
            {
                new Book { Id = 1, Title = "Harry Potter", AuthorId = 1, Genre = "Fantasy" },
                new Book { Id = 2, Title = "A Game of Thrones", AuthorId = 2, Genre = "Fantasy" },
                new Book { Id = 3, Title = "The Hobbit", AuthorId = 3, Genre = "Fantasy" },
                new Book { Id = 4, Title = "Murder on the Orient Express", AuthorId = 4, Genre = "Mystery" },
                new Book { Id = 5, Title = "Foundation", AuthorId = 5, Genre = "Science Fiction" }
            };

                // Paths for JSON and XML files
                string authorJsonPath = "authors.json";
                string bookJsonPath = "books.json";
                string authorXmlPath = "authors.xml";
                string bookXmlPath = "books.xml";

                // Serialize to JSON and save to disk using System.Text.Json
                File.WriteAllText(authorJsonPath, JsonSerializer.Serialize(authors, new JsonSerializerOptions { WriteIndented = true }));
                File.WriteAllText(bookJsonPath, JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));

                // Serialize to XML and save to disk
                XmlSerializer authorXmlSerializer = new XmlSerializer(typeof(List<Author>));
                XmlSerializer bookXmlSerializer = new XmlSerializer(typeof(List<Book>));

                using (FileStream fs = new FileStream(authorXmlPath, FileMode.Create))
                {
                    authorXmlSerializer.Serialize(fs, authors);
                }
                using (FileStream fs = new FileStream(bookXmlPath, FileMode.Create))
                {
                    bookXmlSerializer.Serialize(fs, books);
                }

                // Read JSON and display data in console
                Console.WriteLine("Reading JSON Data:");
                string authorJsonData = File.ReadAllText(authorJsonPath);
                string bookJsonData = File.ReadAllText(bookJsonPath);

                Console.WriteLine("\nAuthors JSON:\n" + authorJsonData);
                Console.WriteLine("\nBooks JSON:\n" + bookJsonData);

                // Deserialize JSON to objects using System.Text.Json
                List<Author> authorsFromJson = JsonSerializer.Deserialize<List<Author>>(authorJsonData);
                List<Book> booksFromJson = JsonSerializer.Deserialize<List<Book>>(bookJsonData);

                Console.WriteLine("\nDeserialized Authors from JSON:");
                foreach (var author in authorsFromJson)
                {
                    Console.WriteLine($"ID: {author.Id}, Name: {author.Name}, Nationality: {author.Nationality}");
                }

                Console.WriteLine("\nDeserialized Books from JSON:");
                foreach (var book in booksFromJson)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author ID: {book.AuthorId}, Genre: {book.Genre}");
                }

                // Read XML and display data in console
                Console.WriteLine("\nReading XML Data:");
                string authorXmlData = File.ReadAllText(authorXmlPath);
                string bookXmlData = File.ReadAllText(bookXmlPath);

                Console.WriteLine("\nAuthors XML:\n" + authorXmlData);
                Console.WriteLine("\nBooks XML:\n" + bookXmlData);

                // Deserialize XML to objects
                using (FileStream fs = new FileStream(authorXmlPath, FileMode.Open))
                {
                    List<Author> authorsFromXml = (List<Author>)authorXmlSerializer.Deserialize(fs);
                    Console.WriteLine("\nDeserialized Authors from XML:");
                    foreach (var author in authorsFromXml)
                    {
                        Console.WriteLine($"ID: {author.Id}, Name: {author.Name}, Nationality: {author.Nationality}");
                    }
                }

                using (FileStream fs = new FileStream(bookXmlPath, FileMode.Open))
                {
                    List<Book> booksFromXml = (List<Book>)bookXmlSerializer.Deserialize(fs);
                    Console.WriteLine("\nDeserialized Books from XML:");
                    foreach (var book in booksFromXml)
                    {
                        Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author ID: {book.AuthorId}, Genre: {book.Genre}");
                    }
                }

                Console.WriteLine("\nData serialization and deserialization complete!");
            }
        }
}
*/

//  TASK 12
/*

namespace Day3_Day4_Tasks
{
    // Customer class
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    // Validator class
    public static class Validator
    {
        // Validate Email
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Basic email format validation
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Validate PhoneNumber (e.g., 10 digits only)
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Assuming a valid phone number is 10 digits
            string phonePattern = @"^\d{10}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        // Validate DateOfBirth (Must be at least 18 years old)
        public static bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;
            return age >= 18;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating a new customer
            Customer customer = new Customer();

            // Ask for customer details
            Console.WriteLine("Enter your details:");

            Console.Write("Name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Phone Number (10 digits): ");
            customer.PhoneNumber = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            while (true)
            {
                string dobInput = Console.ReadLine();
                if (DateTime.TryParse(dobInput, out DateTime dateOfBirth))
                {
                    customer.DateOfBirth = dateOfBirth;
                    break;
                }
                else
                {
                    Console.Write("Invalid date format. Please enter again (yyyy-mm-dd): ");
                }
            }

            // Validate the customer information
            bool isEmailValid = Validator.IsValidEmail(customer.Email);
            bool isPhoneNumberValid = Validator.IsValidPhoneNumber(customer.PhoneNumber);
            bool isDateOfBirthValid = Validator.IsValidDateOfBirth(customer.DateOfBirth);

            Console.WriteLine($"\nCustomer Name: {customer.Name}");
            Console.WriteLine($"Email Valid: {isEmailValid}");
            Console.WriteLine($"Phone Number Valid: {isPhoneNumberValid}");
            Console.WriteLine($"Date of Birth Valid: {isDateOfBirthValid}");

            if (isEmailValid && isPhoneNumberValid && isDateOfBirthValid)
            {
                Console.WriteLine("All customer details are valid.");
            }
            else
            {
                Console.WriteLine("Some customer details are invalid.");
            }
        }
    }
}
*/

//TASK 13


namespace Day3_Day4_Tasks
{
    // TransportSchedule class
    public class TransportSchedule
    {
        public string TransportType { get; set; } // Only "bus"
        public string Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int SeatsAvailable { get; set; }
    }

    // TransportManager class
    public class TransportManager
    {
        public List<TransportSchedule> Schedules { get; set; }

        public TransportManager()
        {
            Schedules = new List<TransportSchedule>();
        }

        // Search schedules by transport type, route, or time
        public IEnumerable<TransportSchedule> Search(string transportType = null, string route = null, DateTime? departureTime = null)
        {
            return Schedules.Where(s =>
                (string.IsNullOrEmpty(transportType) || s.TransportType.Equals(transportType, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(route) || s.Route.Equals(route, StringComparison.OrdinalIgnoreCase)) &&
                (!departureTime.HasValue || s.DepartureTime.Date == departureTime.Value.Date));
        }

        // Group schedules by transport type
        public IEnumerable<IGrouping<string, TransportSchedule>> GroupByTransportType()
        {
            return Schedules.GroupBy(s => s.TransportType);
        }

        // Order schedules by a specified field
        public IEnumerable<TransportSchedule> OrderByField(Func<TransportSchedule, object> keySelector)
        {
            return Schedules.OrderBy(keySelector);
        }

        // Filter schedules based on seat availability or routes within a time range
        public IEnumerable<TransportSchedule> FilterByAvailability(int minSeats = 1, DateTime? startTime = null, DateTime? endTime = null)
        {
            return Schedules.Where(s => s.SeatsAvailable >= minSeats &&
                (!startTime.HasValue || s.DepartureTime >= startTime) &&
                (!endTime.HasValue || s.DepartureTime <= endTime));
        }

        // Aggregate total available seats and average price
        public (int TotalSeats, decimal AveragePrice) AggregateSeatsAndPrice()
        {
            return (Schedules.Sum(s => s.SeatsAvailable),
                    Schedules.Average(s => s.Price));
        }

        // Select routes and their departure times
        public IEnumerable<(string Route, DateTime DepartureTime)> SelectRoutesAndTimes()
        {
            return Schedules.Select(s => (s.Route, s.DepartureTime));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize TransportManager and add bus schedules
            TransportManager transportManager = new TransportManager
            {
                Schedules = new List<TransportSchedule>
                {
                    new TransportSchedule { TransportType = "bus", Route = "A to B", DepartureTime = DateTime.Parse("2024-10-25 08:00"), ArrivalTime = DateTime.Parse("2024-10-25 12:00"), Price = 50, SeatsAvailable = 20 },
                    new TransportSchedule { TransportType = "bus", Route = "C to D", DepartureTime = DateTime.Parse("2024-10-25 14:00"), ArrivalTime = DateTime.Parse("2024-10-25 18:00"), Price = 40, SeatsAvailable = 15 },
                    new TransportSchedule { TransportType = "bus", Route = "E to F", DepartureTime = DateTime.Parse("2024-10-25 06:00"), ArrivalTime = DateTime.Parse("2024-10-25 10:00"), Price = 60, SeatsAvailable = 10 }
                }
            };

            // Example operations

            // Search for a specific route
            Console.WriteLine("Search Results for route 'A to B':");
            var searchResults = transportManager.Search(route: "A to B");
            foreach (var schedule in searchResults)
            {
                Console.WriteLine($"{schedule.TransportType} from {schedule.Route} at {schedule.DepartureTime}, Price: {schedule.Price}, Seats Available: {schedule.SeatsAvailable}");
            }

            // Group by transport type
            var groupedSchedules = transportManager.GroupByTransportType();
            Console.WriteLine("\nGrouped Schedules by Transport Type:");
            foreach (var group in groupedSchedules)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} schedules");
            }

            // Order by departure time
            var orderedSchedules = transportManager.OrderByField(s => s.DepartureTime);
            Console.WriteLine("\nOrdered Schedules by Departure Time:");
            foreach (var schedule in orderedSchedules)
            {
                Console.WriteLine($"{schedule.TransportType} from {schedule.Route} departs at {schedule.DepartureTime}");
            }

            // Filter schedules by available seats
            var filteredSchedules = transportManager.FilterByAvailability(minSeats: 10);
            Console.WriteLine("\nFiltered Schedules with at least 10 seats available:");
            foreach (var schedule in filteredSchedules)
            {
                Console.WriteLine($"{schedule.TransportType} from {schedule.Route} has {schedule.SeatsAvailable} seats available");
            }

            // Aggregate total seats and average price
            var (totalSeats, averagePrice) = transportManager.AggregateSeatsAndPrice();
            Console.WriteLine($"\nTotal Available Seats: {totalSeats}, Average Price: {averagePrice:C}");

            // Select routes and their departure times
            var routesAndTimes = transportManager.SelectRoutesAndTimes();
            Console.WriteLine("\nRoutes and their Departure Times:");
            foreach (var route in routesAndTimes)
            {
                Console.WriteLine($"Route: {route.Route}, Departure Time: {route.DepartureTime}");
            }
        }
    }
}


