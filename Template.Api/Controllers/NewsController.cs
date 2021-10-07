using $ext_projectname$.Application.AppServices;
using $ext_projectname$.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace $safeprojectname$.Controllers
{
    public class NewsController : BaseController
    {
        private readonly NewsAppService _appService;

        public NewsController(NewsAppService appService)
        {
            this._appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(ECategoryType category)
        {
            return ReturnResult(await _appService.GetAll(category));
        }
    }
}
