using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class EditProjectModel : PageModel
    {
        private readonly IProjectService _projectService;

        public EditProjectModel(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [BindProperty]
        public Project project { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            project = _projectService.Get(id);
            return Page();
        }
        public IActionResult OnPostAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            int count = 0;
            foreach (var item in _projectService.ListAdmin())
            {
                count++;
                if (item.Id == project.Id)
                {
                    break;
                }
            }
            project.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            _projectService.Update(project);

            return RedirectToPage("ManageProject", new { id = indexPage });
        }
    }
}
