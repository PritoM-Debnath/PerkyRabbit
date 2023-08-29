using ExpenseTracker.Data.Repositories;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class EntryController : Controller
    {
        private readonly IExpenseEntryRepository entryRepo;
        private readonly IExpenseCategoryRepository categoryRepo;


        public EntryController(IExpenseCategoryRepository expenseCategoryRepository, IExpenseEntryRepository expenseEntryRepository)
        {
            this.categoryRepo = expenseCategoryRepository;
            this.entryRepo = expenseEntryRepository;
        }

        public ActionResult Index() => View();

        public HttpContext GetHttpContext()
        {
            return HttpContext;
        }

        public static int updatingCatId = 0;

        [HttpGet("Category/_ExpenseEntry")]
        public async Task<IActionResult> _ExpenseEntry(int _categoryId)
        {
            if (_categoryId > 0)
            {
                updatingCatId = _categoryId;
            }
            return RedirectToAction("Index", "Category");
        }


        [HttpPost("Category/_ExpenseEntry")]
        public async Task<IActionResult> _ExpenseEntry(ExpenseEntry expenseEntry)
        {

            int _cID = updatingCatId;

            if (_cID > 0 && expenseEntry != null)
            {
                await entryRepo.AddExpenseEntryForCategory(_cID, expenseEntry);
                return RedirectToAction("Index", "Category");
            }
            else return RedirectToAction("Index", "Category");
        }


        public async Task<PartialViewResult> _AllEntry()
        {
            var data = entryRepo.GetAllExpenseEntries();
            if (data != null && data.Any()) return PartialView(data);
            else return PartialView(null);


        }



        public PartialViewResult _AllEntryByCategory(ExpenseCategory _category)
        {
            var allEntryByCategory = entryRepo.GetExpenseEntriesByCategory(_category);
            if (allEntryByCategory != null && allEntryByCategory.Any()) return PartialView(allEntryByCategory);
            else return PartialView();
        }

    }
}
