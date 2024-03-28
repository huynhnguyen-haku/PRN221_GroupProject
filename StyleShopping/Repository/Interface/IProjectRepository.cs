using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IProjectRepository
    {
        public List<Project> List();


        public Project Get(int id);

        void Add(Project project);
        void Update(Project project);

        public List<Project> ListAdmin();
    }
}
