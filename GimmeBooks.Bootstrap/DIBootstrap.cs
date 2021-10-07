using $ext_projectname$.Data.Contexts;
using $ext_projectname$.DI;
using $ext_projectname$.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$
{
    public static class DIBootstrap
    {
        public static void RegisterTypes(IServiceCollection service)
        {
            service.RegisterAppServices()
                .RegisterAppBusiness()
                .RegisterServices()
                .RegisterAppPersistence();

            AppContainer.SetContainer(service);
            AutoMapperConfiguration.Register();

            Migrate(service);
        }
        
        public static void RegisterTypesTest(IServiceCollection service)
        {
            service.RegisterAppServices()
                .RegisterAppBusiness()
                .RegisterServices()
                .RegisterAppPersistenceTest();

            AppContainer.SetContainer(service);
            AutoMapperConfiguration.Register();
        }

        private static void Migrate(IServiceCollection services)
        {
            var dao = services.BuildServiceProvider().GetService<AppDbContext>();
            dao.Database.EnsureCreated();
            //dao.Database.Migrate();
        }
    }
}