using $ext_projectname$.Domain.Entities;
using $ext_projectname$.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace $safeprojectname$.Contexts
{
    public class AppDbContext : BaseContext, IDbContext
    {
        public virtual DbSet<NewsAnalitics> tblNewsAnalitics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("AppDB"));
            base.OnConfiguring(options);

            options.UseLoggerFactory(_loggerFactory);
        }
    }
}
