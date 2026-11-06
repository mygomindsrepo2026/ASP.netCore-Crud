using Microsoft.AspNetCore.Mvc;

namespace MVCADOCrud.Controllers
{
    public class EmpController : Controller
    {
        private readonly EmpSL.EmpServiceLayer _empservice;

        public EmpController(EmpSL.EmpServiceLayer empservice)
        {
            _empservice = empservice;
        }

        public IActionResult Index()
        {
            ViewBag.Emps = _empservice.GetEmps();
            return View(new Models.Employee());

        }

        [HttpPost]
        public IActionResult Index(Models.Employee emp,string b1)
        {
            if(b1=="Save")
            {
                int result = _empservice.SaveEmployee(emp);

                if (result > 0)
                {
                    TempData["Message"] = "Employee Saved Successfully";
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Message = "Employee Registration Failed";
                ViewBag.Emps = _empservice.GetEmps();
                return View(emp);
            }
            else if(b1=="Update")
            {
                int result = _empservice.UpdateEmployee(emp);
                if (result > 0)
                {
                    TempData["Message"] = "Employee Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = "Employee Update Failed";
                ViewBag.Emps = _empservice.GetEmps();
                return View(emp);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
           int i= _empservice.DeleteEmployee(id);
            if(i==1)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Employee emp = _empservice.SearchEmployee(id);

            ViewBag.Emps = _empservice.GetEmps();
            return View("Index", emp);
        }
    }
}







