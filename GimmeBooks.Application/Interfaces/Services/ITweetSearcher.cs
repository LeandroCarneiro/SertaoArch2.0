using $ext_projectname$.ViewModels.AppObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces.Services
{
    public interface ITweetSearcher
    {
        Task<List<Tweet_vw>> SearchAsync(string keywords);
    }
}
