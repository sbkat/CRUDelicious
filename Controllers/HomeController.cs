using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        //chefs controller
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> allChefs = dbContext.Chefs.Include(chef => chef.CreatedDishes).ToList();
            return View(allChefs);
        }
        [HttpGet("newChef")]
        public IActionResult NewChef()
        {
            return View();
        }
        [HttpPost("AddChef")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }

        //dish controller
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(dish => dish.DishId).ToList();
            return View(AllDishes);
        }
        [HttpGet("newDish")]
        public IActionResult NewDish()
        {
            return View();
        }
        [HttpPost("AddDish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return View("NewDish");
            }
        }


        // CRUDelicious edit/update/delete
        // [HttpGet("{id}")]
        // public IActionResult Description(int? id)
        // {
        //     Dish oneDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
        //     return View(oneDish);
        // }
        // [HttpGet("edit/{id}")]
        // public IActionResult EditDish(int? id)
        // {
        //     Dish editDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
     
        //     return View(editDish);
        // }
        // [HttpPost("update")]
        // public IActionResult Update(int? id, [Bind] Dish updateDish)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         dbContext.Dishes.Update(updateDish);
        //         dbContext.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     else
        //     {
        //         return View("EditDish");
        //     }
        // }
        // public IActionResult Delete(int? id)
        // {
        //     Dish oneDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
    
        //     dbContext.Dishes.Remove(oneDish);
            
        //     dbContext.SaveChanges();
        //     return RedirectToAction("Index");
        // }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
