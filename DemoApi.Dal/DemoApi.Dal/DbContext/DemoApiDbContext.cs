using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Dal
{
    public class DemoApiDbContext : DbContext
    {
        public DemoApiDbContext(DbContextOptions<DemoApiDbContext> option) : base(option)
        {

        }
        public DbSet<UserModel> UserModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserModelEntityConfiguration());
        }

        }
    }
