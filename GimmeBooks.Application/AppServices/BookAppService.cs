using $ext_projectname$.Application.Interfaces.Business;
using $ext_projectname$.Application.Interfaces.Services;
using $ext_projectname$.Common;
using $ext_projectname$.Domain.Entities;
using $ext_projectname$.ViewModels.AppObject;
using $ext_projectname$.ViewModels.AppObjects;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace $safeprojectname$.AppServices
{
    public class BookAppService : BaseAppService<Book_vw, Book>
    {
        private readonly IBookBusiness _business;
        private readonly IBookSearcher _searcher;

        public BookAppService(IBookBusiness business, IBookSearcher searcher) : base(business)
        {
            _business = business;
            _searcher = searcher;
        }

        public async Task<ReadOnlyCollection<Book_vw>> Find(ECategoryType category, string keyWords)
        {
            return new ReadOnlyCollection<Book_vw>(await _searcher.SearchAsync(category, keyWords));
        }
    }
}
