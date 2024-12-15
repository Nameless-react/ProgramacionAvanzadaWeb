using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Client
{
    public int ClientId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; }

    public virtual ICollection<AccessReport> AccessReports { get; set; } = new List<AccessReport>();

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
