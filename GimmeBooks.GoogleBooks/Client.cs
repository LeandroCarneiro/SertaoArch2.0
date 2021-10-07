using $ext_projectname$.Application.Interfaces.Services;
using $ext_projectname$.Common;
using $ext_projectname$.NYNews.Objs;
using $ext_projectname$.ViewModels.AppObject;
using $ext_projectname$.ViewModels.AppObjects;
using Microsoft.Extensions.Configuration;
using RestFullHelper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Client : IBookSearcher
    {
        private readonly ApiClient _client;

        public Client(IConfiguration config)
        {
            var settings = config.GetSection("GoogleBooksApi").Get<ApiSettings>();
           
            _client = new ApiClient(
                new Config(
                    settings.Url, 
                    settings.KeyQueryName, 
                    settings.Key, 
                    settings.SecretQueryName,
                    settings.Secret
                    ));
        }

        public async Task<List<Book_vw>> SearchAsync(ECategoryType categatory, string keyWords)
        {
            var result = await _client.SendAsync<GoogleResult>(new ObjRequest()
            {
                Method = $"volumes",
                Parameters = $"?q={categatory.ToString()} {keyWords}",
                Type = ERequestType.Get
            });

            if (result != null && result.Items != null && result.Items.Any())
                return result.Items.ToList();

            return default(List<Book_vw>);
        }
    }
}
