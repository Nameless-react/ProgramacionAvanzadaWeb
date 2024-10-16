using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int OriginAccountId { get; set; }

    public int DestinationAccountId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public virtual Account DestinationAccount { get; set; } = null!;

    public virtual Account OriginAccount { get; set; } = null!;
}
