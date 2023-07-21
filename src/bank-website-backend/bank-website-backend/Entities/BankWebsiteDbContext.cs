using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bank_website_backend.Entities;

public partial class BankWebsiteDbContext : IdentityDbContext<TUser, Role, string>
{

    public BankWebsiteDbContext(DbContextOptions<BankWebsiteDbContext> options): base(options) { }


}
