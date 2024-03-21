

using BussinessObject;
using Microsoft.EntityFrameworkCore;

namespace StyleShopping.DAO
{
    public class StyleDAO
    {
        private static StyleDAO instance = null;
        private static readonly object instanceLock = new object();
        private StyleDAO() { }
        public static StyleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StyleDAO();
                    }
                    return instance;
                }

            }
        }
        public List<Style> List()
        {
            List<Style> styles;
            try
            {
                    var MySale = new styleContext();           
                    styles = MySale.Styles.ToList();             
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return styles;

        }
        

        public Style Get(int id)
        {
            Style style = null;
            try
            {
                var MySale = new styleContext();              
                style = MySale.Styles.SingleOrDefault(x => x.Id == id);             
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return style;
        }
    }
}
