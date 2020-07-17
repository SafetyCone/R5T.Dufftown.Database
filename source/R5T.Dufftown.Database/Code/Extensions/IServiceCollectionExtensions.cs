using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using R5T.Dacia;


namespace R5T.Dufftown.Database
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DatabaseOriginalFileNameMappingRepository{TDbContext}"/> implementation of <see cref="IOriginalFileNameMappingRepository"/> as a <see cref="ServiceLifetime.Singleton"/>.s
        /// </summary>
        public static IServiceCollection AddDatabaseOriginalFileNameMappingRepository<TDbContext>(this IServiceCollection services)
            where TDbContext: DbContext, IOriginalFileNameMappingDbContext
        {
            services.AddSingleton<IOriginalFileNameMappingRepository, DatabaseOriginalFileNameMappingRepository<TDbContext>>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DatabaseOriginalFileNameMappingRepository{TDbContext}"/> implementation of <see cref="IOriginalFileNameMappingRepository"/> as a <see cref="ServiceLifetime.Singleton"/>.s
        /// </summary>
        public static IServiceAction<IOriginalFileNameMappingRepository> AddDatabaseOriginalFileNameMappingRepositoryAction<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext, IOriginalFileNameMappingDbContext
        {
            var serviceAction = ServiceAction.New<IOriginalFileNameMappingRepository>(() => services.AddDatabaseOriginalFileNameMappingRepository<TDbContext>());
            return serviceAction;
        }
    }
}
