using System;
using System.Collections.Generic;

namespace Pitpmlab4.Database.ssms.models;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Cost { get; set; }

    public string ImagePath { get; set; } = null!;
}
