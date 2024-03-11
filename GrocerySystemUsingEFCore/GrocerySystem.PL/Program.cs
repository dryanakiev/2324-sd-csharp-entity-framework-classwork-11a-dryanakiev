using GrocerySystem.DAL.Data;
using GrocerySystem.DAL.Models;

namespace GrocerySystem.PL;

class Program
{
    public static void Main(string[] args)
    {
        GroceryContext context = new GroceryContext();

        Console.WriteLine("----------------------GOODS----------------------");
        foreach (Good good in context.Goods)
        {
            Console.WriteLine($"Good Id: {good.Id}\nGood name: {good.Name}\nGood weight: {good.Weight}");
        }
    }
}