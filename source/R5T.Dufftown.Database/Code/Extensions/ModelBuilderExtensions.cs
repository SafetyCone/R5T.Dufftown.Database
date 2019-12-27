using System;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dufftown.Database
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ForOriginalFileNameMappingDbContext(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.OriginalFileNameMapping>().HasAlternateKey(x => x.UniqueFileName);

            return modelBuilder;
        }
    }
}
