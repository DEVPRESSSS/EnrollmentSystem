using EnrollmentSystem.Data;
using Microsoft.AspNetCore.Mvc;
using EnrollmentSystem.Models;

namespace EnrollmentSystem.Areas.Admin.Controllers
{
    public class ApplicantController : Controller
    {


        private ApplicationDbContext _context;
        public ApplicantController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            IEnumerable<EnrollmentSystem.Models.Applicant> applicants = _context.Applicants.ToList();

            return View(applicants);
        }

        public IActionResult Edit(string id)
        {
            if(string.IsNullOrEmpty(id))
            {

                return NotFound();
            }

            return View();
        }
    }
}
