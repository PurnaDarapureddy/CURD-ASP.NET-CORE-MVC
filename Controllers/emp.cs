using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class emp : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(EmpModel e)
        {
            if(ModelState.IsValid)
            {
                repo re = new repo();
                re.insert(e);
                return RedirectToAction("Displayy");
            }
            return View();
        }
        public IActionResult Displayy(EmpModel e)
        {
            repo re = new repo();
            ModelState.Clear();
            return View(re.Display());
        }
        public IActionResult Edit(int id)
        {
            repo re = new repo();
            return View(re.Display().Find(e => e.empid == id));
        }
        [HttpPost]
        public IActionResult Edit(EmpModel e)
        {
            if(ModelState.IsValid)
            {
                repo re = new repo();
                re.update(e);
                return RedirectToAction("Displayy");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repo re = new repo();
                re.Delete(id);
                return RedirectToAction("Displayy");
            }
            return View();
        }
    }
}
