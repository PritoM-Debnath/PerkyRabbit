﻿using ExpenseTracker.Data.Repositories;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace ExpenseTracker.Controllers;

public class HomeController : Controller
{
    private readonly IExpenseCategoryRepository categoryRepo;

    public static IEnumerable<ExpenseCategory> AllExpenseCategories { get; set; }

    //public static bool IsCategoryUpdating=false;

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


    [HttpGet]
    public async Task<IActionResult> _EntryCategory(int _catID)
    {
        TempData["IsCategoryUpdating"] = true; 
        TempData["_catID"] = _catID;

        var data = await Task.Run(()=> categoryRepo.GetById(_catID));
        if(data == null) { return NotFound(); }
        else return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> _EntryCategory(ExpenseCategory _category)
    {
        if (TempData.ContainsKey("IsCategoryUpdating") && (bool)TempData["IsCategoryUpdating"]) 
        {
            if (ModelState.IsValid)
            {
                _category.Id = (int)TempData["_catID"];
                categoryRepo.UpdateExpenseCategory(_category);
                TempData["IsCategoryUpdating"] = false;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(_category.Name))
            {
                if (await CheckDuplicateItem(_category.Name)) TempData["Message"] = @"<script> alert('Duplicate Name!!');</script>";
                else
                    if (ModelState.IsValid) await categoryRepo.AddExpenseCategory(_category);
            }
            else TempData["Message"] = @"<script> alert('No Category Name?');</script>";
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveCategory(ExpenseCategory category)
    { 
        if (ModelState.IsValid)
        {
            await categoryRepo.RemoveExpenseCategory(category);
        }
        return RedirectToAction("Index");
    }


    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}




