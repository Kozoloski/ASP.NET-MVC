using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;
using PizzaApp.Models.Mappers;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<PizzaViewModel> pizzaViewModels = StaticDb.Pizzas.Select(x => new PizzaViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.HasExtras ? x.Price + 10 : x.Price,
                PizzaSize = x.PizzaSize
            }).ToList();

            return View(pizzaViewModels);
        }

        public IActionResult GetAllPizzas()
        {
            List<Pizza> pizzas = StaticDb.Pizzas;
            return View(pizzas);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if (pizza == null)
            {
                return new EmptyResult();
            }

            //PizzaViewModel pizzaViewModel = new PizzaViewModel
            //{
            //Id = pizza.Id,
            //Name = pizza.Name,
            // Price = pizza.HasExtras ? pizza.Price + 10 : pizza.Price,
            // PizzaSize = pizza.PizzaSize
            // };
            PizzaViewModel pizzaViewModel = PizzaMapper.ToPizzaViewModel(pizza);
            return View(pizzaViewModel);

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
