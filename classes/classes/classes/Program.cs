using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("学习C#语言的类");

            var account = new BankAccount("wangyazhu", 10000);
            Console.WriteLine(
                $"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
            account.MakeWithdrawal(500, DateTime.Now, "rent payment");
            Console.WriteLine(account.Balance);
            
            account.MakeDeposit(100,DateTime.Now, "friend paid me back");
            Console.WriteLine(account.Balance);
            
            account.MakeWithdrawal(7899,DateTime.Now, "Buy macbook Air");
            
            Console.WriteLine(account.GetAccountHistory());
            
            // 捕获异常
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            try
            {
                account.MakeWithdrawal(10002, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
        }
    }
}