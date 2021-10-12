Notes for Basic Authentication/Authorization in Blazor

Resources:

ASP.NET Core Blazor authentication and authorization
https://docs.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-3.1

IdentityManager
https://github.com/mguinness/IdentityManager/
    Download: https://github.com/mguinness/IdentityManager/archive/master.zip


Customize IdentityManager:
    Startup.cs:
        Change:
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
        To:
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    appsettings.json:
        Change "DefaultConnection" to your app's Identity DB connection string

