namespace Food.Models
{
    public class Menu
    {
        public int MenuID { get; set; }
        public string FoodName { get; set; }
        public string Country { get; set; }
        public Double Price { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
