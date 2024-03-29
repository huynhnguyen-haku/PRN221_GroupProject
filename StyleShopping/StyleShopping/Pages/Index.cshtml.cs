using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Interior> list { get; set; } = default!;
        public IEnumerable<Category> listC { get; set; } = default!;
        private readonly IInteriorService _interService;

        public int totalPage { get; set; } = default!;
        public int? indexPage { get; set; } = 1;
        public int? cate_id { get; set; } = 0;

        public int? original_cate { get; set; } = 0;
        public IndexModel(IInteriorService interService)
        {
            _interService = interService;
        }
        public IActionResult OnGetAsync(int? id1,int? id2)
        {
            if(original_cate != id1 && id1 != null)
            {
                indexPage = 1;
            }
            else
            {
                indexPage = id2 == null ? 1 : id2;
            }
            cate_id = id1;
            
            list = _interService.List(cate_id);
            if (list.Count() % 6 == 0)
            {
                totalPage = list.Count() / 6;
            }
            else
            {
                totalPage = (list.Count() / 6)+1;
            }

            if(indexPage != totalPage)
            {
                list = list.Skip(((int)indexPage-1)*6).Take(6);    
            }
            else
            {
                list = list.Skip(((int)indexPage - 1) * 6).Take(6);
            }
            original_cate = cate_id;
             listC = _interService.ListCategory();
            return Page();
        }
    }
}