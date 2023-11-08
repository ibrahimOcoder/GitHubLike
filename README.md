# GitHubLike

This repository has **two** main projects:

1. Backend.
2. Frontend.

Following are the details of these projects:

**Backend:**
The Backend has been developed on **.NET 7 Web APIs** using **EF Core** as the ORM. Following are some key patterns/features that have been integrated in this project:
   1. **A database creator and seeder powershell file** has been provided which upon execution, would get the connection string from the project's appsettings.json (make sure to replace your Db           Server Name and Connection string there) and create a fresh database and would insert all the demo data required to test the application.
   2. **Dependency Injection** has been used for decoupling and seperation of concerns.
   3. **Generic Repository Pattern** has been implemented using **T types** and **System.Reflections** which uses a single repository to create all instances of DbSets and their relative methods.
   4. **Object Orientation** has been heavily implemented.
   5. The project has been broken down into **Modules** which provides more **loose coupling** along with point 2, 3 and 4.
   6. As EF Core has been used so we are not supposed to expose the Entities on the frontend via APIs. To overcome this approach, **AutoMapper** has been used which uses DTOs and mapping                  configurations to convert entities to those DTOs.

**Frontend:**
The Frontend has been developed using **Angular 16**. Following are some key patterns/features that have been used in the project:
  1.  Usage of **RxJs** to avoid using plain subscriptions. This helps in maintaining Observables lifecycles as RxJs handles subscriptions automatically for example no need to use UntilDestroy().
  2.  Usage of **PNPM** instead of NPM for faster installations, deduplication (avoiding multiple copies of same package) and strict mode by which we can not have multiple versions of the same             package.
  3.  **SCAM pattern** has been used to segregate components and provide clear responsbility and dependency.
  4.  **Dependency Injection** has also been used.
