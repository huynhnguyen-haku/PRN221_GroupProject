using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IStyleRepository
    {
        public List<Style> List();


        public Style Get(int id);
    }
}
