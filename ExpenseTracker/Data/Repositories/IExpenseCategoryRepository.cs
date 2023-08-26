using ExpenseTracker.Models;

namespace ExpenseTracker.Data.Repositories
{
    public interface IExpenseCategoryRepository
    {
        Task AddExpenseCategory(ExpenseCategory expenseCategory);
        IEnumerable<ExpenseCategory> GetAllExpenseCategories();
        ExpenseCategory? GetById(int _id);
        ExpenseCategory? GetByName(string _name);
        void RemoveExpenseCategory(ExpenseCategory expenseCategory);
        Task SaveChangesAsync();
        void UpdateExpenseCategory(ExpenseCategory expenseCategory);
    }
}