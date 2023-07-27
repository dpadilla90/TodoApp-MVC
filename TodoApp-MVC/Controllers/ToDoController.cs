using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    // Controller responsible for handling ToDo-related actions and views.
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly ApplicationDbContext _db;

        // Constructor that injects the logger and ApplicationDbContext instance into the controller.
        public ToDoController(ILogger<ToDoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        // Action to display the list of incomplete ToDo items.
        public IActionResult Index()
        {
            // Retrieve all ToDo items from the database that are not completed.
            var todos = _db.ToDos.Where(todo => !todo.IsCompleted).ToList();

            // Pass the list of incomplete ToDo items to the view for rendering.
            return View(todos);
        }

        // GET action to display the form for adding a new ToDo item.
        [HttpGet]
        public IActionResult AddToDo()
        {
            // Render the view that contains the form for adding a new ToDo item.
            return View();
        }

        // POST action to handle the form submission and add a new ToDo item to the database.
        [HttpPost]
        public IActionResult AddToDo(ToDo todo)
        {
            // Check if the model state is valid (i.e., form fields are filled correctly).
            if (ModelState.IsValid)
            {
                // Set the current date as the default completion date for the new ToDo item.
                todo.CompletionDate = DateTime.Now;

                // Add the new ToDo item to the database.
                _db.ToDos.Add(todo);

                // Save the changes to the database.
                _db.SaveChanges();

                // Redirect to the Index action to show the updated ToDo list.
                return RedirectToAction("Index");
            }

            // If the model state is not valid, re-render the AddToDo view with the entered data.
            return View(todo);
        }

        // GET action to handle marking a ToDo item as completed.
        [HttpGet]
        public IActionResult MarkAsCompleted(int id)
        {
            // Find the ToDo item with the specified id in the database.
            var todo = _db.ToDos.Find(id);

            // If the ToDo item is found, mark it as completed and save the changes.
            if (todo != null)
            {
                todo.IsCompleted = true;
                _db.SaveChanges();
            }

            // Redirect to the Index action to show the updated ToDo list.
            return RedirectToAction("Index");
        }
    }
}
