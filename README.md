# PermitAPI

# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started

1.	Software dependencies
2.	Installation process
3.  Creating and Running Migrations

## 1. Software dependencies
***
To setup Permit Api, make sure you have the following dependencies:
* [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/) or equivalent (make sure your IDE of preference supports .NET 6.0)
* [.Net SDK 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) (should install automatically with Visual Studio 2022)

Is also highly recomended to have [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15).

Obs.: This Readme was created using the recommended softwares, so if you run into any issues with your IDE or Db Manager of preference, please let us know se we can uptade this file!

## 2. Installation

After installing the IDE and .Net SDK, to run the project for the first time, first you need to setup the database locally. Open Windows cmd as Administrator and type: `SqlLocalDb create "mssqllocaldb"`. You can check if the server was successfully created when "mssqllocaldb" is shown by typing `SqlLocalDb info`. Now, you need to connect to the newly created "mssqllocaldb" and create a database called "Permit".

To do that, on SSMS, enter the server name "`(LocalDb)\mssqllocaldb`", set authentication as `Windows Authentication` and click `Connect`. Right-click on `Databases` and select "`New Database...`". All you have to do is use "Permit" as database name and click OK.

Download or Clone the Permit project and open it on Visual Studio. You should Build the project and then go to Tools > NuGet Package Manager > Package Manager Console. On "Default project" on the top of the console, select Permit.Persistence. Now, run the command `update-database` to run the project Migrations. If everything runs smoothly, you can check if the Tables were created on SSMS by connecting to the server, selecting the Permit database and checking the "Tables" folder. Now, to run the project, just run Permit.Api by click on the green "play" button on the top-center of Visual Studio and it should open a new browser window with Swagger endpoints for you to test it.


## 3. Creating and Running Migrations
If you need to create a new db migration for the project, on the same Package Manager Console, type `Add-Migration [NAME_OF_MIGRATION]`. This will check the Permit.Persistence.Configurations folder for new changes and create a migration file on "Migrations" folder. To execute the newly created migration, you just need to type `update-database` again to apply the changes on the database.

# Build and Test
Select IIS Express as the Running Platform and click on Play


If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)