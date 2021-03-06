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
        public DbSet<ReportAnimal> ReportAnimal { get; set; }
        public DbSet<WorkHours> WorkHours { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
}
