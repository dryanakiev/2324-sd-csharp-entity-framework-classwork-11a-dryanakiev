using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrocerySystem.DAL.Models;

public partial class Grocery
{
    [Key]
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int GoodsId { get; set; }

    public int ShoppersId { get; set; }

    [ForeignKey("GoodsId")]
    [InverseProperty("Groceries")]
    public virtual Good Goods { get; set; } = null!;

    [ForeignKey("ShoppersId")]
    [InverseProperty("Groceries")]
    public virtual Shopper Shoppers { get; set; } = null!;
}
