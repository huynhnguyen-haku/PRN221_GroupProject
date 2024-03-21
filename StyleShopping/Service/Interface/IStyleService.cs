using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IStyleService
    {
        public IEnumerable<Style> List();

        public Style Get(int id);
    }
}
