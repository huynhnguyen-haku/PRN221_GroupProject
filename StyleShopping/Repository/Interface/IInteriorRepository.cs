using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IInteriorRepository
    {
        List<Interior> List();
        void Add(Interior interior);
        void Update(Interior interior);
        void Delete(int id);
        List<Category> ListCategory();

        List<Interior> ListByCate(int? cate_id);

        Interior Get(int id);

        List<Interior> ListAdmin();
    }
}
