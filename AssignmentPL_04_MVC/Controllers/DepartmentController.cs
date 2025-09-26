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
        public IActionResult Index()
        {
            var departments = departmentServices.GetAll();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentRequest request)
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
                var result = departmentServices.add(request);
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

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = departmentServices.GetById(id.Value);
            if (department == null)
                return NotFound();
            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = departmentServices.GetById(id.Value);
            if (department == null)
                return NotFound();
            return View(department.ToUpdateRequest());
        }

        [HttpPost]
        public IActionResult Edit(DepartmentUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            try
            {
                var result = departmentServices.update(request);
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

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = departmentServices.GetById(id.Value);
            if (department == null)
                return NotFound();

            return View(department);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = departmentServices.GetById(id.Value);
            try
            {
                
                var isDeleted = departmentServices.delete(id.Value); 
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
