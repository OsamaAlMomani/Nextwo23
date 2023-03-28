using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nextwo23.Models.ViewDataModel;
using Nextwo23.Models.ViewDataModel.Roles;

namespace Nextwo23.Controllers
{
    public class AccountController : Controller
    {
        #region Configuration
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private RoleManager<IdentityRole> roleManager;


        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        #endregion

        #region User         
        [AllowAnonymous]

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.phone,
                };
                var Result = await userManager.CreateAsync(user, model.Password!);
                if (Result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                foreach (var err in Result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var Result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (Result.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }

                ModelState.AddModelError("", "User Invalid");

                return View(model);
            }
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");


        }
        #endregion

        #region Roles
        public IActionResult CreateRole()
        {
            //if (User.Identity.IsAuthenticated)
                return View();
            //else
            //    return RedirectToAction("Error_UnAuthorized");
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName
                };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(model);



            }
            return View(model);
        }
        public IActionResult RoleList()
        {
            return View(roleManager.Roles);

        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            if (Id == null)
            {
                return View("Error");
            }
            var role = await roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                return View("Error");
            }
            EditRoleViewModel model = new EditRoleViewModel { RoleId = role.Id, RoleName = role.Name };
            foreach (var item in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(item, role.Name!))
                {
                    model.User!.Add(item.UserName!);
                }
            }
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.RoleId);
                if (role == null)
                {
                    return View("Error");
                }

                role.Name = model.RoleName;
                var result =await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return View(model);
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Modify()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Modify(string id)
        {
            if (!ModelState.IsValid)
            {
                if (id == null) { return View("Error"); }
                var role = await roleManager.FindByIdAsync(id);
                if (role == null) { return RedirectToAction("Index"); }
                List<UserViewModel> users = new List<UserViewModel>();

                foreach(var item in userManager.Users)
                {
                    UserViewModel user = new UserViewModel
                    {
                        UserId = item.Id,
                        UserName = item.UserName,
                    };
                    if (await userManager.IsInRoleAsync(item,role.Name!))
                    {
                        user.IsSelected = true;
                    }else
                    {
                        user.IsSelected= false;
                    }
                    users.Add(user);    
                }
                return View(users);

            }
            return RedirectToAction("Index");
        }
        #endregion


    }
}
