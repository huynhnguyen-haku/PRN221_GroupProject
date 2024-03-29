

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

                using (var MySale = new styleContext())
                {
                    styles = MySale.Styles.Where(x => x.Status == 1).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return styles;

        }
        public List<Style> ListAdmin()
        {
            List<Style> styles;
            try
            {

                using (var MySale = new styleContext())
                {
                    styles = MySale.Styles.ToList();
                }
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
                using (var MySale = new styleContext())
                {
                    style = MySale.Styles.SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return style;
        }
        public void Add(Style style)
        {
            try
            {
                Style c = Get(style.Id);
                if (c == null)
                {
                    using (var MySale = new styleContext())
                    {
                        MySale.Styles.Add(style);
                        MySale.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The style is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(Style style)
        {
            try
            {
                Style p = Get(style.Id);
                if (p != null)
                {
                    using (var MySale = new styleContext())
                    {
                        MySale.Entry<Style>(style).State = EntityState.Modified;
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The style does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
