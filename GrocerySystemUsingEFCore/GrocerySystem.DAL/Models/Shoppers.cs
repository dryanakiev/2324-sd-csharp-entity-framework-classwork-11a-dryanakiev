using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrocerySystem.DAL.Models;

public partial class Shoppers
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Phone { get; set; } = null!;

    [InverseProperty("Shoppers")]
    public virtual ICollection<Groceries> Groceries { get; set; } = new List<Groceries>();
}
