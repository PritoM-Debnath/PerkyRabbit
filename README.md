# PerkyRabbit

### project 
# Expense Tracker Web Application

This is a web application designed for tracking expenses in various categories. Users can manage and monitor their expenses using this application.

## Features

- Track expenses in different categories such as "House Rent," "Water Bill," "Electric Bill," "Groceries," "Uber," "Medications," etc.
- Each expense category must be unique, preventing users from creating duplicate categories.
- Utilizes the ASP.NET Core framework 5 or above.
- Uses Entity Framework Core for database interactions.
- Uses MariaDB as the database system.
- Implemented using the C# programming language.
- Utilizes Bootstrap 4 or 5 CSS framework for styling.
- Follows a code-first approach to system development.

## Functionality

- Users can view all expense categories.
- Users can edit or delete specific expense categories.
- Expense amount field accepts only integer or decimal numbers.
- The system prevents recording expenditures for future dates.
- Users can view expenses within a specified date range.
- Users can edit or delete specific expense entries.



##### Project Details
- This is a .net core(.net 6) MVC web app
- Database: mariaDb
- Built using Code-first approach
    - Maintained repository pattern
    - All repository and data-context were added to build services to achieve maximum loose coupling
 
##### Build Guide: 
- To use Database:
    - Please use package manager console
    - execute 
         `` update-database `` As the connectionstring is configuired for root@localhost. please change according to your preference in ExpenseTracker/Data/AppDataContext.cs -> OnCofiguiring

## Technologies Used

- .net framework 6
- Entity Framework Core
- MariaDB
- C# Programming Language
- Bootstrap 5 CSS Framework



