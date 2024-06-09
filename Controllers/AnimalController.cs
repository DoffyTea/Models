using WebApplication2.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            var animals = ApplicationContext.Animals.ToList();
            return View(animals);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                ApplicationContext.Add(animal);
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // Метод действия для удаления животного
        public IActionResult Delete(int id)
        {
            var animal = ApplicationContext.FindAnimal(id);
            if (animal != null)
            {
                ApplicationContext.Remove(animal);
                return RedirectToAction("Index"); // Перенаправляем на страницу списка животных после удаления
            }
            return NotFound();
        }

        // Метод действия для отображения формы редактирования животного
        public IActionResult Edit(int id)
        {
            var animal = ApplicationContext.FindAnimal(id);
            if (animal != null)
            {
                return View(animal); // Передаем модель животного в представление для редактирования
            }
            return NotFound();
        }

        // Метод действия для сохранения изменений после редактирования
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id)
        {
            var animal = ApplicationContext.FindAnimal((int)id);
            if (animal != null)
            {
                ApplicationContext.Remove(animal);
                return RedirectToAction("Index"); // Перенаправляем на страницу списка животных после удаления
            }
            return NotFound();
        }
    }
}

