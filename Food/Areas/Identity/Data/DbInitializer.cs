using Food.Models;
using System;
using System.Linq;

namespace Food.Areas.Identity.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
             new Employee{EmployeeName = "Menuka Weerasekara",DOB=DateTime.Parse("2004-08-27"),Role="Worker",HireDate=DateTime.Parse("2022-03-18"),Address="Home is Cool",ManagerID= 2,RestaurantID = 1 },
             new Employee{EmployeeName = "Hi",DOB=DateTime.Parse("1990-12-07"),Role="Owner",HireDate=DateTime.Parse("20011-05-28"),Address="Home Cool", RestaurantID = 1},
             new Employee{EmployeeName = "Yes",DOB=DateTime.Parse("2006-02-14"),Role="Worker",HireDate=DateTime.Parse("2015-11-18"),Address="Home",ManagerID= 4,RestaurantID = 2 },
             new Employee{EmployeeName = "Cool",DOB=DateTime.Parse("1988-01-23"),Role="Owner",HireDate=DateTime.Parse("2016-01-28"),Address="Coolest", ManagerID = 2},
             new Employee{EmployeeName = "Ben",DOB=DateTime.Parse("2006-09-03"),Role="Worker",HireDate=DateTime.Parse("2020-06-18"),Address="Cool",ManagerID= 6,RestaurantID = 3 },
             new Employee{EmployeeName = "Kevin",DOB=DateTime.Parse("1999-05-18"),Role="Owner",HireDate=DateTime.Parse("2012-03-28"),Address="Yes", RestaurantID = 3},
             new Employee{EmployeeName = "Finn",DOB=DateTime.Parse("2004-03-21"),Role="Worker",HireDate=DateTime.Parse("2017-08-18"),Address="Noo",ManagerID= 8,RestaurantID = 4 },
             new Employee{EmployeeName = "Edwin",DOB=DateTime.Parse("1987-12-017"),Role="Owner",HireDate=DateTime.Parse("2019-07-28"),Address="Coolest Cool", RestaurantID = 4}

            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();


            var restuarants = new Restaurant[]
           {
             new Restaurant{RestaurantID=1,RestaurantType="Fast Food",RestaurantName="Mc Donalds",DateOfRegistration=DateTime.Parse("1979-05-12"),RestaurantRating= "5", LocationID= 1},
             new Restaurant{RestaurantID=2,RestaurantType="Japanese",RestaurantName="Ichiraku Ramen",DateOfRegistration=DateTime.Parse("1998-04-08"),RestaurantRating= "5", LocationID = 4},
             new Restaurant{RestaurantID=3,RestaurantType="Chinese",RestaurantName="Dumplings Shop",DateOfRegistration=DateTime.Parse("1990-09-19"),RestaurantRating= "4", LocationID = 7},
             new Restaurant{RestaurantID=4,RestaurantType="Thai",RestaurantName="ThaiShops",DateOfRegistration=DateTime.Parse("2000-01-11"),RestaurantRating= "3", LocationID = 2},
           };
            foreach (Restaurant r in restuarants)
            {
                context.Restaurants.Add(r);
            }
            context.SaveChanges();

            var locations = new Location[]
           {
              new Location{LocationID=1,LocationName="Auckland",Suburb="Glen Eden",AreaCode="0602"},
              new Location{LocationID=2,LocationName="Auckland",Suburb="New Lynn",AreaCode="0600"},
              new Location{LocationID=3,LocationName="Auckland",Suburb="Henderson",AreaCode="0612"},
              new Location{LocationID=4,LocationName="ChristChurch",Suburb="Latimer",AreaCode="0806"},
              new Location{LocationID=5,LocationName="ChristChurch",Suburb="Victoria",AreaCode="0871"},
              new Location{LocationID=6,LocationName="ChristChurch",Suburb="Moa",AreaCode="0864"},
              new Location{LocationID=7,LocationName="Invercargill",Suburb="Avenal",AreaCode="0575"},
              new Location{LocationID=8,LocationName="Invercargill",Suburb="Clifton",AreaCode="0542"},
              new Location{LocationID=9,LocationName="Invercargill",Suburb="Garsmore",AreaCode="0579"},

           };
            foreach (Location l in locations)
            {
                context.Locations.Add(l);
            }
            context.SaveChanges();

            var menus = new Menu[]
            {
              new Menu{MenuID=1,FoodName="Big Mac",Country="USA",Price=9,RestaurantID =1 },
              new Menu{MenuID=2,FoodName="Ramen",Country="Japan",Price=12,RestaurantID =1 },
              new Menu{MenuID=3,FoodName="Dumplings",Country="China",Price=10,RestaurantID =1 },
              new Menu{MenuID=4,FoodName="shrimp Soup",Country="ThaiLand",Price=15,RestaurantID =1 },

            };
            foreach (Menu m in menus)
            {
                context.Menus.Add(m);
            }
            context.SaveChanges();

        } 
    }
}
