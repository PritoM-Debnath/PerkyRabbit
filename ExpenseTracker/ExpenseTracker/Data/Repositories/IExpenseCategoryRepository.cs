using ExpenseTracker.Models;

namespace ExpenseTracker.Data.Repositories
{
    public interface IExpenseCategoryRepository
    {
        Task<bool> AddExpenseCategory(ExpenseCategory expenseCategory);
        IEnumerable<ExpenseCategory> GetAllExpenseCategories();
        ExpenseCategory? GetById(int _id);
        ExpenseCategory? GetByName(string _name);
        Task RemoveExpenseCategory(ExpenseCategory expenseCategory);
        Task SaveChangesAsync();
        Task UpdateExpenseCategory(ExpenseCategory expenseCategory);
    }
}