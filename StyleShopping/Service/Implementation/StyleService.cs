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
        private IStyleRepository _repository;
        public StyleService()
        {
            _repository = new StyleRepository();
        }
        public Style Get(int id) => _repository.Get(id);

        public IEnumerable<Style> List() => _repository.List();

        public List<Style> ListAdmin() => _repository.ListAdmin();


        public void Add(Style style) => _repository.Add(style);

        public void Update(Style style) => _repository.Update(style);
    }
}
