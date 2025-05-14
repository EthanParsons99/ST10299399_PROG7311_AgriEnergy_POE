# Agri-Energy Connect - Prototype

## Project Overview
This is the repository for the prototype of the Agri-Energy Connect web application. The project uses ASP.NET MVC and SQLite. The goal of the application is to have a platform in which farmers and employees can connect. Farmers are allowed to add more products and view products in the marketplace. Employees can add new farmers to the application and filter products that have been added.

## Features
- User Authentication: Login feature with role-based access
### Employee
- Add new farmers to the application
- View all products that have been added by farmers
- Filter the products based on the category and date
### Farmer
- Add products to the marketplace
- Are able to view the marketplace
- View personal product listings
  
## Technolgy Used
- ASP.NET MVC (Visual Studio 2022)
- SQLite Database
- Entity Framework Core
- C#

## Running the project
### Prerequisites
- Visual Studio 2022
- .NET 6.0 or later
- SQLite
- Git

### Installation
1. Clone the repository from Github
   link paste
2. Open the solution file (.sln) in Visual Studio 2022
3. The SQLite database file is within the project folder so no setup is required.
4. Build the solution: Navigate to Build in the menu and select Build Solution
   Build > Build Solution
5. Run the application

## NuGet Packages
Make sure these packages are installed before running the application
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools

## User Guide
Once you have it running you can use the wb application as it has a very simple UI design. There is seeded accounts within the database.
## Employee Account
- Username: Admin1
- Password: admin1
- Email: admin1@gmail.com
---------------------------------------------------------------------------
- Username: Admin2
- Password: admin2
- Email: admin2@gmail.com
---------------------------------------------------------------------------
- Username: Admin3
- Password: admin3
- Email: admin3@gmail.com
---------------------------------------------------------------------------
- Username: Admin4
- Password: admin4
- Email: admin4@gmail.com
---------------------------------------------------------------------------
- Username: Admin5
- Password: admin5
- Email: admin5@gmail.com
---------------------------------------------------------------------------
## Farmer Account
- Username: Pieter
- Password: pieter123
- Email: pieter@gmail.com
---------------------------------------------------------------------------
- Username: John
- Password: john123
- Email: john@gmail.com
---------------------------------------------------------------------------
- Username: Jasper
- Password: jasper123
- Email: jasper@gmail.com
---------------------------------------------------------------------------
- Username: Manie
- Password: manie123
- Email: manie@gmail.com
---------------------------------------------------------------------------
- Username: Fanie
- Password: fanie123
- Email: fanie@gmail.com
---------------------------------------------------------------------------
## Using the Application as Employee
**1. Login**
   - After running the project navigate to the login
   - Enter the required Employee details given above
   - The system will redirect you to the Employee Dashboard
   
**2. Managing Farmers**
   - On the dashboard you can navigate to the page to add new farmers page
   - Enter the required fields with the farmers details and click add farmer
   - The farmers information will be saved to the database
   
**3. Viewing Products**
   - Using either the navigation bar at the to or going back to the dashboard you can go to the page to view added products
   - On the page you are able to see all products that have been added by farmers or filter the products
   
**4. Logout**
   - There is also a logout option on the right hand side of the navigation bar
     
## Using the Application as a Farmer
**1. Login**
   - After running the project navigate to the login
   - Enter the seeded farmer details given above or use the details you added as employee
   - You will then be redirected to the Farmer Dashboard
   
**2. Adding Products**
   - Navigate to the add products page
   - Enter all the required fields and click add product.
   - The product should then save to the database and display in the market place
   
**3. Viewing products**
   - From the dashboard click on My products
   - You will then see the products you have added
   
**4. Marketplace**
   - If you navigate to the marketplace you will be able to see all products from diffrent accounts.
   
**5. Logout**
   - There is also a logout option on the right hand side of the navigation bar

## Project Stucture
- Controllers: handles the functionality of the project
- Models: contains the data of the project and database context
- View: the UI of the project

## Future Changes
- Edit feauture: Allowing farmers and employees to change things they have added like farmers being able to change product information they added and employees being able to update farmer information
- Delete feature: Allwoing farmers to delete products they have added and employees to delete farmers they have added.

## Refrences

