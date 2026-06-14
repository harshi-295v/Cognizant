// SRP 

class Student {
    private int id;
    private String name;

    public Student(int id, String name) {
        this.id = id;
        this.name = name;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }
}

class StudentRepository {

    public void save(Student student) {
        System.out.println("Student saved successfully.");
    }
}

class StudentReportGenerator {

    public void generateReport(Student student) {
        System.out.println("Student Report");
        System.out.println("ID   : " + student.getId());
        System.out.println("Name : " + student.getName());
    }
}

//  OCP 

interface CalculatorOperation {
    double perform(double a, double b);
}

class Addition implements CalculatorOperation {

    @Override
    public double perform(double a, double b) {
        return a + b;
    }
}

class Subtraction implements CalculatorOperation {

    @Override
    public double perform(double a, double b) {
        return a - b;
    }
}

class Multiplication implements CalculatorOperation {

    @Override
    public double perform(double a, double b) {
        return a * b;
    }
}

class Calculator {

    public void calculate(CalculatorOperation operation,
                          double a,
                          double b) {

        System.out.println("Result = " +
                operation.perform(a, b));
    }
}

//  LSP 

abstract class WithdrawableAccount {

    protected double balance;

    public WithdrawableAccount(double balance) {
        this.balance = balance;
    }

    public abstract void withdraw(double amount);

    public double getBalance() {
        return balance;
    }
}

class SavingsAccount extends WithdrawableAccount {

    public SavingsAccount(double balance) {
        super(balance);
    }

    @Override
    public void withdraw(double amount) {
        balance -= amount;
        System.out.println("Savings Account Withdraw: " + amount);
    }
}

class CurrentAccount extends WithdrawableAccount {

    public CurrentAccount(double balance) {
        super(balance);
    }

    @Override
    public void withdraw(double amount) {
        balance -= amount;
        System.out.println("Current Account Withdraw: " + amount);
    }
}

class BankingService {

    public void processWithdrawal(WithdrawableAccount account,
                                  double amount) {

        account.withdraw(amount);

        System.out.println("Remaining Balance: "
                + account.getBalance());
    }
}

//  MAIN 

public class SolidPrinciplesPractice {

    public static void main(String[] args) {

        System.out.println("===== SRP =====");

        Student student = new Student(101, "Harshitha");

        StudentRepository repository = new StudentRepository();
        StudentReportGenerator report = new StudentReportGenerator();

        repository.save(student);
        report.generateReport(student);

        System.out.println("\n===== OCP =====");

        Calculator calculator = new Calculator();

        calculator.calculate(new Addition(), 10, 5);
        calculator.calculate(new Subtraction(), 10, 5);
        calculator.calculate(new Multiplication(), 10, 5);

        System.out.println("\n===== LSP =====");

        BankingService service = new BankingService();

        WithdrawableAccount savings =
                new SavingsAccount(10000);

        WithdrawableAccount current =
                new CurrentAccount(15000);

        service.processWithdrawal(savings, 2000);

        System.out.println();

        service.processWithdrawal(current, 3000);
    }
}