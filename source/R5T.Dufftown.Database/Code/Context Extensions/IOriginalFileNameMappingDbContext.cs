using System;

using Microsoft.EntityFrameworkCore;


namespace R5T.Dufftown.Database
{
    public interface IOriginalFileNameMappingDbContext
    {
        DbSet<Entities.OriginalFileNameMapping> OriginalFileNameMappings { get; }
    }
}
