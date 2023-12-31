﻿using ExpenseTracker.Models;
using Microsoft.AspNetCore.Components;

namespace ExpenseTracker.Data.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly AppDataContext appDataContext;

        public ExpenseCategoryRepository(AppDataContext _appDataContext)
        {
            this.appDataContext = _appDataContext;
        }

        public IEnumerable<ExpenseCategory> GetAllExpenseCategories()
        {
            return appDataContext.ExpenseCategories.ToList();
        }

        public ExpenseCategory? GetByName(string _name)
        {
            return appDataContext.ExpenseCategories.FirstOrDefault(c => c.Name == _name) ?? null;
        }

        public ExpenseCategory? GetById(int _id)
        {
            return appDataContext.ExpenseCategories.FirstOrDefault(c => c.Id == _id) ?? null;
        }

        public async Task<bool> AddExpenseCategory(ExpenseCategory expenseCategory)
        {
            await appDataContext.ExpenseCategories.AddAsync(expenseCategory);
            var IsAdded = await appDataContext.SaveChangesAsync();

            return (IsAdded != 0);
        }

        public async Task RemoveExpenseCategory(ExpenseCategory expenseCategory)
        {
            appDataContext.ExpenseCategories.Remove(expenseCategory);
            //await Task.Run(()=>appDataContext.ExpenseCategories.Remove(expenseCategory));
            await appDataContext.SaveChangesAsync();
        }
        
        public async Task  UpdateExpenseCategory(ExpenseCategory expenseCategory)
        {
            appDataContext.ExpenseCategories.Update(expenseCategory);
            //await Task.Run(()=> appDataContext.ExpenseCategories.Update(expenseCategory));
            await appDataContext.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return appDataContext.SaveChangesAsync();
        }
    }
}
