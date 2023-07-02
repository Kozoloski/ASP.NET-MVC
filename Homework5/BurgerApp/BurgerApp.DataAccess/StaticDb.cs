using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess
{
    public class StaticDb
    {
        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger()
            {
               Id = 1,
               Name = "Classic Burger",
               Price = 200,
               IsVegetarian = false,
               IsVegan = false,
               HasFries = true
            },

            new Burger()
            {
               Id = 2,
               Name = "Veggie Burger",
               Price = 230,
               IsVegetarian = true,
               IsVegan = true,
               HasFries = false
            },

            new Burger()
            {
               Id = 3,
               Name = "Chicken Burger",
               Price = 330,
               IsVegetarian = false,
               IsVegan = false,
               HasFries = true
            },

            new Burger()
            {
               Id = 4,
               Name = "Beef Burger",
               Price = 480,
               IsVegetarian = false,
               IsVegan = false,
               HasFries = true
            },

        };

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                BurgerId = 1,
                FullName = "Petko Petkoski",
                Address = "Gjorche Petrov 11",
                IsDelivered = false,
                Burger = Burgers.FirstOrDefault(x => x.Id == 1),
                Location = "Skopje"
            },

            new Order
            {
                Id = 2,
                BurgerId = 2,
                FullName = "Ivana Ivanoska",
                Address = "Razlovecko Vostanie 12",
                IsDelivered = true,
                Burger = Burgers.FirstOrDefault(x => x.Id == 2),
                Location = "Skopje"
            }
        };


    }
}
