using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Seeders
{
    public class AnimalSeeder
    {
        private readonly AnimalsContext _animalsDbContext;
        public AnimalSeeder(AnimalsContext animalsDbContext)
        {
            _animalsDbContext = animalsDbContext;
        }
        
        //public void Seed()
        //{
        //    if (_animalsDbContext.Database.CanConnect())
        //    {
        //        AutoMigration();

        //        if (!_animalsDbContext.Animals.Any())
        //        {
        //            var animals = GetAnimals();
        //            _animalsDbContext.Animals.AddRange(animals);
        //            _animalsDbContext.SaveChanges();
        //        }
        //    }
        //}

        //private void AutoMigration()
        //{
        //    var pendingMigrations = _animalsDbContext.Database.GetPendingMigrations();
        //    if (pendingMigrations != null && pendingMigrations.Any())
        //        _animalsDbContext.Database.Migrate();
        //}

        private IEnumerable<Animal> GetAnimals()
        {
            var animals = new List<Animal>()
            {
                new Animal()
                {
                    Name = "Pipek",
                    TypeAnimale = TypeAnimal.Dog,
                    AgeAnimal = Age.Months612,
                    RaceAnimal = Race.GermanShepherd,
                    AddDate = DateTime.UtcNow,
                    PhotoPath = "/Images/20210512_135535.jpg"
                },
                new Animal()
                {
                    Name = "Tymek",
                    TypeAnimale = TypeAnimal.Cat,
                    AgeAnimal = Age.Year,
                    RaceAnimal = Race.Dachshund,
                    AddDate = DateTime.UtcNow,
                    PhotoPath = "/Images/20210512_135547.jpg"
                },
                new Animal()
                {
                    Name = "Coco",
                    TypeAnimale = TypeAnimal.Other,
                    AgeAnimal = Age.Older,
                    RaceAnimal = Race.Other,
                    AddDate = DateTime.UtcNow,
                    PhotoPath = "/Images/20210410_105623.jpg"
                }
            };
            return animals;
        }
    }
}
