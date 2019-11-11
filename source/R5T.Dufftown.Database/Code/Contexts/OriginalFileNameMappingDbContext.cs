using System;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dufftown.Database
{
    public class OriginalFileNameMappingDbContext : DbContext
    {
        public DbSet<Entities.OriginalFileNameMapping> OriginalFileNameMappings { get; set; }


        public OriginalFileNameMappingDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.OriginalFileNameMapping>().HasAlternateKey(x => x.UniqueFileName);
        }
    }
}
