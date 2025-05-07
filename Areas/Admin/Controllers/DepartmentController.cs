using EnrollmentSystem.Data;
using EnrollmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentSystem.Areas.Admin.Controllers
{
	public class DepartmentController : Controller
	{
		private ApplicationDbContext _context;

		public DepartmentController(ApplicationDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
		{

			List<Department> departmentList = _context.Departments.ToList();

			return View(departmentList);
		}

		public IActionResult Upsert(string? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return View(new Department());
			}

			// Edit
			var department = _context.Departments.FirstOrDefault(d => d.DepartmentID == id);

			if (department == null)
			{
				return NotFound();
			}

			return View(department);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public IActionResult Upsert(Department obj)
		{
			if (ModelState.IsValid)
			{
				if (string.IsNullOrEmpty(obj.DepartmentID))
				{
					obj.DepartmentID = $"DPRT{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
					_context.Departments.Add(obj);
				}
				else
				{
					var existing = _context.Departments.FirstOrDefault(d => d.DepartmentID == obj.DepartmentID);
					if (existing != null)
					{
						existing.DepartmentName = obj.DepartmentName;
						existing.CourseCode = obj.CourseCode;
						_context.Departments.Update(existing);
					}
				}

				_context.SaveChanges();
                return RedirectToAction("Index");

            }
			else
			{
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
					ViewBag.Message = $"ERROR: {error.ErrorMessage}";
                }

            }
            return View(obj);

        }


        public IActionResult Delete(string id)
        {

            if (string.IsNullOrEmpty(id))
            {

                return NotFound();
            }

            //Find the ID
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentID == id);

            if (department == null)
            {
                return BadRequest("No applicant id found");

            }
            if (ModelState.IsValid)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();

            }

            return RedirectToAction($"Index");

        }

    }
}
