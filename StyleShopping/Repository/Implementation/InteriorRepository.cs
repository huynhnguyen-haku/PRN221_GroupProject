using BussinessObject;
using Repository.Interface;
using StyleShopping.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class InteriorRepository : IInteriorRepository
    {
        public void Add(Interior interior) => InteriorDAO.Instance.Add(interior);

        public void Delete(int id) => InteriorDAO.Instance.Delete(id);

        public List<Interior> List() => InteriorDAO.Instance.List();

        public void Update(Interior interior) => InteriorDAO.Instance.Update(interior);

        public List<Category> ListCategory() => InteriorDAO.Instance.ListCategory();

        public List<Interior> ListByCate(int? id) => InteriorDAO.Instance.ListByCategory(id);

        public Interior Get(int id) => InteriorDAO.Instance.Get(id);

        public List<Interior> ListAdmin() => InteriorDAO.Instance.ListAdmin();
    }
}
