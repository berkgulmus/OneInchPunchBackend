using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DataLayer
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Deparment> Deparments { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<UserManager> UserManagers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<IssueLog> IssueLogs { get; set; }
    }
}
