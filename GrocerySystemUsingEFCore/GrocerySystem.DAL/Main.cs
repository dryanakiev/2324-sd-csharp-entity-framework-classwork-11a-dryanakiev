using GrocerySystem.DAL.Data;
using GrocerySystem.DAL.Models;

namespace GrocerySystem.DAL;

public class Main
{
    public static void Main(string[] args)
    {
        LibraryContext context = new LibraryContext();

        Good good = new Good()
        {
            Name = "Banana",
            Weight = (decimal)5.50,
        };

        context.Add(good);

        context.SaveChanges();
    }
}