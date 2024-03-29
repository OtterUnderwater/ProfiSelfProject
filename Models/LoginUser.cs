﻿using System;
using System.Collections.Generic;

namespace colol2.Models;

public partial class LoginUser
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual User? User { get; set; }
}
