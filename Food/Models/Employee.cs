using System.ComponentModel.DataAnnotations;

namespace Food.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [StringLength(46)]
        public string EmployeeName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [StringLength(8)]
        public string Role { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public int? ManagerID { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant Restaurants { get; set; }
        public Employee? Manager { get; set; }
    }
}
