using System;
using System.Collections.Generic;

namespace ASPDotnetWebApplication.Models;

public partial class Guide
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? JoiningDate { get; set; }

    public byte[]? Photo { get; set; }

    public string? Profession { get; set; }

    public virtual ICollection<GuideEvent> GuideEvents { get; set; } = new List<GuideEvent>();

    public virtual ICollection<GuideMember> GuideMembers { get; set; } = new List<GuideMember>();
}
