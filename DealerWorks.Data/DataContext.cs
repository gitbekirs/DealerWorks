
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerWorks.Data
{

    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
        {

        }

        //public DataContext() 
        //{
        //}

        //public DataContext(DbContextOptions<DataContext> options) : base(options)
        //{
        //}




        public DbSet<Model.Kategori> Kategoris { get; set; }
        public DbSet<Model.Marka> Markas { get; set; }
        public DbSet<Model.Model> Models { get; set; }
        public DbSet<Model.Urun> Uruns { get; set; }
        public DbSet<Model.UrunFiyat> UrunFiyats { get; set; }
        public DbSet<Model.UrunGorsel> UrunGorsels { get; set; }
        public DbSet<Model.Setting> Setting { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Model.Kategori>(entity => entity.ToTable("t9_Kategori"));
            builder.Entity<Model.Marka>(entity => entity.ToTable("t9_Marka"));
            builder.Entity<Model.Model>(entity => entity.ToTable("t9_Model"));
            builder.Entity<Model.Urun>(entity => entity.ToTable("t9_Urun"));
            builder.Entity<Model.UrunFiyat>(entity => entity.ToTable("t9_UrunFiyat"));
            builder.Entity<Model.UrunGorsel>(entity => entity.ToTable("t9_UrunGorsel"));
            builder.Entity<Model.Setting>(entity => entity.ToTable("t9_Setting"));

        }



    }
}
