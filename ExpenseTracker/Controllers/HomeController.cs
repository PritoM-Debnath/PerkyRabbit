using ExpenseTracker.Data.Repositories;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseTracker.Controllers;

public class HomeController : Controller
{
    private readonly IExpenseCategoryRepository categoryRepo;

    public static IEnumerable<ExpenseCategory> AllExpenseCategories { get; set; }

    public HomeController(IExpenseCategoryRepository expenseCategoryRepository)
    {
        categoryRepo = expenseCategoryRepository;
    }

    public IActionResult Index() => View();

    public async Task<PartialViewResult> _AllCategories()
    {
        AllExpenseCategories = await Task.Run(() => categoryRepo.GetAllExpenseCategories());
        return PartialView(AllExpenseCategories);
    }

    public async Task<bool> CheckDuplicateItem(string name)
    {
        bool isDuplicate = await Task.FromResult(AllExpenseCategories.Any(ec => ec.Name == name));
        return isDuplicate;
    }

    [HttpPost]
    public async Task<IActionResult> _EntryCategory(ExpenseCategory _category)
    {
        if (!string.IsNullOrEmpty(_category.Name))
        {
            if (await CheckDuplicateItem(_category.Name)) TempData["Message"] = @"<script> alert('Duplicate Name!!');</script>";
            else
                if (ModelState.IsValid) await categoryRepo.AddExpenseCategory(_category);
        }
        else TempData["Message"] = @"<script> alert('No Category Name?');</script>";

        return RedirectToAction("Index");
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
