using System;

using R5T.Sparta;

using AppType = R5T.Dufftown.OriginalFileNameMapping;
using EntityType = R5T.Dufftown.Database.Entities.OriginalFileNameMapping;


namespace R5T.Dufftown.Database
{
    public static class OriginalFileNameMappingExtensions
    {
        public static AppType ToAppType(this EntityType entityType)
        {
            var appType = new AppType()
            {
                UniqueFileName = FileName.New(entityType.UniqueFileName),
                OriginalFileName = FileName.New(entityType.OriginalFileName),
            };

            return appType;
        }

        public static EntityType ToEntityType(this AppType appType)
        {
            var entityType = new EntityType()
            {
                UniqueFileName = appType.UniqueFileName.Value,
                OriginalFileName = appType.OriginalFileName.Value,
            };

            return entityType;
        }
    }
}
