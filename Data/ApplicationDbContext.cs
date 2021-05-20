using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektSchronisko.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VolunteerUser> ApplicationUser { get; set; }
    }
}
