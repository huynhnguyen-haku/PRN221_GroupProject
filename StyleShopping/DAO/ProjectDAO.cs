using BussinessObject;
using StyleShopping.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProjectDAO
    {
        private static ProjectDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProjectDAO() { }
        public static ProjectDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectDAO();
                    }
                    return instance;
                }

            }
        }
        public List<Project> List()
        {
            List<Project> projects;
            try
            {

                using (var MySale = new styleContext())
                {
                    projects = MySale.Projects.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return projects;

        }


        public Project Get(int id)
        {
            Project project = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    project = MySale.Projects.SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return project;
        }
    }
}
