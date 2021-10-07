using $ext_projectname$.Application.Interfaces;
using $ext_projectname$.Application.Interfaces.Services;
using $ext_projectname$.Common;
using $ext_projectname$.ViewModels.AppObject;
using LinqToTwitter;
using LinqToTwitter.Common;
using LinqToTwitter.OAuth;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Client : ITweetSearcher
    {
        private readonly TwitterContext _twitterCtx;

        public Client(IConfiguration config)
        {
            var settings = config.GetSection("TwitterApi").Get<ApiSettings>();
            var auth = Setup.Authorization(settings);

            _twitterCtx = new TwitterContext(auth);
        }

        public async Task<List<Tweet_vw>> SearchAsync(string keywords)
        {
            Search? searchResponse =
                await
                _twitterCtx.Search.Where(
                    x => x.Query == keywords
                    && x.Type == SearchType.Search
                    && x.IncludeEntities == true
                    && x.TweetMode == TweetMode.Extended
                 )
                .FirstOrDefaultAsync();

            var list = new List<Tweet_vw>();

            if (searchResponse?.Statuses != null)

                searchResponse.Statuses.ForEach(tweet =>
                    list.Add(new Tweet_vw()
                    {
                        User = tweet.User?.ScreenNameResponse,
                        Text = tweet.Text ?? tweet.FullText
                    }));

            return list;
        }
    }
}
