﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Security.Models;
using System;
using System.Collections.Generic;
using System.Text;
using NewCoEF.Security.Areas.Admin.Models;

namespace NewCoEF.Security.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUserRoles> ApplicationUserRoles { get; set; }

    }
}
