using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Dal
{
   public class UserModel
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Addresses { get; set; }
    }


    public class UserModelEntityConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasColumnName("FirstName").HasColumnType("character varying");
            builder.Property(p => p.LastName).HasColumnName("LastName").HasColumnType("character varying");
            builder.Property(p => p.Sex).HasColumnName("Sex").HasColumnType("character varying");
            builder.Property(p => p.Addresses).HasColumnName("Addresses").HasColumnType("character varying");



            builder.ToTable("User", "public");
        }
    }
}
