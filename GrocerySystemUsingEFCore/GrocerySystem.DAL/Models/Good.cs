using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrocerySystem.DAL.Models;

public partial class Good
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Weight { get; set; }

    [InverseProperty("Goods")]
    public virtual ICollection<Grocery> Groceries { get; set; } = new List<Grocery>();
}
