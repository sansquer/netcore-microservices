using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebMvc.Models.JobsViewModels;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;
        private readonly ILogger _logger;

        public JobsController(IJobService jobService, ILogger logger)
        {
            _jobService = jobService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Add(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _jobService.AddJob(model.Title, model.Company, model.Description, model.Salary);
                if (result != null)
                {
                    _logger.LogInformation("successfully add a job.");
                    return Redirect(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "an error ocurred while adding your job, please try again.");
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
