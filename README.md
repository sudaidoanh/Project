# Using .NET technology to develop the project
## Technologies
- ASP.NET CORE 6.0
- Entity Framwork Core 7.0.5
## Install Packages
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.FileExtensions
- Microsoft.Extensions.Configuration.Json
- Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.16
- Microsoft.AspNetCore.Http.Features" Version="5.0.17

## 17/4 - 20/4 :
- Design ER Database
- Create solution structure project
- Design and configuration database by C# code on Visual Studio
- Migration database to SQL Server local
- And continuing to configure
## 20/4 - 24/4 :
- Complete the database configuration
- Seed data and migration database to SQL Server
- Create application layer structure
- Create system roles and catalog user accounts
- And continuing to develop
## 24/4 - 27/4 :
- Create View Model layer structure
- Create Backend API layer structure
- Create user - admin side functions including: account management (create, delete, query, search and paging), user-side (view profile, edit profile picture and personal information, change change Password)
- Create Backend API gets all user account admin side 
## 27/4 - 4/5 :
- Add swagger to application to manage the API 
- Create Restful API for the administrator to manage the account (get all, get by Id, create new, delete one or many)
- Create authenticate API with JWT return JWT
## 4/5 - 8/5: 
- Add Authorization header to Swagger
- Focus on debugging and reconfiguration
- Create Restful API for user to updates profile, uploads personal image, changes password (image is storaged on server, folder Project.BackendApi/wwwroot/user-content)
- Create Area functions and Area APIs include: Create new area based on area name, load model view of area, load model view based on dependent distributor,
load model view based on dependent user
## 8/5 - 11/5:
- Create Resful API to manage areas, get all areas, get detail area with user view, get detail area with distributor view, add user account using areaId from query uri, add distributor from query uri, remove list users from area, remove list distributors from area
- Create role functions to assign roles
- Create visit planning functions: add new plan
## 11/5 - 15/5: 
- Create Resful API for plan's function according to requirement
- Configure database table Surveys reasonable
- Create functions for Surveys, Details
- Create API controller for Surveys
## 15/5 - 18/5: 
- Create Restful API for survey's function according to requirement
- Create Restful API for task 's function according to requiment
- Create APIs role and assign role for users system
- Integrated email sending via smtp client (Not running)
## Finished late
- Notification API
## Unfinished: 
- Fluent validation
