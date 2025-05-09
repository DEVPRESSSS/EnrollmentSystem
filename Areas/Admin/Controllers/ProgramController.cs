using EnrollmentSystem.Data;
using EnrollmentSystem.Models;
using EnrollmentSystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentSystem.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProgramController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProgramController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Programs> programs= _context.Programs.Include(x=>x.Department)
                .ToList();

            return View(programs);
        }

        public IActionResult Upsert(string id)
        {

            ViewBag.DepartmentList = _context.Departments.Select(x => new SelectListItem
            {

                Value = x.DepartmentID,
                Text = x.DepartmentName

            }).ToList();

            if (string.IsNullOrEmpty(id))
            {

                return View(new Programs());
            }
            

             var program = _context.Programs.FirstOrDefault(x=>x.ProgramID == id);

             if (program == null)
             {
                    return NotFound("Oops the Id you are looking for is not found");
             }


              
            

            return View(program);
        }

        [HttpPost]
		public IActionResult Upsert(Programs programs)
		{


            ViewBag.DepartmentList = _context.Departments.Select(x => new SelectListItem
            {

                Value = x.DepartmentID,
                Text = x.DepartmentName

            }).ToList();

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(programs.ProgramID))
                {
                    programs.ProgramID = $"COURSE-{Guid.NewGuid().ToString().Substring(0, 8)}";
                    programs.IsAvailableForEnrollment = true ;
                    _context.Programs.Add(programs);

                   //return RedirectToAction("Index");
                }
                else
                {

                    _context.Programs.Update(programs);


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
         

          
            return View(programs);

        }





        public IActionResult Delete(string id)
        {


            if(string.IsNullOrEmpty(id))
            {

                return NotFound("No program id found");
            }

            var program = _context.Programs.FirstOrDefault(x=>x.ProgramID == id);
            if (program == null)
            {
                return BadRequest("No applicant id found");

            }

            if (ModelState.IsValid)
            {
                _context.Programs.Remove(program);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

    }
}
