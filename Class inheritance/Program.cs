using System;

public class Viewer : Order
{

    public Viewer (ViewerType type, int ordersCount, int curOrderCount, double price) : 
        base(ViewerType.viewer, ordersCount, curOrderCount, price) {}


    public override double calcTotal () {
        double total = curOrderCount * price;
        return total;
    }
}

public class Regular : Order
{
    public Regular (ViewerType type, int ordersCount, int curOrderCount, double price) : 
        base(ViewerType.regular, ordersCount, curOrderCount, price) {}


    public override double calcTotal () 
    {
        int DiscountStep = 10;
        int MaxDiscount = 20; 
        double totalCost = 0;
        int currentVisit = ordersCount + 1;
        for (int i = 0; i < curOrderCount; i++)
        {
            int currentDiscountPercentage = Math.Min((currentVisit / DiscountStep), MaxDiscount);
            double discount = (currentDiscountPercentage / 100.0) * price;
            double priceAfterDiscount = price - discount;
            totalCost += priceAfterDiscount;

            currentVisit++;
        }

        return totalCost;
    }

}


public class Student : Order
{
    public Student (ViewerType type, int ordersCount, int curOrderCount, double price) : 
        base(ViewerType.student, ordersCount, curOrderCount, price) {}


    public override double calcTotal () {
        int countDiscount = (ordersCount % 3 + curOrderCount) / 3;
        double total = countDiscount * price * 0.5 + (curOrderCount-countDiscount) * price;
        return total;
    }
}

public class Pensioner : Order
{
    public Pensioner (ViewerType type, int ordersCount, int curOrderCount, double price) : 
        base(ViewerType.student, ordersCount, curOrderCount, price) {}


    public override double calcTotal () {
        int countDiscount = (ordersCount % 5 + curOrderCount) / 5;
        double total = Math.Round((curOrderCount-countDiscount) * price) *  0.5;
        return total;
    }
}


public enum ViewerType
{
    student,
    pensioner,
    viewer,
    regular
}


public class Order
{
    public int ordersCount {get;}
    public int curOrderCount {get;}
    public double price {get;}
    public ViewerType viewerType {get;}

    public Order(ViewerType viewerType, int ordersCount, int curOrderCount, double price)
    {
        this.viewerType = viewerType;
        this.ordersCount = ordersCount;
        this.curOrderCount = curOrderCount;
        this.price = price;
    }

    public virtual double calcTotal() {
        return 0;
    }

}


public static class OrderFactory
{
    public static Order CreateOrder (ViewerType type, int ordersCount, int curOrderCount, double price)
    {
        switch (type)
        {
            case ViewerType.student:
                return new Student(type, ordersCount, curOrderCount, price);
            case ViewerType.pensioner:
                return new Pensioner(type, ordersCount, curOrderCount, price);
            case ViewerType.viewer:
                return new Viewer(type, ordersCount, curOrderCount, price);
            case ViewerType.regular:
                return new Regular(type, ordersCount, curOrderCount, price);
            default:
                throw new NotImplementedException();
        }
    }
}


public class MainClass
{
    public static void Main(string[] args)
    {

        var testCases = new string[] {
            "regular 28 100 2", // 195
            "regular 28 100 12", // 1164
            "regular 300 100 1", // 80
            "regular 198 100 2", // 161
            "viewer 28 100 4", // 400
            "student 28 100 2",
            "student 28 100.225 2",
            "student 28 100 3",
            "student 28 100 6",
            "pensioner 28 100 4",
            "pensioner 28 100 7",
            "pensioner 28 100 8"
        };
        foreach (string input in testCases){

        string[] inData = input.Split(" ");

        var ordersCount = int.Parse(inData[1]);
        var curOrderCount = int.Parse(inData[3]);
        var price = Math.Round(double.Parse(inData[2]), 2);

        if (!Enum.TryParse(inData[0], out ViewerType type)) 
            throw new ArgumentException("Invalid value for ViewerType");

        Order order = OrderFactory.CreateOrder(type, ordersCount, curOrderCount, price);
        double total = order.calcTotal();
        Console.WriteLine(Math.Round(total, 2));
        }
    }
}

// regular 28 100 2 //195
// regular 300 100 1 //80
// regular 198 100 2 // 161
// viewer 28 100 4 //400

// student 28 100 2 //150
// student 28 100.225 2 //150.34
// student 28 100 3 //250
// student 28 100 6 //500

// pensioner 28 100 4 //150
// pensioner 28 100 7 //250
// pensioner 28 100 8 //300



