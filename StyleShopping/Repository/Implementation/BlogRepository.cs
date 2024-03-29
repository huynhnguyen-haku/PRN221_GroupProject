using BussinessObject;
using DAO;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class BlogRepository : IBlogRepository
    {
        public Blog Get(int id) => BlogDAO.Instance.Get(id);

        public List<Blog> List() => BlogDAO.Instance.List();

        public List<Blog> ListAdmin() => BlogDAO.Instance.ListAdmin();

        public void Add(Blog blog) => BlogDAO.Instance.Add(blog);


        public void Update(Blog blog) => BlogDAO.Instance.Update(blog);
    }
}
