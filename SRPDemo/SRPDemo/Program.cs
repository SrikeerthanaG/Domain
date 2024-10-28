// See https://aka.ms/new-console-template for more information
using SRPDemo;
class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(1000);

        account.Deposit(500);
        account.Withdraw(200);
        account.Deposit(100);

        Console.WriteLine("Mini Statement:");
        foreach (var transaction in account.GetMiniStatement())
        {
            Console.WriteLine($"{transaction.Type}: {transaction.Amount} on {transaction.Date}");
        }

        Console.WriteLine("\nMonthly Statement:");
        foreach (var transaction in account.GetMonthlyStatement())
        {
            Console.WriteLine($"{transaction.Type}: {transaction.Amount} on {transaction.Date}");
        }

        Console.WriteLine("\nYearly Statement:");
        foreach (var transaction in account.GetYearlyStatement())
        {
            Console.WriteLine($"{transaction.Type}: {transaction.Amount} on {transaction.Date}");
        }
    }
}