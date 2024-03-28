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
    public class StyleRepository : IStyleRepository
    {
        public Style Get(int id) => StyleDAO.Instance.Get(id);

        public List<Style> List() => StyleDAO.Instance.List();

        public List<Style> ListAdmin() => StyleDAO.Instance.ListAdmin();

        public void Add(Style style) => StyleDAO.Instance.Add(style);


        public void Update(Style style) => StyleDAO.Instance.Update(style);
    }
}
