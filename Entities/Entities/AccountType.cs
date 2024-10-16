using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class AccountType
{
    public int AccountTypeId { get; set; }

    public string AccountTypeName { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
