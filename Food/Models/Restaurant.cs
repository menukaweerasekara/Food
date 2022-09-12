using System.ComponentModel.DataAnnotations;

namespace Food.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string? RestaurantType { get; set; }
        [StringLength(20)]
        public string RestaurantName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfRegistration { get; set; }
        public string RestaurantRating { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}
