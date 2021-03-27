# C#学习笔记

> 时间：2021年3月21日
>
> 作者：王亚祝



## 简介

C#语言编译和执行流程：

![image-20210322200046697](C:\Users\14810\AppData\Roaming\Typora\typora-user-images\image-20210322200046697.png)

> .NET Core框架是一个基于云的，跨平台的、开源衍生产品，可以更好的解决Web开发以及Linux或macOS计算机的开发。



一个简单的示例：

```C#
// SimpleProgram.cs

// 告诉编译器这个程序使用System命名空间的类型
using System;

// 声明一个新命名空间，名称为Simple
namespace Simple
{
    // 声明一个新的类型，名称为Program
    class Program
    {
        // 声明一个名称为Main的方法作为类Program的成员
        // Main是一个特殊函数，编译器用它作为程序的起始点
        static void Main()
        {
            // 简单语句以一个分号结束
            // 这条语句使用命名空间System中的一个名称为Console的类将消息输出到屏幕窗口
            Console.WriteLine("Hi There!");
        }
    }
}
```



## 基础语法

1. 格式化字符串

```c#
// 格式化字符串的两种方式
Console.WriteLine("Two sample integers are {0} and {1}.", 3, 6);
Console.WriteLine("Three integers are {1}, {0}, {1}.", 3, 6);


int var1 = 3;
int var2 = 6;
Console.WriteLine($"Two sample integers {var1} and {var2}.");
```

2. 注释

```c#
// 单行注释
/*
	多行注释
	多行注释
	多行注释
*/

/// 文档注释
```

3. 预定义类型

- bool
- char
- string
- int
- double
- decimal
- float

4. 自定义类型

- 类类型(class)
- 结构类型(struct)
- 数组类型(array)
- 枚举类型(enum)
- 委托类型(delegate)
- 接口类型(interface)

5. 值类型和引用类型

值类型：只需要一段单独的内存，用于存储实际的数据。

引用类型：需要两端内存，第一段存储实际的数据，它总是位于堆中；第二段是一个引用，指向数据在堆中的位置。

## 程序结构







## 面向对象





## 使用类和对象探索面向对象的编程

1. 创建应用程序

![image-20210322212524232](C:\Users\14810\AppData\Roaming\Typora\typora-user-images\image-20210322212524232.png)

使用Rider新建C#控制台程序。目录为`classes`。

在`classes`文件夹中新建名为`BankAccount.cs`的文件。

此文件包含“银行账户“定义，面向对象的编程通过创建类**形式来组织代码。这些类包含表示特定实体的代码。`BankAccount`类表示银行账户。代码通过方法和属性实现特定操作。银行账户包含以下内容：

- 用一个10位数唯一标识银行账户；
- 用字符串存储一个或多个所有者名称；
- 可以检索余额；
- 接受存款；
- 接受取款；
- 初始余额必须为正数；
- 取款后的余额不能是负数。

2. 定义银行账户类型

首先，创建定义此行为的类的基本设置。在`BankAccount.cs`中添加以下代码：

```c#
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace classes
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            
            MakeDeposit(initialBalance,DateTime.Now, "Initial balance");
        }

        private List<Transaction> allTransactions = new List<Transaction>();
        
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
```

3. 打开新账户

```c#
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
```

4. 创建存款和取款

```c#
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
```



5. 记录所有交易

```c#
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
```



总结：该示例的三份代码

```c#
// Program.cs

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
```



```c#
// BankAccount.cs
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace classes
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            
            MakeDeposit(initialBalance,DateTime.Now, "Initial balance");
        }

        private List<Transaction> allTransactions = new List<Transaction>();
        
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
```



```c#
// Transaction.cs
using System;

namespace classes
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
```



## 拓展类的使用

面向对象的编程中使用的四项关键技术：

- “抽象”是指将一组相关的属性、方法和其他成员视为一个单元或对象；
- “封装”是指堆类型使用者隐藏不必要的详细信息；
- “继承”描述基于现有类创建新类的能力；
- “多态性”意味着可以有多个可互换使用的类，即使每个类以不同方式实现相同属性或方法。



在上一节`BankAccount`类的基础上，进一步扩展。需求如下：

- 在每月的月末获得利息的红利账户；
- 余额可以为负，但存在余额时会产生每月利息的信用账户；
- 以单笔存款开户且只能用于支付的预付礼品卡账户。可在每月初重新充值一次。



重新写三个类：`InteresEarningAccount`,`LineOfCreditAccount`,`GiftCardAccount`


> 使用C#语言的难点在于不知道怎么利用.NET Core开发web应用。