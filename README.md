# PerkyRabbit

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
- Run
