using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JobPortal.Pages
{
    public class FindJobModel : PageModel
    {
        private readonly ILogger<FindJobModel> _logger;

        public FindJobModel(ILogger<FindJobModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
    }
}
