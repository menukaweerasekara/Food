namespace Food.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DOB { get; set; }
        public string Role { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public int ReportsToID { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant Restaurants { get; set; }
        public Employee ReportsTo { get; set; }
    }
}
