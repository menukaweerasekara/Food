namespace Food.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Suburb { get; set; }
        public string AreaCode { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
