using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class AccessReport
{
    public int AccessReportId { get; set; }

    public int ClientId { get; set; }

    public DateTime? AccessDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool? Success { get; set; }

    public string? AccessDescription { get; set; }

    public virtual Client Client { get; set; } = null!;
}
