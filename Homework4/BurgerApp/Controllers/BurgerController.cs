using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
    public class BurgerController : Controller
    {
        public IActionResult Index()
        {
            List<Burger> burgersFromDb = StaticDb.Burgers;

            List<BurgerViewModel> burgerViewModelList = burgersFromDb.Select(x => new BurgerViewModel
            {
                Id = x.Id,
                BurgerName = x.Name,
                Price = x.Price,
                IsVegetarian = x.IsVegetarian,
                IsVegan = x.IsVegan,
                HasFries = x.HasFries
            }).ToList();

            ViewData["Title"] = "Burger Menu";
            ViewData["NumberOfBurgers"] = burgersFromDb.Count;

            return View(burgerViewModelList);
        }


        public IActionResult AddBurger()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBurger(BurgerViewModel burgerViewModel)
        {
            Burger newBurger = new Burger
            {
                Id = StaticDb.Burgers.Count + 1,
                Name = burgerViewModel.BurgerName,
                Price = burgerViewModel.Price,
                IsVegetarian = burgerViewModel.IsVegetarian,
                IsVegan = burgerViewModel.IsVegan,
                HasFries = burgerViewModel.HasFries
            };

            StaticDb.Burgers.Add(newBurger);

            return RedirectToAction("Index");
        }

        public IActionResult EditBurger(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

            if (burger == null)
            {
                return View("Error");
            }

            BurgerFormViewModel burgerFormViewModel = new BurgerFormViewModel
            {
                Id = burger.Id,
                BurgerName = burger.Name,
                Price = burger.Price,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries
            };

            return View(burgerFormViewModel);
        }

        [HttpPost]
        public IActionResult EditBurger(BurgerFormViewModel burgerFormViewModel)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerFormViewModel.Id);

            if (burger == null)
            {
                return View("ResourceNotFound");
            }

            burger.Name = burgerFormViewModel.BurgerName;
            burger.Price = burgerFormViewModel.Price;
            burger.IsVegetarian = burgerFormViewModel.IsVegetarian;
            burger.IsVegan = burgerFormViewModel.IsVegan;
            burger.HasFries = burgerFormViewModel.HasFries;

            return RedirectToAction("Index");
        }


        public IActionResult DeleteBurger(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

            if (burger == null)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Burgers.Remove(burger);

            return RedirectToAction("Index");
        }
    }
}
