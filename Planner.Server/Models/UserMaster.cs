using System;
using System.Collections.Generic;

namespace Planner.Server.Models;

public partial class UserMaster
{
    public long UmUserId { get; set; }

    public string? UmEmail { get; set; }

    public string? UmFirstName { get; set; }

    public string? UmLastName { get; set; }

    public bool? UmIsActive { get; set; }

    public DateTime? UmCreatedOn { get; set; }

    public DateTime? UmModifiedOn { get; set; }

    public virtual TaskDetail? TaskDetail { get; set; }
}
