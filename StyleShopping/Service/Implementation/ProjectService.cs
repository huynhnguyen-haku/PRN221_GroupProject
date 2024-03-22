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
    public class ProjectService : IProjectService
    {
        private IProjectRepository _repository;
        public ProjectService()
        {
            _repository = new ProjectRepository();
        }
        public Project Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Project> List()
        {
           return _repository.List();
        }
    }
}
