using AssignmentBLL.DataTransferObjects;
using AssignmentBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentPL.Controllers
{
    public class DepartmentController(IDepartmentService departmentServices,
        ILogger<DepartmentController> logger,
        IWebHostEnvironment webHostEnvironment
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var departments = await departmentServices.GetAllAsync();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(DepartmentRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            //var rowsAffected = departmentServices.add(request);
            //if (rowsAffected > 0)
            //    return RedirectToAction("Index");
            //ModelState.AddModelError("", "Failed to create department.");
            //return View(request);
            try
            {
                var result = await departmentServices.addAsync(request);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Failed to create department.");



            }
            catch (Exception ex)
            {
                if (webHostEnvironment.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else logger.LogError(ex.Message, "An error occurred while creating a department.");


            }
            return View(request);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department =await departmentServices.GetByIdAsync(id.Value);
            if (department == null)
                return NotFound();
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department =await departmentServices.GetByIdAsync(id.Value);
            if (department == null)
                return NotFound();
            return View(department.ToUpdateRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            try
            {
                var result = await departmentServices.updateAsync(request);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Failed to update department.");
            }
            catch (Exception ex)
            {
                if (webHostEnvironment.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else logger.LogError(ex.Message, "An error occurred while updating a department.");
            }
            return View(request);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = await departmentServices.GetByIdAsync(id.Value);
            if (department == null)
                return NotFound();

            return View(department);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department =await departmentServices.GetByIdAsync(id.Value);
            try
            {
                
                var isDeleted =await departmentServices.deleteAsync(id.Value); 
                if (isDeleted) 
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Failed to delete department.");
            }
            catch (Exception ex)
            {
                if (webHostEnvironment.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else logger.LogError(ex.Message, "An error occurred while deleting a department.");
            }
            return View(department);

        }
    }
}
