using System;
using System.Collections.Generic;

namespace colol2.Models;

public partial class User
{
    public int Id { get; set; }

    public int GenderId { get; set; }

    public DateOnly Birthday { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual LoginUser IdNavigation { get; set; } = null!;
}
