using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPDemo
{
    public class Deposit
    {
        public decimal PerformDeposit(decimal amount, ref decimal balance)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            balance += amount;
            return amount;
        }
    }
}
