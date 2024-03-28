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
    public class InteriorService : IInteriorService
    {
        private IInteriorRepository _repository;
        public InteriorService() {
            _repository = new InteriorRepository();
        }
        public void Add(Interior interior) => _repository.Add(interior);

        public void Delete(int id) => _repository.Delete(id);

        public Interior Get(int id) => _repository.Get(id);

        public List<Interior> List(int? cate_id)
        {
            List<Interior> list = _repository.List();
            if(cate_id != null)
            { 
                list = _repository.ListByCate(cate_id);
            }
            return list;

        }

        public List<Interior> ListAdmin() => _repository.ListAdmin();

        public IEnumerable<Category> ListCategory() => _repository.ListCategory();

        public void Update(Interior interior) => _repository.Update(interior);

    }
}
