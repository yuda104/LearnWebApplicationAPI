using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStore.EF
{
    public class BugsContext : DbContext
    {
        public BugsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

            //seeding
            modelBuilder.Entity<Project>().HasData(
                    new Project { ProjectId = 1, Name = "Project 1" },
                    new Project { ProjectId = 2, Name = "Project 2" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                    new Ticket
                    {
                        TicketId = 1,
                        Title = "Bug #1",
                        Description = "A new bug",
                        ProjectId = 1,
                        Owner = "Strange",
                        ReportDate = new DateTime(2022, 3, 21),
                        DueDate = new DateTime(2022, 3, 30)
                    },
                    new Ticket
                    {
                        TicketId = 2,
                        Title = "Bug #2",
                        Description = "Program exited immediately",
                        ProjectId = 1,
                        Owner = "Marvel",
                        ReportDate = new DateTime(2022, 3, 21),
                        DueDate = new DateTime(2022, 3, 30)
                    },
                    new Ticket { TicketId = 3, 
                        Title = "Bug #3", 
                        Description= "Couldn't click submit button",
                        ProjectId = 2,
                        Owner = "Strange",
                        ReportDate = new DateTime(2022, 3, 21),
                        DueDate = new DateTime(2022, 3, 30)
                    },
                    new Ticket { TicketId = 4, 
                        Title = "Another bug", 
                        Description = "Value didn't change properly", 
                        ProjectId = 2,
                        Owner = "Marvel",
                        ReportDate = new DateTime(2022, 3, 21),
                        DueDate = new DateTime(2022, 3, 30)
                    }
                );
        }
    }
}
