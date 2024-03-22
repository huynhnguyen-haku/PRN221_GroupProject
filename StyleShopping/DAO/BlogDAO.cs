using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BlogDAO
    {
        private static BlogDAO instance = null;
        private static readonly object instanceLock = new object();
        private BlogDAO() { }
        public static BlogDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BlogDAO();
                    }
                    return instance;
                }

            }
        }
        public List<Blog> List()
        {
            List<Blog> blogs;
            try
            {

                using (var MySale = new styleContext())
                {
                    blogs = MySale.Blogs.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return blogs;

        }


        public Blog Get(int id)
        {
            Blog blog = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    blog = MySale.Blogs.SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return blog;
        }
    }
}
