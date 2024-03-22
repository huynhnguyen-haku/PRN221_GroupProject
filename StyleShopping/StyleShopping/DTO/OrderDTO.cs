namespace StyleShopping.DTO
{
    public class OrderDTO
    {
        public int id { get; set; }
        public string style { get; set; }
        public int square { get; set; }

        public int priceStyle { get; set; }

        public int totalCartPrice { get; set; }

        public int totalStylePrice { get; set; }

        public int status { get; set; }
    }
}
