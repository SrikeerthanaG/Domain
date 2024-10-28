using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPDemo
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }

        public Transaction(DateTime date, decimal amount, string type)
        {
            Date = date;
            Amount = amount;
            Type = type;
        }
    }

    public class Statement
    {
        private readonly List<Transaction> _transactions;

        public Statement()
        {
            _transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        // Mini statement - last 5 transactions
        public List<Transaction> GetMiniStatement()
        {
            return _transactions.TakeLast(5).ToList();
        }

        // Monthly statement - all transactions in the current month
        public List<Transaction> GetMonthlyStatement()
        {
            return _transactions.Where(t => t.Date.Month == DateTime.Now.Month && t.Date.Year == DateTime.Now.Year).ToList();
        }

        // Yearly statement - all transactions in the current year
        public List<Transaction> GetYearlyStatement()
        {
            return _transactions.Where(t => t.Date.Year == DateTime.Now.Year).ToList();
        }
    }
}
