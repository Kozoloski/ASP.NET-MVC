using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    public class PizzaOrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("ListOrders")]
        public IActionResult ListOrders()
        {
            return View("Index");
        }
       
        [Route("[controller]/Details/{id?}")]
        public IActionResult Details(int? id)
        {         
            if (id == null)
            {
                return new EmptyResult();
            }

            PizzaOrder order = StaticDb.Pizzas.Where(x => x.OrderId == id).FirstOrDefault();

            if (order == null)
            {
                return new EmptyResult();
            }
            return View(order);
            
        }

        [Route("[controller]/GetJson")]
        public IActionResult GetJson()
        {
            PizzaOrder pizzaOrders = new PizzaOrder()
            {
                OrderId = 1,
                CustomerName = "Petko Petkoski",
                PizzaType = "Caprichiosa"
            };
            return new JsonResult(pizzaOrders);
        }

        public IActionResult RedirectToHomeController()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
