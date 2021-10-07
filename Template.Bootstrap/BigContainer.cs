using $ext_projectname$.Application.AppServices;
using $ext_projectname$.Application.Interfaces.Business;
using $ext_projectname$.Application.Interfaces.Services;
using $ext_projectname$.Business.Domain;
using $ext_projectname$.Data.Contexts;
using $ext_projectname$.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$
{
    public static class BigContainer
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection service)
        {
            service.AddTransient<NewsAnaliticsAppService>();
            service.AddTransient<NewsAppService>();
            service.AddTransient<BookAppService>();
            service.AddTransient<TweetAppService>();
            return service;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection service)
        {
            service.AddTransient<INewsSearcher, NYNews.Client>();
            service.AddTransient<IBookSearcher, GoogleBooks.Client>();
            service.AddTransient<ITweetSearcher, Twitter.Client>();

            return service;
        }

        public static IServiceCollection RegisterAppBusiness(this IServiceCollection service)
        {
            service.AddTransient<INewBusiness, NewsBusiness>();
            service.AddTransient<IBookBusiness, BookBusiness>();
            service.AddTransient<INewsAnaliticsBusiness, NewsAnaliticsBusiness>();
            service.AddTransient<ITweetBusiness, TweetBusiness>();

            return service;
        }

        public static IServiceCollection RegisterAppPersistence(this IServiceCollection service)
        {
            service.AddDbContext<AppDbContext>();
            service.AddTransient<IDbContext, AppDbContext>();

            return service;
        }

        public static IServiceCollection RegisterAppPersistenceTest(this IServiceCollection service)
        {
            service.AddDbContext<AppDbContext>();
            service.AddTransient<IDbContext, AppDbContext>();

            return service;
        }
    }
}
