using Microsoft.AspNetCore.Mvc;
using NetCore_Services.Interfaces;
using NetCore.Data.ViewModels;

namespace NetCore.Controllers;

public class MembershipController : Controller
{
    private IUser user;

    public MembershipController(IUser user)
    {
        this.user = user;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginInfo login)
    {
        string message = string.Empty;
        
        if (ModelState.IsValid)
        {
            string userId = "jadejs";
            string password = "123456";

            if (user.MatchTheUserInfo(login))
            {
                TempData["Message"] = "로그인이 성공적으로 이루어졌습니다.";
                return RedirectToAction("Index", "Membership");
            }
            message = "로그인되지 않았습니다.";
        }
        else
        {
            message = "로그인 정보를 올바르게 입력하세요.";
        }
        
        ModelState.AddModelError(string.Empty, message);
        return View(login);
    }
}