using WebApplication2.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        { }
        public ActionResult Index()
        {
            return View(ApplicationContext.Users);
        }

        public ActionResult Details(long id)
        {
            foreach(User user in ApplicationContext.Users)
            {
                if(user.Id == id)
                    return View(user);
            }
            return View("Index");
        }

        public ActionResult Create()
        {
            return Redirect("/Registration");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            foreach (User user in ApplicationContext.Users)
            {
                if (user.Id == id)
                    return View(user);
            }
            return View("Index");
        }

        public ActionResult Edits(long id)
        {
            foreach (User user in ApplicationContext.Users)
            {
                if (user.Id == id)
                    return View(user);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(long id, User user, IFormCollection collection)
        {
            try
            {
                foreach (User currentUser in ApplicationContext.Users)
                {
                    if (currentUser.Id == id)
                    {
                        currentUser.Email = user.Email;
                        currentUser.Password = user.Password;
                        currentUser.Login = user.Login;
                        currentUser.Age = user.Age;
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(long id)
        {
            try
            {
                foreach (User user in ApplicationContext.Users)
                {
                    if (user.Id == id)
                    {
                        ApplicationContext.Users.Remove(user);

                        return RedirectToAction(nameof(Index));
                    }
                }
                return View("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, IFormCollection collection)
        {
            try
            {
                foreach(User user in ApplicationContext.Users)
                {
                    if(user.Id == id)
                    {
                        ApplicationContext.Users.Remove(user);

                        return RedirectToAction(nameof(Index));
                    }
                }
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Login1(User model)
        {
            foreach(User user in ApplicationContext.Users)
            {
                if (user.Login == model.Login && user.Password == model.Password)
                {
                    ApplicationContext.authorizedUser = user;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        public IActionResult EditEmail()
        {
            if (ApplicationContext.authorizedUser != null)
            {
                return View(ApplicationContext.authorizedUser);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditEmail(string email)
        {
            if (ApplicationContext.authorizedUser != null)
            {
                foreach(User currentUser in ApplicationContext.Users)
                {
                    if (currentUser.Email == email)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                ApplicationContext.authorizedUser.Email = email;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult EditLoginAndAge()
        {
                return View();
            }
        [HttpPost]
            public IActionResult EditLoginAndAge(string login, int age)
        {
            if (ApplicationContext.authorizedUser != null)
            {
                foreach (User currentUser in ApplicationContext.Users)
                {
                    if (currentUser.Login == login)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                ApplicationContext.authorizedUser.Login = login;
                ApplicationContext.authorizedUser.Age = age;
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditPassword(string password)
        {
            if (ApplicationContext.authorizedUser != null)
            {
                ApplicationContext.authorizedUser.Password = password;
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
