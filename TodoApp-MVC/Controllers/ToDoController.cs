using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly ApplicationDbContext _db;

        public ToDoController(ILogger<ToDoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        public IActionResult Index()
        {
            var todos = _db.ToDos.Where(todo => !todo.IsCompleted).ToList();
            return View(todos);
        }

        [HttpGet]
        public IActionResult AddToDo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToDo(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                todo.CompletionDate = DateTime.Now; // Set the current date as the default completion date
                _db.ToDos.Add(todo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        [HttpGet]
        public IActionResult MarkAsCompleted(int id)
        {
            var todo = _db.ToDos.Find(id);
            if (todo != null)
            {
                todo.IsCompleted = true;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
