using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBlogService
    {
        public IEnumerable<Blog> List();

        Blog Get(int id);

        public void Add(Blog blog);


        public void Update(Blog blog);

        List<Blog> ListAdmin();
    }
}
