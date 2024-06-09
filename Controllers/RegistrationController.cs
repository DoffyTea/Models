using WebApplication2.Data;
using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

        [HttpPost]
        public IActionResult Check(Model model)
        {
            if (ModelState.IsValid)
            {
                // Проверка на уникальность логина
                var existingUser = ApplicationContext.Users.FirstOrDefault(u => u.Login == model.Login);
                if (existingUser != null)
                {
                    // Логин уже существует, добавляем ошибку модели
                    ModelState.AddModelError("Login", "Логин уже используется.");
                    return View("Index");
                }

                ApplicationContext.Users.Add(new Data.User
                {
                    Id = ApplicationContext.index++,
                    Login = model.Login,
                    Email = model.Email,
                    Age = model.Age,
                    Password = model.Password,
                    IsAdmin = false
                });
                return Redirect("/Account");
            }
            return View("Index");
        }
    }
}
