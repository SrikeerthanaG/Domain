using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPDemo
{
    public class BankAccount
    {
        private decimal _balance;
        private Deposit _deposit;
        private CashWithdrawal _cashWithdrawal;
        private Statement _statement;

        public BankAccount(decimal initialBalance = 0)
        {
            _balance = initialBalance;
            _deposit = new Deposit();
            _cashWithdrawal = new CashWithdrawal();
            _statement = new Statement();
        }

        public void Deposit(decimal amount)
        {
            var depositedAmount = _deposit.PerformDeposit(amount, ref _balance);
            _statement.AddTransaction(new Transaction(DateTime.Now, depositedAmount, "Deposit"));
        }

        public void Withdraw(decimal amount)
        {
            var withdrawnAmount = _cashWithdrawal.PerformWithdrawal(amount, ref _balance);
            _statement.AddTransaction(new Transaction(DateTime.Now, withdrawnAmount, "Withdrawal"));
        }

        public List<Transaction> GetMiniStatement() => _statement.GetMiniStatement();

        public List<Transaction> GetMonthlyStatement() => _statement.GetMonthlyStatement();

        public List<Transaction> GetYearlyStatement() => _statement.GetYearlyStatement();
    }
}
