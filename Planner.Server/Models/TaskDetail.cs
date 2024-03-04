using System;
using System.Collections.Generic;

namespace Planner.Server.Models;

public partial class TaskDetail
{
    public long TdTaskId { get; set; }

    public long TdUmUserId { get; set; }

    public string? TdTitle { get; set; }

    public string? TdDescription { get; set; }

    public string? TdProgress { get; set; }

    public DateTime? TdStartDate { get; set; }

    public DateTime? TdDueDate { get; set; }

    public DateTime? TdCreatedDate { get; set; }

    public DateTime? TdModifiedDate { get; set; }

    public virtual UserMaster TdTask { get; set; } = null!;
}
