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
    public class ProjectRepository : IProjectRepository
    {
        public Project Get(int id) => ProjectDAO.Instance.Get(id);

        public List<Project> List() => ProjectDAO.Instance.List();
    }
}
