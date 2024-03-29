using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Staff
{
    public class ProjectBlockModel : PageModel
    {
        private readonly IProjectService projectService;

        public ProjectBlockModel()
        {
            projectService = new ProjectService();
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in projectService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Project project = projectService.Get(id);
            project.Status = 0;
            int? indexPage = (count - 1) / 5 + 1;
            projectService.Update(project);
            return RedirectToPage("ProjectManage", new { id = indexPage });
        }
    }
}
