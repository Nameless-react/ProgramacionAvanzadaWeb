using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Client
{
    public int ClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<AccessReport> AccessReports { get; set; } = new List<AccessReport>();

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
