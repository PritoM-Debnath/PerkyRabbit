using ExpenseTracker.Models;

namespace ExpenseTracker.Data.Repositories
{
    public interface IExpenseEntryRepository
    {
        Task<bool> AddExpenseEntryForCategory(int categoryId, ExpenseEntry entry);
        IEnumerable<ExpenseEntry> GetAllExpenseEntries();
        ExpenseEntry? GetById(int _id);
        IEnumerable<ExpenseEntry>? GetExpenseEntriesByCategory(ExpenseCategory expenseCategory);
        void RemoveEntryCategory(ExpenseEntry expenseEntry);
        Task SaveChangesAsync();
        Task UpdateEntryCategory(ExpenseEntry entry);
    }
}