using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dish.OrderByDescending(dish => dish.DishId).ToList();
            return View(AllDishes);
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost("add")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }
        [HttpGet("{id}")]
        public IActionResult Description(int? id)
        {
            Dish oneDish = dbContext.Dish.FirstOrDefault(dish => dish.DishId == id);
            return View(oneDish);
        }
        [HttpGet("edit/{id}")]
        public IActionResult EditDish(int? id)
        {
            Dish editDish = dbContext.Dish.FirstOrDefault(dish => dish.DishId == id);
     
            return View(editDish);
        }
        [HttpPost("update")]
        public IActionResult Update(int? id, [Bind] Dish updateDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dish.Update(updateDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditDish");
            }
        }
        public IActionResult Delete(int? id)
        {
            Dish oneDish = dbContext.Dish.FirstOrDefault(dish => dish.DishId == id);
    
            dbContext.Dish.Remove(oneDish);
            
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
