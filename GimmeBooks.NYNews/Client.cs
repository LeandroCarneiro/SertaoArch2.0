using $ext_projectname$.Application.Interfaces.Services;
using $ext_projectname$.Common;
using $ext_projectname$.NYNews.Objs;
using $ext_projectname$.ViewModels.AppObjects;
using Microsoft.Extensions.Configuration;
using RestFullHelper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Client : INewsSearcher
    {
        private readonly ApiClient _client;

        public Client(IConfiguration config)
        {
            var settings = config.GetSection("NYApi").Get<ApiSettings>();
           
            _client = new ApiClient(
                new Config(
                    settings.Url, 
                    settings.KeyQueryName, 
                    settings.Key, 
                    settings.Secret
                    ));
        }

        public async Task<List<News_vw>> SearchAsync(ECategoryType categatory)
        {
            var result = await _client.SendAsync<NYResult>(new ObjRequest()
            {
                Method = $"topstories/v2/{categatory}.json",
                Parameters = "",
                Type = ERequestType.Get
            });

            if (result != null && result.Results != null && result.Results.Any() && result.Status == "OK")
                return result.Results.ToList();

            return default(List<News_vw>);
        }
    }
}
