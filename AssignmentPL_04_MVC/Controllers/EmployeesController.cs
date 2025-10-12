using AssignmentBLL.DataTransferObjects;
using AssignmentBLL.DataTransferObjects.Employee;
using AssignmentBLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentPL.Controllers
{
    public class EmployeesController(IEmployeeService employeeService 
        , ILogger<EmployeesController> logger
        , IWebHostEnvironment env , IMapper mapper)
        : Controller
    {
        public IActionResult Index()
        {
            var employees = employeeService.GetAll();

            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeeRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
           
            try
            {
                var result = employeeService.Add(request);
                if (result > 0)
                    TempData["Message"] = $"Employee {request.Name} Created";
                else
                    TempData["Message"] = $" Can Not Create Employee {request.Name}";
                return RedirectToAction(nameof(Index));
                



            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else logger.LogError(ex.Message, "An error occurred while creating a employee.");


            }
            return View(request);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = employeeService.GetById(id.Value);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = employeeService.GetById(id.Value);
            if (employee == null)
                return NotFound();
            return View(mapper.Map<EmployeeUpdateRequest>(employee) );
        }

        [HttpPost]
        public IActionResult Edit(EmployeeUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            try
            {
                var result = employeeService.Update(request);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Failed to update employee.");
            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else logger.LogError(ex.Message, "An error occurred while updating a employee.");
            }
            return View(request);
        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = employeeService.GetById(id.Value);
            if (employee == null)
                return NotFound();

            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = employeeService.GetById(id.Value);
            try
            {

                var isDeleted = employeeService.Delete(id.Value);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Failed to delete employee.");
            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else logger.LogError(ex.Message, "An error occurred while deleting a employee.");
            }
            return View(employee);

        }
    }
}
