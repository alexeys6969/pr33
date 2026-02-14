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
    public class UserContext : DbContext
    {
        public DbSet<User> Users {  get; set; }
        public UserContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Config.config);
    }
}
