using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBlogRepository
    {
        public List<Blog> List();


        public Blog Get(int id);

        void Add(Blog blog);
        void Update(Blog blog);

        List<Blog> ListAdmin();
    }
}
