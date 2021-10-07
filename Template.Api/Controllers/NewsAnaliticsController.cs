using $ext_projectname$.Application.AppServices;
using $ext_projectname$.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace $safeprojectname$.Controllers
{
    public class NewsAnaliticsController : BaseController
    {
        private readonly NewsAnaliticsAppService _newsAppService;

        public NewsAnaliticsController(NewsAnaliticsAppService newsAppService)
        {
            _newsAppService = newsAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ECategoryType category = ECategoryType.Science)
        {
            return ReturnResult(await _newsAppService.FindAndSave(category));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return ReturnResult(await _newsAppService.AllAsync());
        }
    }
}
