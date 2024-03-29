using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class DetailProjectModel : PageModel
    {
        private readonly IProjectService _projectService;
        public DetailProjectModel(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public Project project { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
        {
            project = _projectService.Get(id);
            return Page();
        }
    }
}
