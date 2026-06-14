using System;

// ==================== SRP ====================

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class StudentRepository
{
    public void Save(Student student)
    {
        Console.WriteLine("Student saved successfully.");
    }
}

class StudentReportGenerator
{
    public void GenerateReport(Student student)
    {
        Console.WriteLine("Student Report");
        Console.WriteLine($"ID   : {student.Id}");
        Console.WriteLine($"Name : {student.Name}");
    }
}

// ==================== OCP ====================

interface ICalculatorOperation
{
    double Perform(double a, double b);
}

class Addition : ICalculatorOperation
{
    public double Perform(double a, double b)
    {
        return a + b;
    }
}

class Subtraction : ICalculatorOperation
{
    public double Perform(double a, double b)
    {
        return a - b;
    }
}

class Multiplication : ICalculatorOperation
{
    public double Perform(double a, double b)
    {
        return a * b;
    }
}

class Calculator
{
    public void Calculate(ICalculatorOperation operation,
                          double a,
                          double b)
    {
        Console.WriteLine("Result = " + operation.Perform(a, b));
    }
}

// ==================== LSP ====================

abstract class WithdrawableAccount
{
    protected double balance;

    public WithdrawableAccount(double balance)
    {
        this.balance = balance;
    }

    public abstract void Withdraw(double amount);

    public double GetBalance()
    {
        return balance;
    }
}

class SavingsAccount : WithdrawableAccount
{
    public SavingsAccount(double balance) : base(balance) { }

    public override void Withdraw(double amount)
    {
        balance -= amount;
        Console.WriteLine("Savings Account Withdraw: " + amount);
    }
}

class CurrentAccount : WithdrawableAccount
{
    public CurrentAccount(double balance) : base(balance) { }

    public override void Withdraw(double amount)
    {
        balance -= amount;
        Console.WriteLine("Current Account Withdraw: " + amount);
    }
}

class BankingService
{
    public void ProcessWithdrawal(WithdrawableAccount account,
                                  double amount)
    {
        account.Withdraw(amount);
        Console.WriteLine("Remaining Balance: " +
                          account.GetBalance());
    }
}

// ==================== MAIN ====================

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== SRP =====");

        Student student = new Student(101, "Harshitha");

        StudentRepository repository = new StudentRepository();
        StudentReportGenerator report = new StudentReportGenerator();

        repository.Save(student);
        report.GenerateReport(student);

        Console.WriteLine("\n===== OCP =====");

        Calculator calculator = new Calculator();

        calculator.Calculate(new Addition(), 10, 5);
        calculator.Calculate(new Subtraction(), 10, 5);
        calculator.Calculate(new Multiplication(), 10, 5);

        Console.WriteLine("\n===== LSP =====");

        BankingService service = new BankingService();

        WithdrawableAccount savings =
            new SavingsAccount(10000);

        WithdrawableAccount current =
            new CurrentAccount(15000);

        service.ProcessWithdrawal(savings, 2000);

        Console.WriteLine();

        service.ProcessWithdrawal(current, 3000);
    }
}