using System;
using System.Collections.Generic;

namespace CookingClassLibrary.Entities;

public partial class TblCredential
{
    public long CredentialsId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
