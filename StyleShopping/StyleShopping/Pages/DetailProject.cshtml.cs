using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class DetailProjectModel : PageModel
    {
        private readonly IProjectService projectService;
        public DetailProjectModel()
        {
            projectService = new ProjectService();
        }
        public Project project { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
        {
            project = projectService.Get(id);
            return Page();
        }
    }
}
