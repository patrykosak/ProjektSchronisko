using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.AppData
{
    public class AnimalsContext:DbContext
    {
        public AnimalsContext(DbContextOptions<AnimalsContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
    }
}
