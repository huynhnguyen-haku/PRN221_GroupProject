namespace StyleShopping.DTO
{
    public class OrderDTO
    {
        public int id { get; set; }

        public int totalCartPrice { get; set; }

        public int totalStylePrice { get; set; }

        public int status { get; set; }

        public DateTime? orderDate { get; set; }

    }
}
