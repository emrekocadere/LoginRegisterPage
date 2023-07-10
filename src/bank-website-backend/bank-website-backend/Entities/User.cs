using System;
using System.Collections.Generic;

namespace bank_website_backend.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }
}
