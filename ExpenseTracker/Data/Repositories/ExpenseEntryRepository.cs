using ExpenseTracker.Models;

namespace ExpenseTracker.Data.Repositories
{
    public class ExpenseEntryRepository : IExpenseEntryRepository
    {
        private readonly AppDataContext appDataContext;

        public ExpenseEntryRepository(AppDataContext _appDataContext) => this.appDataContext = _appDataContext;

        public IEnumerable<ExpenseEntry> GetAllExpenseEntries()
        {
            return appDataContext.ExpenseEntries.ToList();
        }

        public ExpenseEntry? GetById(int _id)
        {
            return appDataContext.ExpenseEntries.FirstOrDefault(c => c.Id == _id) ?? null;
        }

        public IEnumerable<ExpenseEntry>? GetExpenseEntriesByCategory(ExpenseCategory expenseCategory)
        {
            return appDataContext.ExpenseCategories.Find(expenseCategory).Expenses ?? null;
        }

        public void AddExpenseCategory(ExpenseCategory expenseCategory)
        {
            appDataContext.ExpenseCategories.Add(expenseCategory);
            appDataContext.SaveChangesAsync();
        }

        public void RemoveExpenseCategory(ExpenseCategory expenseCategory)
        {
            appDataContext.ExpenseCategories.Remove(expenseCategory);
            appDataContext.SaveChangesAsync();
        }

        public void UpdateExpenseCategory(ExpenseCategory expenseCategory)
        {
            appDataContext.ExpenseCategories.Update(expenseCategory);
            appDataContext.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return appDataContext.SaveChangesAsync();
        }
    }
}
