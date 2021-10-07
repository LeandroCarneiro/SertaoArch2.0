using $ext_projectname$.Application.Interfaces.Business;
using $ext_projectname$.Application.Interfaces.Services;
using $ext_projectname$.Common;
using $ext_projectname$.Domain.Entities;
using $ext_projectname$.ViewModels.AppObject;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$.AppServices
{
    public class NewsAnaliticsAppService : BaseAppService<NewsAnalitics_vw, NewsAnalitics>
    {
        private readonly INewsAnaliticsBusiness _business;
        private readonly IBookSearcher _bookSearcher;
        private readonly ITweetSearcher _tweetSearcher;
        private readonly INewsSearcher _newsSearcher;

        public NewsAnaliticsAppService(INewsAnaliticsBusiness business, IBookSearcher bookSearcher, ITweetSearcher tweetSearche, INewsSearcher newsSearcher) : base(business)
        {
            _business = business;
            _bookSearcher = bookSearcher;
            _newsSearcher = newsSearcher;
            _tweetSearcher = tweetSearche;
        }

        public async Task<NewsAnalitics_vw> FindAndSave(ECategoryType category)
        {
            var news = await _newsSearcher.SearchAsync(category);
            var books = _bookSearcher.SearchAsync(category, news.FirstOrDefault().Title);
            var tweets = _tweetSearcher.SearchAsync(news.FirstOrDefault().Title);

            var result = new NewsAnalitics_vw()
            {
                NewsTitle = news.FirstOrDefault().Title,
                RelatedTweetsCount = (await tweets).Count,
                RelatedBooksCount = (await books).Count,
                Date = DateTime.Now
            };

            var entity = Resolve(result);
            _business.Add(entity);

            return result;
        }
    }
}
