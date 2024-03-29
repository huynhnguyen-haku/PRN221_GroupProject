
using BussinessObject;
using Repository.Implementation;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class BlogService : IBlogService
    {
        private IBlogRepository _repository;
        public BlogService()
        {
            _repository = new BlogRepository();
        }
        public Blog Get(int id) => _repository.Get(id);

        public IEnumerable<Blog> List() => _repository.List();

        public List<Blog> ListAdmin() => _repository.ListAdmin();


        public void Add(Blog blog) => _repository.Add(blog);

        public void Update(Blog blog) => _repository.Update(blog);
    }
}
