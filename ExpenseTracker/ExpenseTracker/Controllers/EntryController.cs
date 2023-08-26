using ExpenseTracker.Data.Repositories;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class EntryController : Controller
    {
        private readonly IExpenseEntryRepository entryRepo;
        private readonly IExpenseCategoryRepository categoryRepo;


        public EntryController(IExpenseCategoryRepository expenseCategoryRepository, IExpenseEntryRepository  expenseEntryRepository )
        {
            this.categoryRepo = expenseCategoryRepository;
            this.entryRepo = expenseEntryRepository;
        }

        // GET: EntryController
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: EntryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntryController/Create
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

        // GET: EntryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntryController/Edit/5
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

        // GET: EntryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntryController/Delete/5
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
    }
}
