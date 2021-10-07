using $ext_projectname$.Application.AppServices;
using $ext_projectname$.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace $safeprojectname$.Controllers
{
    public class TweetController : BaseController
    {
        private readonly TweetAppService _appService;

        public TweetController(TweetAppService appService)
        {
            _appService = appService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string keywords)
        {
            return ReturnResult(await _appService.Find(keywords));
        }
    }
}
