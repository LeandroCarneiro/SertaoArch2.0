using $ext_projectname$.Application.AppServices;
using $ext_projectname$.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace $safeprojectname$.Controllers
{
    public class BookController : BaseController
    {
        private readonly BookAppService _appService;

        public BookController(BookAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(ECategoryType category, string keywords)
        {
            return ReturnResult(await _appService.Find(category, keywords));
        }
    }
}
