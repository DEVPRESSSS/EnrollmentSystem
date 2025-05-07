using EnrollmentSystem.Data;
using Microsoft.AspNetCore.Mvc;
using EnrollmentSystem.Models;
using System.Drawing.Printing;

namespace EnrollmentSystem.Areas.Admin.Controllers
{

    //[Area("Admin")]
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

		public IActionResult Create()
		{



			return View();
		}


        [HttpPost]
        public IActionResult Create(EnrollmentSystem.Models.Applicant obj)
        {



            if (ModelState.IsValid)
            {

                string id = $"Applicant{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";

                obj.ApplicantID = id;

                _context.Applicants.Add(obj);
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }


        public IActionResult Edit(string id)
        {
            if(string.IsNullOrEmpty(id))
            {

                return NotFound();
            }

            //Find the ID
            var applicant = _context.Applicants.FirstOrDefault(x=>x.ApplicantID == id);

            if(applicant == null)
            {
				return BadRequest("No applicant id found");

			}

			return View(applicant);
        }

        [HttpPost]
        public IActionResult Edit(EnrollmentSystem.Models.Applicant applicant) {
        
        
            if(applicant == null)
            {
                return BadRequest("No applicant id found");
            }

            //Check if the inputs are valid

            if (ModelState.IsValid)
            {


                _context.Update(applicant);
                _context.SaveChanges();

                return RedirectToAction("Index");



            }
			
            return View();
        }


        public IActionResult Delete(string id)
        {

			if (string.IsNullOrEmpty(id))
			{

				return NotFound();
			}

			//Find the ID
			var applicant = _context.Applicants.FirstOrDefault(x => x.ApplicantID == id);

			if (applicant == null)
			{
				return BadRequest("No applicant id found");

			}
			if (ModelState.IsValid)
			{
				_context.Applicants.Remove(applicant);
				_context.SaveChanges();

			}

			return RedirectToAction($"Index");

		}

      


	}
}
