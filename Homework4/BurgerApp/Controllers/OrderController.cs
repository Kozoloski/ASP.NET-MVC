using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BurgerApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersFromDb = StaticDb.Orders;

            List<OrderViewModel> orderViewModelList = ordersFromDb.Select(x => new OrderViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Address = x.Address,
                IsDelivered = x.IsDelivered,
                BurgerName = x.Burger.Name,
                Location = x.Location
            }).ToList();

            ViewData["Title"] = "All Orders";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;

            return View(orderViewModelList);
        }


        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel orderViewModel)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.BurgerName);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }
            Order newOrder = new Order
            {
                Id = StaticDb.Orders.Count + 1,
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                IsDelivered = orderViewModel.IsDelivered,
                Burger = new Burger
                {
                    Name = orderViewModel.BurgerName
                },
                Location = orderViewModel.Location
            };

            StaticDb.Orders.Add(newOrder);

            return RedirectToAction("Index");
        }



        public IActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return View("ResourceNotFound");
            }

            OrderFormViewModel orderFormViewModel = new OrderFormViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                BurgerName = order.Burger.Name,
                Location = order.Location
            };

            return View(orderFormViewModel);
        }


        [HttpPost]
        public IActionResult EditOrder(OrderFormViewModel orderFormViewModel)
        {
            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == orderFormViewModel.Id);

            if (order == null)
            {
                return View("ResourceNotFound");
            }

            order.FullName = orderFormViewModel.FullName;
            order.Address = orderFormViewModel.Address;
            order.IsDelivered = orderFormViewModel.IsDelivered;
            order.Burger.Name = orderFormViewModel.BurgerName;
            order.Location = orderFormViewModel.Location;

            return RedirectToAction("Index");
        }


        public IActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.Remove(order);

            return RedirectToAction("Index");
        }
    }
}
