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
    public class StyleService : IStyleService
    {
        private IStyleRepository _styleRepository;
        public StyleService()
        {
            _styleRepository = new StyleRepository();
        }
        public Style Get(int id) => _styleRepository.Get(id);

        public IEnumerable<Style> List() => _styleRepository.List();
    }
}
