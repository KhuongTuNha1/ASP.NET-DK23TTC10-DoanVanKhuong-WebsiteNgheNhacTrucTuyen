using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseProvider
{
    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<casi> casis { get; set; }
        public virtual DbSet<chude> chudes { get; set; }
        public virtual DbSet<nhac> nhacs { get; set; }
        public virtual DbSet<playlist> playlists { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }
        public virtual DbSet<taikhoan> taikhoans { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<playlist>()
                .Property(e => e.TenPL)
                .IsFixedLength();

            modelBuilder.Entity<playlist>()
                .Property(e => e.MaPL)
                .IsFixedLength();
        }
    }
}
