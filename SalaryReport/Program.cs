
public enum Level {
    Level1 = 1,
    Level2 = 2,
    Level3 = 3,
}


abstract class Employeers 
{
    public decimal Salary {get; set;}
    public int Coffee {get; set;}
    public int Reports {get; set;}
    // public Level Rank {get; set;}

    public Employeers(int salary, int coffee, int reports) {
        Salary = salary;
        Coffee = coffee;
        Reports = reports;
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
}
 

class Manager : Employeers 
{
    public Manager (Level rank) : base (50_000, 20, 200) 
    {
        updateSalaryRank(rank);
    }
}

class Marketing : Employeers 
{
    public Marketing (Level rank) : base (40_000, 15, 150) 
    {
        updateSalaryRank(rank);
    }
}


class Engineer : Employeers 
{
    public Engineer (Level rank) : base (20_000, 5, 50) 
    {
        updateSalaryRank(rank);
    }
}

class Analyst : Employeers 
{
    public Analyst (Level rank) : base (80_000, 50, 5) 
    {
        updateSalaryRank(rank);
    }
}


class SalaryReport 
{
    public Employeers[] department {get; init;}
    
    public void generateReport()
    {
        Console.WriteLine("");
    }
}

class Leader 
{
    public Employeers employeers {get; init;}

    public Leader(Employeers employeers)
    {
        this.employeers = employeers;
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
        // Leader leaderManager = new Leader(manager);

        Console.WriteLine($"engineer Salary: {engineer.Salary}");
        // Console.WriteLine($"Leader Manager Salary: {leaderManager.Salary}");
    }
}