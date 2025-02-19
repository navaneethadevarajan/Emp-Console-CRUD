# Employee Management System Console
This project was created using .NET 8.0.405.

The Employee Management System Console is a simple application designed to manage employee information.

It provides functionalities to add, update, delete, and view employee details(CRUD).

The system is built using a three-tier architecture.

## Development
To start the local development server, run:
```bash
dotnet run
```
Once the server is running, the application will execute in the console, and you can interact with it through the command line.

The output will be the following as showed in the image below which is displayed in console and we can interact with the console to perform the CRUD operations.

<img width="355" alt="image" src="https://github.com/user-attachments/assets/c9a6c3f4-653c-4f05-93c4-47f6aa4d53b1" />

## Project Structure
The project follows a three-tier architecture with the following layers:

Data Access Layer (DAL): Contains the data access logic.

Business Logic Layer (BLL): Contains the business logic.

Data Model: Contains the data models.

The below image is the 3-tier architecture of the Employee Management System For Console:

<img width="208" alt="image" src="https://github.com/user-attachments/assets/67fead7b-4e33-4993-af16-75bd6f080fed" />


## Adding a New Feature
To add a new feature, follow these steps:

Define the Data Model: Add a new data model in the Data Model layer.

Implement the Business Logic: Implement the business logic for the feature in the BLL.

Access Data: Implement the data access logic in the DAL.

## Building
To build the project, run:
```bash
dotnet build
```
This will compile your project and store the build artifacts in the bin/ directory.

## Running the Application
To run the application, use the following command:
```bash
dotnet run
```
This will start the application and allow you to interact with it through the console.

## Additional Resources
For more information on using .NET CLI, including detailed command references, visit the .NET CLI Overview and Command Reference.

For .Net CLI-https://learn.microsoft.com/en-us/dotnet/core/tools/

For Console Projects in .Net-https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code
