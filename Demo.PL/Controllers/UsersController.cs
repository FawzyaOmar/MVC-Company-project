using Demo.PL.Models;
using DEMO.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager= userManager;
        }   

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<IActionResult>Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                var Users = await _userManager.Users.Select(
                    u => new UsersViewModel()
                    {
                        Id = u.Id,
                        Name=u.UserName,
                        PhoneNumber=u.PhoneNumber,
                        Email=u.Email,
                        Roles= _userManager.GetRolesAsync(u).Result
                    }
                    ).ToListAsync();
                return View(Users);
            }
            else
            {
                var User = await _userManager.FindByEmailAsync(searchValue);
                var MappedUser = new UsersViewModel() {

                    Id = User.Id,
                    Name = User.UserName,
                    PhoneNumber = User.PhoneNumber,
                    Email = User.Email,
                    Roles = _userManager.GetRolesAsync(User).Result


                };
                return View(new List<UsersViewModel> { MappedUser });
                
            }

        }
    }
}
