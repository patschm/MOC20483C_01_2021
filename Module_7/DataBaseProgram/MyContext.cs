using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseProgram
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions opts) : base(opts)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<PersonHobby> PersonHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(p => {
                p.Property(x => x.FirstName).HasMaxLength(1024);
                p.Property(x => x.LastName).HasMaxLength(1024);
            });

            modelBuilder.Entity<Hobby>(h => {
                h.Property(x => x.Description).HasMaxLength(2048);
            });

            modelBuilder.Entity<PersonHobby>(ph => {
                ph.HasKey(x => new { x.PersonID, x.HobbyID });
            });
        }

    }
}
