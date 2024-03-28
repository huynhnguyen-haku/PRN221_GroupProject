using BussinessObject;
using Microsoft.EntityFrameworkCore;
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
                    projects = MySale.Projects.Where(x => x.Status == 1).ToList();
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
        public List<Project> ListAdmin()
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
        public void Add(Project project)
        {
            try
            {
                Project c = Get(project.Id);
                if (c == null)
                {
                    using (var MySale = new styleContext())
                    {
                        MySale.Projects.Add(project);
                        MySale.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The project is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(Project project)
        {
            try
            {
                Project p = Get(project.Id);
                if (p != null)
                {
                    using (var MySale = new styleContext())
                    {
                        MySale.Entry<Project>(project).State = EntityState.Modified;
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The project does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
