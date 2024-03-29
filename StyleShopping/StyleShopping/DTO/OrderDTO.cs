namespace StyleShopping.DTO
{
    public class OrderDTO
    {
        public int id { get; set; }

        public int totalCartPrice { get; set; }

        public int totalStylePrice { get; set; }

        public int status { get; set; }

        public string address { get; set; }
        public string username { get; set; }

        public string phone { get; set; }

        public string note { get; set; }

        public DateTime? orderDate { get; set; }

    }
}
