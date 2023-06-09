using PizzaApp.Models;

namespace PizzaApp
{
    public class StaticDb
    {
        public static List<PizzaOrder> Pizzas = new List<PizzaOrder>
        {
            new PizzaOrder()
            {
                OrderId = 1,
                CustomerName = "Petko Petkoski",
                PizzaType = "Caprichiosa"
            },
            new PizzaOrder()
            {
                OrderId = 2,
                CustomerName = "Trajko Trajkoski",
                PizzaType = "Margarita"
            },

            new PizzaOrder()
            {
                OrderId = 3,
                CustomerName = "Ivana Ivanoska",
                PizzaType = "Pepperoni"
            }
        };
    }
}
