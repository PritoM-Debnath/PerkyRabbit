namespace ExpenseTracker.Data
{
    public static class AppDataSeeder
    {
        public static void SeedData(AppDataContext context)
        {
            if (!context.ExpenseCategories.Any())
            {
                //“House Rent”, “Water Bill”, “Electric Bill”, “Groceries”, “Uber”, “Medications” 
                context.ExpenseCategories.Add(new Models.ExpenseCategory { CreationDate = DateTime.Now, Name = $"House Rent", Description = $"" });
                context.ExpenseCategories.Add(new Models.ExpenseCategory { CreationDate = DateTime.Now, Name = $"Water Bill", Description = $"" });
                context.ExpenseCategories.Add(new Models.ExpenseCategory { CreationDate = DateTime.Now, Name = $"Electric Bill", Description = $"" });
                context.ExpenseCategories.Add(new Models.ExpenseCategory { CreationDate = DateTime.Now, Name = $"Uber", Description = $"" });
                context.ExpenseCategories.Add(new Models.ExpenseCategory { CreationDate = DateTime.Now, Name = $"Medications", Description = $"" });
                context.SaveChanges();
            }
        }
    }
}
