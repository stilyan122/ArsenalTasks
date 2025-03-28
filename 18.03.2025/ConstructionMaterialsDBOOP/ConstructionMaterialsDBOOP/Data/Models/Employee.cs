﻿using System;
using System.Collections.Generic;

namespace ConstructionMaterialsDBOOP.Data.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;
}
