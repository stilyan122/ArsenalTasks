﻿using System;
using System.Collections.Generic;

namespace ConstructionMaterialsDBOOP.Data.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
