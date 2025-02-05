using System;
using System.Collections.Generic;

namespace Pitpmlab4.Database.ssms.models;

public partial class User
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long? UserRole { get; set; }

    public virtual UserRole? UserRoleNavigation { get; set; }
}
