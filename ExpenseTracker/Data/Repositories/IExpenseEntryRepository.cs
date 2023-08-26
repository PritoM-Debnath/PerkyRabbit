﻿using ExpenseTracker.Models;

namespace ExpenseTracker.Data.Repositories
{
    public interface IExpenseEntryRepository
    {
        void AddExpenseCategory(ExpenseCategory expenseCategory);
        IEnumerable<ExpenseEntry> GetAllExpenseEntries();
        ExpenseEntry? GetById(int _id);
        IEnumerable<ExpenseEntry>? GetExpenseEntriesByCategory(ExpenseCategory expenseCategory);
        void RemoveExpenseCategory(ExpenseCategory expenseCategory);
        Task SaveChangesAsync();
        void UpdateExpenseCategory(ExpenseCategory expenseCategory);
    }
}