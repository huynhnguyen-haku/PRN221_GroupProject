using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IInteriorService
    {
        public void Add(Interior interior);

        public void Delete(int id);

        public List<Interior> List(int? cate_id);

        public void Update(Interior interior);

        public IEnumerable<Category> ListCategory();

        Interior Get(int id);

        List<Interior> ListAdmin();
    }
}
