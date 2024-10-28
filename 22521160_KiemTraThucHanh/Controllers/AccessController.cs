using _22521160_KiemTraThucHanh.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22521160_KiemTraThucHanh.Controllers
{
    public class AccessController : Controller
    {
        QlspContext db = new QlspContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    if (u.Type == 1)
                        return RedirectToAction("Index", "HomeAdmin", new {area="Admin"});
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Access");
        }
    }
}
