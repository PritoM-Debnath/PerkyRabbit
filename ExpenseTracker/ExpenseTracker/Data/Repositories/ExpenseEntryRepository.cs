﻿using ExpenseTracker.Models;

namespace ExpenseTracker.Data.Repositories
{
    public class ExpenseEntryRepository : IExpenseEntryRepository
    {
        private readonly AppDataContext appDataContext;

        public ExpenseEntryRepository(AppDataContext _appDataContext) => this.appDataContext = _appDataContext;

        public IEnumerable<ExpenseEntry>? GetAllExpenseEntries()
        {
            return appDataContext.ExpenseEntries.ToList() ?? null;
        }

        public ExpenseEntry? GetById(int _id)
        {
            return appDataContext.ExpenseEntries.FirstOrDefault(c => c.Id == _id) ?? null;
        }

        public IEnumerable<ExpenseEntry>? GetExpenseEntriesByCategory(ExpenseCategory expenseCategory)
        {
            if (!string.IsNullOrEmpty(expenseCategory.Name))
            {
                return appDataContext.ExpenseCategories.FirstOrDefault(ec=>ec.Id==expenseCategory.Id).Expenses;
            }else return null;

            
        }

        /*public async Task<bool> AddExpenseEntryForCategory(int categoryId, ExpenseEntry entry)
        {
            var uCategory = appDataContext.ExpenseCategories.FirstOrDefault(ec => ec.Id == categoryId);
            await Task.Delay(1);

            if(uCategory != null)
            {
                entry.Category = uCategory;

                appDataContext.ExpenseEntries.Add(entry);
                var cc = appDataContext.SaveChanges();

                return bool.Parse(cc.ToString());
            }else return false;
        }*/

        public async Task<bool> AddExpenseEntryForCategory(int categoryId, ExpenseEntry entry)
        {
            var category = await appDataContext.ExpenseCategories.FindAsync(categoryId);

            if (category != null)
            {
                entry.Category = category;
                appDataContext.ExpenseEntries.Add(entry);

                int numberOfChanges = await appDataContext.SaveChangesAsync();
                return numberOfChanges > 0;
            }

            return false;
        }


        public async Task RemoveEntryCategory(ExpenseEntry expenseEntry)
        {
            await Task.Run(() => appDataContext.ExpenseEntries.Remove(expenseEntry));
            await appDataContext.SaveChangesAsync();
        }

        public async Task UpdateEntryCategory(ExpenseEntry entry)
        {
            await Task.Run(()=> appDataContext.ExpenseEntries.Update(entry));
            await appDataContext.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return appDataContext.SaveChangesAsync();
        }
    }
}
