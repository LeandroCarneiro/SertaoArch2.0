using $ext_projectname$.Common;
using $ext_projectname$.Domain.Entities;
using $ext_projectname$.ViewModels.AppObject;
using $ext_projectname$.ViewModels.AppObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces.Services
{
    public interface IBookSearcher
    {
        Task<List<Book_vw>> SearchAsync(ECategoryType category, string keyWords);
    }
}
