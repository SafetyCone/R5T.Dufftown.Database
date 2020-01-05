using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.Sparta;
using R5T.Venetia;


namespace R5T.Dufftown.Database
{
    public class DatabaseOriginalFileNameMappingRepository<TDbContext> : ProvidedDatabaseRepositoryBase<TDbContext>, IOriginalFileNameMappingRepository
        where TDbContext: DbContext, IOriginalFileNameMappingDbContext
    {
        public DatabaseOriginalFileNameMappingRepository(DbContextOptions<TDbContext> dbContextOptions, IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextOptions, dbContextProvider)
        {
        }

        public async Task Add(OriginalFileNameMapping mapping)
        {
            var mappingEntity = mapping.ToEntityType();

            await this.ExecuteInContextAsync(async dbContext =>
            {
                dbContext.OriginalFileNameMappings.Add(mappingEntity);

                await dbContext.SaveChangesAsync();
            });
        }

        public async Task Delete(FileName uniqueFileName)
        {
            await this.ExecuteInContextAsync(async dbContext =>
            {
                var entity = await dbContext.OriginalFileNameMappings.Where(x => x.UniqueFileName == uniqueFileName.Value).SingleAsync();

                dbContext.Remove(entity);

                await dbContext.SaveChangesAsync();
            });
        }

        public async Task<bool> Exists(FileName uniqueFileName)
        {
            var exists = await this.ExecuteInContextAsync(async dbContext =>
            {
                var entityOrDefault = await dbContext.OriginalFileNameMappings.Where(x => x.UniqueFileName == uniqueFileName.Value).SingleOrDefaultAsync();

                var output = entityOrDefault == default;
                return output;
            });

            return exists;
        }

        public async Task<OriginalFileNameMapping> Get(FileName uniqueFileName)
        {
            var originalFileNameMapping = await this.ExecuteInContextAsync(async dbContext =>
            {
                var entity = await dbContext.OriginalFileNameMappings.Where(x => x.UniqueFileName == uniqueFileName.Value).SingleAsync();

                var appType = entity.ToAppType();
                return appType;
            });

            return originalFileNameMapping;
        }
    }
}
