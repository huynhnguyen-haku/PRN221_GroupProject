using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Staff
{
    public class ProjectEditModel : PageModel
    {
        private readonly IProjectService projectService;

        public ProjectEditModel()
        {
            projectService = new ProjectService();
        }
        [BindProperty]
        public Project project { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            project = projectService.Get(id);
            return Page();
        }
        public IActionResult OnPostAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            int count = 0;
            foreach (var item in projectService.ListAdmin())
            {
                count++;
                if (item.Id == project.Id)
                {
                    break;
                }
            }
            project.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            projectService.Update(project);

            return RedirectToPage("ProjectManage", new { id = indexPage });
        }
    }
}
