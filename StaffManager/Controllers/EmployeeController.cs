using Microsoft.AspNetCore.Mvc;
using StaffManager.Models;
using StaffManager.Models.DB;

namespace StaffManager.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBContext employeeDBContext;
        public EmployeeController(EmployeeDBContext sc)
        {
            employeeDBContext = sc;
        }

        public IActionResult Index()
        {
            return View(employeeDBContext.employeeDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                employeeDBContext.employeeDetails.Add(employeeDetails);
                employeeDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Update(int id)
        {
            return View(employeeDBContext.employeeDetails.Where(a => a.ID == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(EmployeeDetails employeeDetails)
        {
            employeeDBContext.employeeDetails.Update(employeeDetails);
            employeeDBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = employeeDBContext.employeeDetails.Where(a => a.ID == id).FirstOrDefault();
            employeeDBContext.employeeDetails.Remove(employee);
            employeeDBContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
