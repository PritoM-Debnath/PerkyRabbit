using ExpenseTracker.Models;

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

        public async Task AddExpenseCategory(ExpenseCategory expenseCategory)
        {
            await appDataContext.ExpenseCategories.AddAsync(expenseCategory);
            await appDataContext.SaveChangesAsync();
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
