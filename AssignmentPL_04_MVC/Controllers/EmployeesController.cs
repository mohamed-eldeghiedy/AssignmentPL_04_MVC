using AssignmentBLL.DataTransferObjects;
using AssignmentBLL.DataTransferObjects.Employee;
using AssignmentBLL.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssignmentPL.Controllers
{
    public class EmployeesController(IEmployeeService employeeService 
        , ILogger<EmployeesController> logger
        , IWebHostEnvironment env , IMapper mapper , IDepartmentService  departmentService)
        : Controller
    {
        public async Task< IActionResult> Index( string? SearchValue)
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
                return View( await employeeService.GetAllAsync());
            else
                return View(await employeeService.GetAllAsync(SearchValue));

        }

        [HttpGet]
        public async Task< IActionResult> Add()
        {
            var departments = await departmentService.GetAllAsync();
            var SelectList = new SelectList(departments , "Id" ,"Name");
            ViewBag.Departments = SelectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
           
            try
            {
                var result = await employeeService.AddAsync(request);
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

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = await employeeService.GetByIdAsync(id.Value);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = await employeeService.GetByIdAsync(id.Value);
            if (employee == null)
                return NotFound();
            var departments = await departmentService.GetAllAsync();
            var SelectList = new SelectList(departments, "Id", "Name" , employee.DepartmentId);
            ViewBag.Departments = SelectList;
            return View(mapper.Map<EmployeeUpdateRequest>(employee) );
        }

        [HttpPost]
        public async  Task<IActionResult> Edit(EmployeeUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            try
            {
                var result = await employeeService.UpdateAsync(request);
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = await employeeService.GetByIdAsync(id.Value);
            if (employee == null)
                return NotFound();

            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = await employeeService.GetByIdAsync(id.Value);
            try
            {

                var isDeleted = await employeeService.DeleteAsync(id.Value);
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
