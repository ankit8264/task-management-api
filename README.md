# Task Management API

This API provides endpoints for managing tasks and demonstrates the Task management api with the use of several design patterns: Strategy Pattern, Decorator Pattern, Dependency Injection, and Factory Pattern. Here's an overview of the project structure and the design patterns used:

## Project Structure
Controllers: Contains the API endpoints (TaskManagementController) responsible for handling HTTP requests and responses.
Services: Contains the business logic and service implementations.
TaskService: Implements the core task management functionality.
LoggingTaskServiceDecorator: A decorator for logging task operations.
TaskServiceDecorator: A decorator for filtering tasks using the Strategy Pattern.
Services/DomainObject: Contains the domain objects like TaskItem.
Services/Domain/FilterStrategy: Contains the filtering strategies.
ITaskFilterStrategy: Interface defining the strategy for filtering tasks.
CompletedTaskFilterStrategy: Concrete implementation of ITaskFilterStrategy for filtering completed tasks.
Services/Factory: Contains the factory pattern implementation.
TaskServiceFactory: Factory class for creating different implementations of ITaskService. 

### Design Patterns Used

To find where I am using these patterns, search with design pattern name in the solution, you will find that commented in the respective place

1. Strategy Pattern
Folder: Services/Domain/FilterStrategy

Explanation: The Strategy Pattern is used to encapsulate different filtering algorithms. ITaskFilterStrategy defines the interface for filtering tasks, and CompletedTaskFilterStrategy provides a concrete implementation for filtering completed tasks. The TaskService class uses the selected strategy to filter tasks based on completion status.

2. Decorator Pattern
Folder: Services

Explanation: The Decorator Pattern is used to add responsibilities to the TaskService class without altering its structure. TaskServiceDecorator and LoggingTaskServiceDecorator are decorators that enhance the behavior of the TaskService. TaskServiceDecorator adds filtering functionality, and LoggingTaskServiceDecorator adds logging capabilities to the core TaskService operations.

3. Dependency Injection
Folder: Controllers

Explanation: Dependency Injection (DI) is used throughout the application. Controller classes like TaskManagementController receive dependencies like ITaskService through their constructors. In the Startup.cs file, services and their dependencies are registered with the DI container. This promotes loose coupling, making the code more modular and testable.

4. Factory Pattern
Folder: Services/Factory

Explanation: The Factory Pattern is used to create different implementations of ITaskService without exposing the instantiation logic to the client code. TaskServiceFactory is a factory class responsible for creating different implementations of the ITaskService interface based on specific requirements or conditions.

I have created TaskManagementApi.Infra, which gives an idea how we can connect with Azure DB, although I haven't utilize that as I don't have required resources. All the data are hardcoded in service layer
