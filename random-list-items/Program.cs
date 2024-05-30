using System;
using System.Collections.Generic;


public class RandomTypes 
{
    public static void Main(string[] args)
    {
        var res = GetList(3);
        for (int i = 0; i < res.Count; i++)
        {
            Console.WriteLine(res[i]);
        }
    }
    static List<object> GetList(int n)
    {
        List<object> resList = new List<object>();
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            int typeNum = random.Next(4);
            switch (typeNum)
            {
                case 0:
                    resList.Add(random.Next(1, 100));
                    break;
                case 1:
                    resList.Add(random.NextDouble() * 100.00);
                    break;
                case 2:
                    String randString = "";
                    for (int j = 0; j < n; j++) 
                    {
                        randString += (char)random.Next(65, 90);
                    }
                    resList.Add(randString);
                    break;
                case 3:
                    resList.Add(random.Next(2) == 1);
                    break;
                default:
                    break;
            }
        }
        return resList;
    }
}
