using System;
using System.Text;


public enum Level {
    Level1 = 1,
    Level2 = 2,
    Level3 = 3,
}


abstract class Employeer 
{
    public decimal Salary {get; set;}
    public int Coffee {get; set;}
    public int Reports {get; set;}
    public Level Rank {get; set;}

    public Employeer(decimal salary, int coffee, int reports, Level rank) {
        Salary = salary;
        Coffee = coffee;
        Reports = reports;
        Rank = rank;
    }

    public void updateSalaryRank(Level rank)
    {
        switch (rank) 
        {
            case Level.Level1:
                break;
            case Level.Level2:
                Salary *= (decimal)1.25;
                break;
            case Level.Level3:
                Salary *= (decimal)1.5;
                break;
        }
    }
    public virtual void Info() {
        Console.WriteLine($"Salary: {Salary}, Coffee: {Coffee}, Reports: {Reports} \n");
    }
}
 

class Manager : Employeer 
{
    public Manager (Level rank) : base (50_000, 20, 200, rank) 
    {
        updateSalaryRank(rank);
    }

    public override void Info() {
        Console.WriteLine($"Manager {Rank}");
        base.Info();
    }
}

class Marketing : Employeer 
{
    public Marketing (Level rank) : base (40_000, 15, 150, rank) 
    {
        updateSalaryRank(rank);
    }

    public override void Info() {
        Console.WriteLine($"Marketing {Rank}");
        base.Info();
    }
}


class Engineer : Employeer 
{
    public Engineer (Level rank) : base (20_000, 5, 50, rank) 
    {
        updateSalaryRank(rank);
    }
    public override void Info() {
        Console.WriteLine($"Engineer {Rank}");
        base.Info();
    }
}

class Analyst : Employeer 
{
    public Analyst (Level rank) : base (80_000, 50, 5, rank) 
    {
        updateSalaryRank(rank);
    }
    public override void Info() {
        Console.WriteLine($"Analyst {Rank}");
        base.Info();
    }
}


class Department 
{
    public string Name {get; init;}
    public Employeer[] Employeers {get; init;}
    public Leader Leader {get; init;}

    public Department(string name, Leader leader, Employeer[] employeers)
    {
        this.Name = name;
        this.Employeers = employeers;
        this.Leader = leader;
    }
    
    public void generateSalaryReport()
    {
        foreach (Employeer employeer in this.Employeers) {
            employeer.Info();
        }
    }
}


class SalaryReport
{
    public string[] columns = {"Департамент", "Сотрудников", "Тугрики", "Кофе", "Страницы", "Тугр./стр."};
    public int delimiterSpaces = 5;
    public int[] columnWidth = {};

    public void printHeader()
    {
        foreach (string column in columns) {
            Console.Write(column);
            columnWidth.Append(column.Length + 5);
            for (int j = 0; j < delimiterSpaces; j++) {
                Console.Write(" ");
            }
        }

    }
}

class Leader
{
    public decimal Salary;
    public int Coffee;
    public int Report = 0;

    public Leader(Employeer employeer)
    {
        Salary = employeer.Salary * (decimal) 1.5;
        Coffee = (int) (employeer.Coffee * 1.5);
    }

    public virtual void Info() {
        Console.WriteLine($"Salary: {Salary}, Coffee: {Coffee}, Reports: {Report} \n");
    }
}


public class Accounting 
{
    public static void Main(string[] args)
    {
        
        Manager manager = new Manager(Level.Level1);
        Marketing marketer = new Marketing(Level.Level2);
        Engineer engineer = new Engineer(Level.Level3);
        Analyst analyst = new Analyst(Level.Level3);

        Leader leaderManager = new Leader(manager);

        Employeer[] employeers = {manager, marketer, engineer, analyst};
        Department accounting = new Department("Accounting", new Leader(manager), employeers);
        accounting.generateSalaryReport();
        leaderManager.Info();


        string[] columns = {"Департамент", "Сотрудников", "Тугрики", "Кофе", "Страницы", "Тугр./стр."};
        string[,] data = {
            { "1", "Alice", "30" },
            { "2", "Bob", "25" },
            { "3", "Charlie", "35" },
        };

        StringBuilder table = new StringBuilder();
        // Create header
        foreach (var header in columns)
        {
            table.Append(header.PadRight(15));  // Adjust the padding to fit your data
        }
        table.AppendLine();
        table.Append('-', 90);
        table.AppendLine();

        // Create rows
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                table.Append(data[i, j].PadRight(15));  // Ensure each column is aligned
            }
            table.AppendLine();
        }
        table.Append('-', 90);
        table.AppendLine();

        Console.WriteLine(table.ToString());
    }
}