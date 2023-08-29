using ExpenseTracker.Data.Repositories;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseTracker.Controllers;

public class CategoryController : Controller
{
    private readonly IExpenseCategoryRepository categoryRepo;
    private readonly IExpenseEntryRepository entryRepo;

    public static IEnumerable<ExpenseCategory> AllExpenseCategories { get; set; }

    //public static bool IsCategoryUpdating=false;

    public CategoryController(IExpenseCategoryRepository expenseCategoryRepository, IExpenseEntryRepository expenseEntryRepository)
    {
        categoryRepo = expenseCategoryRepository;
        entryRepo = expenseEntryRepository;
    }

    public IActionResult Index() => View();

    public async Task<PartialViewResult> _AllCategories()
    {
        AllExpenseCategories = await Task.Run(() => categoryRepo.GetAllExpenseCategories());
        return PartialView(AllExpenseCategories);
    }

    public async Task<PartialViewResult> _SingleCategories(string _name)
    {
        var data = await Task.Run(() => categoryRepo.GetByName(_name));
        return PartialView(data);
    }

    public async Task<bool> CheckDuplicateItem(string name)
    {
        bool isDuplicate = await Task.FromResult(AllExpenseCategories.Any(ec => ec.Name == name));
        return isDuplicate;
    }




    public async Task<IActionResult> RemoveCategory(ExpenseCategory _category)
    {
        if (ModelState.IsValid)
        {
            await categoryRepo.RemoveExpenseCategory(_category);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}




