﻿using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using R5T.Sparta;
using R5T.Venetia;


namespace R5T.Dufftown.Database
{
    public class DatabaseOriginalFileNameMappingRepository : DatabaseRepositoryBase<OriginalFileNameMappingDbContext>, IOriginalFileNameMappingRepository
    {
        public DatabaseOriginalFileNameMappingRepository(DbContextOptions<OriginalFileNameMappingDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public override OriginalFileNameMappingDbContext GetNewDbContext()
        {
            var dbContext = new OriginalFileNameMappingDbContext(this.DbContextOptions);
            return dbContext;
        }

        public void Add(OriginalFileNameMapping mapping)
        {
            var mappingEntity = mapping.ToEntityType();

            using (var dbContext = this.GetNewDbContext())
            {
                dbContext.OriginalFileNameMappings.Add(mappingEntity);

                dbContext.SaveChanges();
            }
        }

        public void Delete(FileName uniqueFileName)
        {
            using (var dbContext = this.GetNewDbContext())
            {
                var entity = dbContext.OriginalFileNameMappings.Where(x => x.UniqueFileName == uniqueFileName.Value).Single();

                dbContext.Remove(entity);

                dbContext.SaveChanges();
            }   
        }

        public bool Exists(FileName uniqueFileName)
        {
            using (var dbContext = this.GetNewDbContext())
            {
                var entityOrDefault = dbContext.OriginalFileNameMappings.Where(x => x.UniqueFileName == uniqueFileName.Value).SingleOrDefault();

                var output = entityOrDefault == default;
                return output;
            }
        }

        public OriginalFileNameMapping Get(FileName uniqueFileName)
        {
            using (var dbContext = this.GetNewDbContext())
            {
                var entity = dbContext.OriginalFileNameMappings.Where(x => x.UniqueFileName == uniqueFileName.Value).Single();

                var appType = entity.ToAppType();
                return appType;
            }
        }
    }
}