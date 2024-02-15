using System;
using System.Collections.Generic;

namespace ASPDotnetWebApplication.Models;

public partial class Member
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? MobileNumber { get; set; }

    public string? EmergencyNumber { get; set; }

    public byte[]? Photo { get; set; }

    public string? Profession { get; set; }

    public string? Nationality { get; set; }

    public virtual ICollection<EventMember> EventMembers { get; set; } = new List<EventMember>();

    public virtual ICollection<GuideMember> GuideMembers { get; set; } = new List<GuideMember>();
}
