using IIBS.Data;
using IIBS.Models;
using IIBS.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IIBS.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployee _employee;

        public EmployeeController(ApplicationDbContext context, IEmployee employee)
        {
            this._context = context;
            this._employee = employee;
        }

        public IActionResult Index()
        {
            List<Employee> employee = _employee.GetAllEmployee();
            return View(employee);
        }
        public IActionResult Default()
        {
            ViewBag.datasource = _context.employees.Take(100).ToList();
            return View();
        }
        public IActionResult Details(int id)
        {
            var employee = _employee.GetEmployeeByID;
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            try
            {
                _employee.AddEmployee(emp);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employee.GetEmployeeByID(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            _employee.UpdateEmployee(emp);
            _context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var empd = _context.employees.Find(id);
            return View(empd);
        }
  
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _employee.DeleteEmployee(id);
            _context.SaveChanges(true);
            return RedirectToAction(nameof(Index));
        }
    }
}
