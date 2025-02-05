using System;
using System.Collections.Generic;

namespace Pitpmlab4.Database.ssms.models;

public partial class UserRole
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
