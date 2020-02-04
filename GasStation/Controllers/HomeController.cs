using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GasStation.Models;
using Microsoft.EntityFrameworkCore;

namespace GasStation.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationContext context;
        

        public HomeController(ApplicationContext context)
        {
            this.context = context;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Vacancies()
        {
            return View();

        }


        public ViewResult Stocks()
        {
            return View();
        }


        public ViewResult Contacts()
        {
            return View();
        }


        public ViewResult AboutUs()
        {
            return View(0);
        }


        public ViewResult News1()
        {
            return View();
        }

        public ViewResult News2()
        {
            return View();
        }

        public ViewResult News3()
        {
            return View();
        }
        public ViewResult Buy95()
        {
            return View();
        }

        public ViewResult Buy92()
        {
            return View();
        }

        public ViewResult BuyDp()
        {
            return View();
        }

        public ViewResult BuyGas()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Fuel fuel)
        {
          
            context.Fuels.Add(fuel);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Liters")] Fuel fuel)
        {
            if (id != fuel.Id)
            {
                return NotFound();
            }
            var current = await context.Fuels.AsNoTracking().FirstAsync(it => it.Id == id);
            var liters = current.Liters;

            if (ModelState.IsValid)
            {
                try
                {
                    fuel.Liters = liters - fuel.Liters;
                    if(fuel.Liters < 0)
                    {
                        return View("Error");
                    }
                    else
                    {
                        context.Update(fuel);
                        await context.SaveChangesAsync();
                        return View("Thanks");
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelExists(fuel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fuel);
        }

        private bool FuelExists(int id)
        {
            return context.Fuels.Any(e => e.Id == id);
        }


        

    }
}
