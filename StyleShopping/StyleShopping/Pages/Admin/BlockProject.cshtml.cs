using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class BlockProjectModel : PageModel
    {
        private readonly IProjectService _projectService;

        public BlockProjectModel(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in _projectService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Project project = _projectService.Get(id);
            project.Status = 0;
            int? indexPage = (count - 1) / 5 + 1;
            _projectService.Update(project);
            return RedirectToPage("ManageProject", new { id = indexPage });
        }
    }
}
