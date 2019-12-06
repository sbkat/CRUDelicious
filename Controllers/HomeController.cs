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
            List<Dish> AllDishes = dbContext.Dishes.Include(dish => dish.Chef).OrderByDescending(dish => dish.CreatedAt).ToList();
            return View(AllDishes);
        }
        [HttpGet("newDish")]
        public IActionResult NewDish()
        {
            List<Chef> allChefs = dbContext.Chefs.ToList();
            return View(new AddDishViewModel{SelectChef = allChefs});
        }
        [HttpPost("AddDish")]
        public IActionResult AddDish(AddDishViewModel newDish)
        {
            if(ModelState.IsValid)
            {
                Chef chef = dbContext.Chefs.FirstOrDefault(c => c.chefId == newDish.chefId);
                newDish.Dish.Chef = chef;
                dbContext.Add(newDish.Dish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                List<Chef> allChefs = dbContext.Chefs.ToList();
                return View("NewDish", new AddDishViewModel{SelectChef = allChefs});
            }
        }
        [HttpGet("edit/{id}")]
        public IActionResult EditDish(int? id)
        {
            Dish editDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
            List<Chef> allChefs = dbContext.Chefs.ToList();
            return View(new AddDishViewModel{Dish = editDish, SelectChef = allChefs});
        }
        [HttpPost("update/{id}")]
        public IActionResult Update(int? id, [Bind] AddDishViewModel updateDish)
        {
            if(ModelState.IsValid)
            {
                Dish editDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
                editDish = updateDish.Dish;
                editDish.UpdatedAt = DateTime.Now;
                dbContext.Dishes.Update(editDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return View("EditDish");
            }
        }
        public IActionResult Delete(int? id)
        {
            Dish oneDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
            dbContext.Dishes.Remove(oneDish);
            dbContext.SaveChanges();
            return RedirectToAction("Dishes");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
