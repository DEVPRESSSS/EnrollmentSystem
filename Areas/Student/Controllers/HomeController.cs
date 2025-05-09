using EnrollmentSystem.Data;
using EnrollmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnrollmentSystem.Areas.Applicant.Controllers
{
    [Area("Student")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProgramOffered()
        {

            IEnumerable<Programs> programs = _context.Programs.ToList();
            return View(programs);
        }

        public IActionResult ViewProgramDetails(string id)
        {

            var programDetails = _context.Programs.FirstOrDefault(x => x.ProgramID == id);

            if (programDetails == null)
            {

                return NotFound("Program id not found");
            }

            return View(programDetails);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
