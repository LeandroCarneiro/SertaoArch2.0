using $ext_projectname$.Application.Interfaces.Business;
using $ext_projectname$.Application.Interfaces.Services;
using $ext_projectname$.Common;
using $ext_projectname$.Domain.Entities;
using $ext_projectname$.ViewModels.AppObjects;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace $safeprojectname$.AppServices
{
    public class NewsAppService : BaseAppService<News_vw, News>
    {
        private readonly INewBusiness _business;
        private readonly INewsSearcher _newsSearcher;

        public NewsAppService(INewBusiness business, INewsSearcher newsSearcher) : base(business)
        {
            _business = business;
            _newsSearcher = newsSearcher;
        }

        public override void Update(News_vw entity)
        {
            var newSurvey = Resolve(entity);            
        }

        public async Task<ReadOnlyCollection<News_vw>> GetAll(ECategoryType category)
        {
            return new ReadOnlyCollection<News_vw>(await _newsSearcher.SearchAsync(category));
        }
    }
}
