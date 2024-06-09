using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class AnimalEditController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid)
            {
                var existingAnimal = ApplicationContext.FindAnimal((int)animal.Id);
                if (existingAnimal != null)
                {
                    existingAnimal.Name = animal.Name;
                    existingAnimal.Type = animal.Type;
                    existingAnimal.Description = animal.Description;
                    return RedirectToAction("Index", "Animal"); // Перенаправляем на страницу списка животных после сохранения изменений
                }
                else
                {
                    return NotFound(); // Возвращаем 404 Not Found, если животное не найдено
                }
            }

            // Если модель недействительна, возвращаем представление с текущими данными животного для исправления
            return View("~/Views/Animal/Edit.cshtml", animal);
        }
    }
}
