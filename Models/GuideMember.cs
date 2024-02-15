using System;
using System.Collections.Generic;

namespace ASPDotnetWebApplication.Models;

public partial class GuideMember
{
    public int Id { get; set; }

    public int? GuideId { get; set; }

    public int? MemberId { get; set; }

    public virtual Guide? Guide { get; set; }

    public virtual Member? Member { get; set; }
}
