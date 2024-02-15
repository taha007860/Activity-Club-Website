using System;
using System.Collections.Generic;

namespace ASPDotnetWebApplication.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Destination { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public decimal? Cost { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<EventMember> EventMembers { get; set; } = new List<EventMember>();

    public virtual ICollection<GuideEvent> GuideEvents { get; set; } = new List<GuideEvent>();
}
