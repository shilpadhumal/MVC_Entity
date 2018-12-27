using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Entity.Models;
using System.Data.Entity;

namespace MVC_Entity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            using(ProjectDataContext context = new ProjectDataContext())
            {
                return View(context.Employees.ToList());
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            using (ProjectDataContext context = new ProjectDataContext())
            {
                return View(context.Employees.FirstOrDefault(e=>e.EmpId==id));
            }
               
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (ProjectDataContext context = new ProjectDataContext())
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            using (ProjectDataContext context = new ProjectDataContext())
            {
                
                return View(context.Employees.FirstOrDefault(e => e.EmpId == id));
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                using (ProjectDataContext context = new ProjectDataContext())
                {
                    context.Entry(employee).State = EntityState.Modified;
                    context.SaveChanges();
                }
                 

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            using (ProjectDataContext context = new ProjectDataContext())
            {
                return View(context.Employees.FirstOrDefault(e=>e.EmpId==id));
                
            }
               
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                using (ProjectDataContext context = new ProjectDataContext())
                {
                    employee = context.Employees.FirstOrDefault(e => e.EmpId == id);
                    context.Employees.Remove(employee);
                    context.SaveChanges();

                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
