Overview:
The Employee Management System (EMS) is a console-based application designed to manage employee and department data. 
It allows users to add, update, display, and remove employees and departments. 
The system interacts with a PostgreSQL database using stored procedures to perform database operations. 
Technologies Used:
C#: The programming language used to implement the system logic and user interface.
PostgreSQL: The relational database system that stores employee and department data.
Npgsql: A .NET data provider for PostgreSQL, used for interacting with the database.
Console Tables: Used for better display formatting of employee and department data in the console.
Architecture:
The architecture of the Employee Management System follows a layered approach, with the following key components:
Data Model (Entities):Contains auto-implemented properties of the classes Employees and Department.
Data Access Layer (DAL):Contains methods for interacting directly with the PostgreSQL database. This layer performs CRUD operations on departments and employees.
Business Logic Layer (BLL):Contains the business logic for managing departments and employees, using the methods provided by the DAL.
