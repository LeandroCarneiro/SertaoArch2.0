using $ext_projectname$.Domain.Entities;
using $ext_projectname$.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Contexts
{
    class MockDb : BaseContext, IDbContext
    {
        public virtual DbSet<NewsAnalitics> tblNewsAnalitics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("GimmeBooksDB");
            base.OnConfiguring(options);

            options.UseLoggerFactory(_loggerFactory);
        }
    }
}
