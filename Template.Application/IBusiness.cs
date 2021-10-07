using $ext_projectname$.Domain;
using $ext_projectname$.Domain.Interfaces;

namespace $safeprojectname$
{
    public interface IBusiness<T> : ICrud<T, long> where T : EntityBase<long>
    {
    }
}
