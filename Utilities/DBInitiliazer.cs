using EnrollmentSystem.Data;
using EnrollmentSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentSystem.Utilities
{
    public class DBInitiliazer:IDBinitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public DBInitiliazer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;

        }

        public void Initialize()
        {

            try
            {

                if(_context.Database.GetPendingMigrations().Count() > 0)
                {

                    _context.Database.Migrate();
                }

            }
            catch 
            {
                throw;
            }

            if(!_roleManager.RoleExistsAsync(SD.StudentApplicant).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();  
                _roleManager.CreateAsync(new IdentityRole(SD.StudentApplicant)).GetAwaiter().GetResult();  
                _roleManager.CreateAsync(new IdentityRole(SD.Staff)).GetAwaiter().GetResult();  
            }
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "xmontemorjerald@gmail.com",
                Email = "xmontemorjerald@gmail.com",
                Name = "Montemor, Jerald R.",
                PhoneNumber = "09488749263",
                Address = "Malabon City",

            }, "Admin123*").GetAwaiter().GetResult();


            ApplicationUser? user = _context.ApplicationUser.FirstOrDefault(x => x.Email == "xmontemorjerald@gmail.com");
            _userManager.AddToRoleAsync(user, SD.Admin).GetAwaiter().GetResult();

            return;
        }


    }
}
