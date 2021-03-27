using System;

namespace classes
{
    public class InteresEarningAccount : BankAccount
    {
        public InteresEarningAccount(string name, decimal initialBalance) : base(name,initialBalance)
        {}

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest,DateTime.Now, "apply month interest");
            }
        }
    }
}