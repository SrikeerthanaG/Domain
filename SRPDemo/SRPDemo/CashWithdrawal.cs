using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPDemo
{
    public class CashWithdrawal
    {
        public decimal PerformWithdrawal(decimal amount, ref decimal balance)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (balance >= amount)
            {
                balance -= amount;
                return amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance.");
            }
        }
    }
}
