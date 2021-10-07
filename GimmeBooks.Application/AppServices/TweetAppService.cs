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
    public class TweetAppService : BaseAppService<Tweet_vw, Tweet>
    {
        private readonly ITweetBusiness _business;
        private readonly ITweetSearcher _searcher;

        public TweetAppService(ITweetBusiness business, ITweetSearcher searcher) : base(business)
        {
            _business = business;
            _searcher = searcher;
        }

        public async Task<ReadOnlyCollection<Tweet_vw>> Find(string keyWords)
        {
            return new ReadOnlyCollection<Tweet_vw>(await _searcher.SearchAsync(keyWords));
        }
    }
}
