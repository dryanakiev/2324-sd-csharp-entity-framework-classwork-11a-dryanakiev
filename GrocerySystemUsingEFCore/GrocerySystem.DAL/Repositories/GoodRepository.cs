using GrocerySystem.DAL.Data;
using GrocerySystem.DAL.Models;

namespace GrocerySystem.DAL.Repositories;

public class GoodRepository
{
    private static GroceryContext context = new GroceryContext();

    public List<Good> GetAllGoods()
    {
        return context.Goods.ToList();
    }

    public Good GetGoodByName(string name)
    {
        // Query syntax
        // var queryGood =
        //     from good in context.Goods
        //     where good.Name == name
        //     select good;
        //
        // return queryGood as Good;
        
        // Method syntax
        return context.Goods.FirstOrDefault(x => x.Name == name)!;
    }

    public void AddGood(Good newGood)
    {
        context.Goods.Add(newGood);

        context.SaveChanges();
    }

    public void UpdateGood(Good newGood)
    {
        context.Goods.Update(newGood);

        context.SaveChanges();
    }
    
    public void DeleteGood(Good good)
    {
        context.Goods.Remove(good);

        context.SaveChanges();
    }
}