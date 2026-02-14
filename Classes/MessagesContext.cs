using ChatStudentsShashin.Classes.Common;
using ChatStudentsShashin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatStudentsShashin.Classes
{
    public class MessagesContext : DbContext
    {
        public DbSet<Messages> Messages { get; set; }
        public MessagesContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Config.config);
    }
}
