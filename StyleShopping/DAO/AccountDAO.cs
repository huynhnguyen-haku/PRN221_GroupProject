using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }

            }
        }
       


        public Account GetByNameAndPassword(string username,string password)
        {
            Account account = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    account = MySale.Accounts.SingleOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password) && x.Status == 1);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
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
