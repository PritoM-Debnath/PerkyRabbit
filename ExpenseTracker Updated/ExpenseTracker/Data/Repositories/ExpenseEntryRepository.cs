using ExpenseTracker.Models;

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
                return appDataContext.ExpenseCategories.FirstOrDefault(ec => ec.Id == expenseCategory.Id).Expenses;
            }
            else
            {
                return appDataContext.ExpenseEntries.AsEnumerable();
            }
        }

        public async Task AddExpenseEntryForCategory(int categoryId, ExpenseEntry entry)
        {
            var CurrentCategory = appDataContext.ExpenseCategories.FirstOrDefault(ec => ec.Id == categoryId);
            await Task.Delay(1);

            if (CurrentCategory != null)
            {
                entry.Category = CurrentCategory;

                appDataContext.ExpenseEntries.Add(entry);

                appDataContext.SaveChanges();
            }
        }

        public void RemoveEntryCategory(ExpenseEntry expenseEntry)
        {
            _ = appDataContext.ExpenseEntries.Remove(expenseEntry);
            appDataContext.SaveChangesAsync();
        }

        public async Task UpdateEntryCategory(ExpenseEntry entry)
        {
            await Task.Run(() => appDataContext.ExpenseEntries.Update(entry));
            await appDataContext.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return appDataContext.SaveChangesAsync();
        }
    }
}
