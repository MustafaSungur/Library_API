# **LibraryAPI Project**
## Introduction
Welcome to the LibraryAPI project! This project is a robust library management system aimed at assisting librarians, employees, and members in efficiently managing library resources. It includes features for book management, member management, loan management, and more, all with a focus on scalability, security, and ease of use.

##  Project Overview
The LibraryAPI project is a RESTful API developed using ASP.NET Core. It offers endpoints for managing various library resources, including books, authors, categories, and members. The project also supports functionalities for handling loans, calculating penalties, and managing user roles and authentication. The API is designed to cater to different roles—librarians, employees, and members—each with specific permissions and capabilities.
## Technologies Used
This project utilizes a variety of technologies to ensure a robust and efficient system. Below is a detailed explanation of the key technologies used:

### ASP.NET Core
ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, internet-connected applications. It is used to build the RESTful API that powers the BlogAPI project.

### Entity Framework Core
Entity Framework Core (EF Core) is an open-source ORM (Object-Relational Mapper) for .NET. It allows developers to work with a database using .NET objects, eliminating the need for most data-access code.

### Identity Framework
The ASP.NET Core Identity framework is used to manage users, passwords, roles, and claims. It provides a complete, customizable authentication and authorization system. It integrates seamlessly with EF Core to handle the storage and retrieval of user-related data.

### JWT (JSON Web Tokens)
JWT is used for securely transmitting information between parties as a JSON object. It is used for authentication and authorization in the BlogAPI project.

### SQL Server
SQL Server is a relational database management system developed by Microsoft. It is used as the database for the BlogAPI project to store all the blog data.

### Swagger
Swagger is an open-source tool for documenting APIs. It provides a user-friendly interface to explore and test API endpoints. The BlogAPI project includes Swagger for API documentation and testing.
# Project Structure

    libAPI/
    ├── Models/
    ├── DTOs/
    ├── Migrations/
    ├── Services/
    │   ├── Abstract/
    │   ├── Concrete/
    ├── Repositories/
    │   ├── Abstract/
    │   ├── Concrete/
    ├── Controllers/
    │   ├── Auth/
    ├── Data/

### Key Folders and Files
- **Controllers/:** Contains the API controllers that handle HTTP requests.
- **DTOs/:** Contains Data Transfer Objects used for data encapsulation.
- **Data/:** Contains the database context and migration files and repository files.
- **Services/:** Contains the service classes implementing the business logic.


## Model Classes
The model classes represent the entities in the database. Here are some key model classes used in the project:

### ApplicationUser
Represents a user in the system with properties like Id, Name, Email, and more.

## Endpoints
The LibraryAPI provides various endpoints for managing library resources. Here is a table of the key endpoints and their purposes:

### Authentication Endpoints 

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
|  POST |  /api/auth/Login |  Logs in a user and returns a JWT token |
|  POST   | /api/auth/ForgetPassword	   |  Generates a password reset token and sends it via email |
| POST  |  /api/auth/ResetPassword | Resets the password using the provided token and new password   |

### AddressCities Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
|  GET |  	/api/AddressCities |  Retrieves all address cities |
|  GET   | 	/api/AddressCities/{id}   | Retrieves a specific address city by ID|
| PUT  |  /api/AddressCities/{id}| Updates the details of a specific address city (Admin only)  |
| POST	| /api/AddressCities | Creates a new address city (Admin only) |
| DELETE	| 	/api/AddressCities |  Deletes a specific address city (Admin only) |

### AddressCountries Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  | /api/AddressCountries  |  Retrieves all address countries |
|  GET | 	/api/AddressCountries/{id}  |  Retrieves a specific address country by ID |
| PUT  |/api/AddressCountries/{id}   |  Updates the details of a specific address country (Admin only) |
| POST  |  	/api/AddressCountries |  Creates a new address country (Admin only) |
| DELETE  |  /api/AddressCountries/{id} |  Deletes a specific address country (Admin only) |

### Authors Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  |  /api/Authors |Retrieves all authors|
| GET |  	/api/Authors/{id}  | 	Retrieves a specific author by ID  |
| PUT  |  /api/Authors/{id}	 | Updates the details of a specific author (Admin, Worker only)  |
| POST  |  	/api/Authors | Creates a new author (Admin, Worker only)  |
|  DELETE |	/api/Authors/{id}   | Deletes a specific author (Admin, Worker only)  |

### Books Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  | /api/Books  | 	Retrieves all books  |
| GET  | 	/api/Books/{id}  |  	Retrieves a specific book by ID |
| PUT  |	/api/Books/{id}   | 	Updates the details of a specific book (Admin, Worker only)  |
|  POST |  	/api/Books |  Creates a new book (Admin, Worker only) |
| PUT | 	/Api/Books/Stock/{ISBM}  |  Updates the stock of a book by ISBM (Admin, Worker only) |
|DELETE   | 	/api/Books/{id}	  | Deletes a specific book (Admin, Worker only)  |
|  POST| 	/api/Books/Rate/{id}  |  Rates a specific book (Member only) |

### BorrowBooks Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  |  	/api/BorrowBooks | 	Retrieves all borrowed books (Admin, Worker only)  |
| GET  | 	/api/BorrowBooks/{id}  |  	Retrieves a specific borrowed book by ID (Admin, Worker only) |
| PUT  |  /api/BorrowBooks/{id} | Updates the details of a specific borrowed book (Admin, Worker only)  |
| POST  | 	/api/BorrowBooks  | 	Creates a new borrowed book record (Admin, Worker only)  |
| DELETE  |  	/api/BorrowBooks/{id} | 	Deletes a specific borrowed book record (Admin, Worker only)  |

### Categories Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  |  	/api/Categories | 	Retrieves all categories  |
| GET  |  	/api/Categories/{id} | 	Retrieves a specific category by ID  |
| PUT  | 	/api/Categories/{id}  | Updates the details of a specific category (Admin, Worker only)  |
| POST  |  	/api/Categories |  	Creates a new category (Admin, Worker only) |
|  DELETE | 	/api/Categories/{id}  |  	Deletes a specific category (Admin, Worker only) |

### Departments Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
|GET   |  /api/Departments | Retrieves all departments (Admin only)  |
| GET |  /api/Departments/{id} | Retrieves a specific department by ID (Admin only)  |
| PUT  | /api/Departments/{id}  |  Updates the details of a specific department (Admin only) |
| POST  | 	/api/Departments  |  Creates a new department (Admin only) |
|  DELETE |  	/api/Departments/{id} | Deletes a specific department (Admin only)  |

### EducationalDegrees Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  | 	/api/EducationalDegrees  |  Retrieves all educational degrees (Admin only) |
| GET  |  	/api/EducationalDegrees/{id} |  Retrieves a specific educational degree by ID (Admin only) |
| PUT  | 	/api/EducationalDegrees/{id}  |  Updates the details of a specific educational degree (Admin only) |
| POST  | 	/api/EducationalDegrees  |  Creates a new educational degree (Admin only) |
| DELETE  |  /api/EducationalDegrees/{id} |  Deletes a specific educational degree (Admin only) |

### Employees Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  |  	/api/Employees | 	Retrieves all employees (Admin only)  |
| GET  |  	/api/Employees/{id} |  	Retrieves a specific employee by ID (Admin only) |
|  PUT	 | 	/api/Employees/{id}  | Updates the details of a specific employee (Admin only)  |
| POST  | /api/Employees  |  	Creates a new employee (Admin only) |
| DELETE  | /api/Employees/{id}  |  Deletes a specific employee (Admin only) |


### EmployeeTitles Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  | /api/EmployeeTitles  | 	Retrieves all employee titles (Admin only)  |
| GET  |  	/api/EmployeeTitles/{id} |  Retrieves a specific employee title by ID (Admin only) |
| PUT  | 	/api/EmployeeTitles/{id}  | Updates the details of a specific employee title (Admin only)  |
|  POST | /api/EmployeeTitles  |  	Creates a new employee title (Admin only) |
| DELETE  | 	/api/EmployeeTitles/{id}  | 	Deletes a specific employee title (Admin only) |

### Genres Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  | 	/api/Genres |  Retrieves all genres (Admin only) |
| GET  | 	/api/Genres/{id}  | 	Retrieves a specific genre by ID (Admin only)  |
|  PUT | 	/api/Genres/{id}  | Updates the details of a specific genre (Admin only)  |
|  POST | /api/Genres  | 	Creates a new genre (Admin only)  |
| DELETE  |  /api/Genres/{id} |  Deletes a specific genre (Admin only) |

### Languages Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  | 	/api/Languages  | Retrieves all languages (Admin only)  |
| GET  | 	/api/Languages/{id}  |  Retrieves a specific language by ID (Admin only) |
| PUT  | 	/api/Languages/{id}  | 	Updates the details of a specific language (Admin only)  |
| POST  | 	/api/Languages  | 	Creates a new language (Admin only)  |
| DELETE  | 	/api/Languages/{id}  |  Deletes a specific language (Admin only) |

### Locations Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
|  GET |  /api/Locations | 	Retrieves all locations (Admin, Worker only)  |
| GET  | 	/api/Locations/{id}  | Retrieves a specific location by ID (Admin, Worker only)  |
|  PUT |  	/api/Locations/{id} | Updates the details of a specific location (Admin, Worker only)  |
| POST  | 	/api/Locations  |  	Creates a new location (Admin, Worker only) |
|  DELETE |  	/api/Locations/{id} | 	Deletes a specific location (Admin, Worker only)  |

### Members Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  | 	/api/Members | Retrieves all locations (Admin, Worker only)  |
| GET  | /api/Members/History/{memberId} | Retrieves a specific location by ID (Admin, Worker only)  |
| GET  |	/api/Members/{id}  | Retrieves a specific location by ID (Admin, Worker only)  |
| PUT  |  /api/Members/{id} | Updates the details of a specific member (Admin, Worker only) |
| POST  | 	/api/Members | Creates a new member |
| DELETE  | 	/api/Members/{id} |  	Deletes a specific member (Admin, Worker only) |
| POST  | /api/Members/Ban/{id}  |  	Bans a specific member (Admin, Worker only) |
| POST  | /api/Members/RemoveBan/{id} | Removes ban from a specific member (Admin, Worker only)|

### Publishers Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
|  GET | 	/api/Publishers   | 	Retrieves all publishers (Admin, Worker only) |
| GET  | 	/api/Publishers/{id}  |  	Retrieves a specific publisher by ID (Admin, Worker only) |
| PUT  | /api/Publishers/{id}  | Updates the details of a specific publisher (Admin, Worker only)  |
| POST  | /api/Publishers  |  Creates a new publisher (Admin, Worker only) |
|  DELETE | 	/api/Publishers/{id}  |  	Deletes a specific publisher (Admin, Worker only) |

### Shifts Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET | 	/api/Shifts  |  	Retrieves all shifts (Admin only) |
| GET  |  	/api/Shifts/{id} |  	Retrieves a specific shift by ID (Admin only) |
|  PUT |  /api/Shifts/{id} | Updates the details of a specific shift (Admin only)  |
|  POST |  /api/Shifts | 	Creates a new shift (Admin only)  |
|DELETE   |  	/api/Shifts/{id} | 	Deletes a specific shift (Admin only)  |

### SubCategories Endpoints

|  HTTP Method |Endpoint	   | Purpose  |
| ------------ | ------------ | ------------ |
| GET  | 	/api/SubCategories  |  	Retrieves all subcategories |
| GET  | 	/api/SubCategories/{id}  | Retrieves a specific subcategory by ID  |
|  PUT | 	/api/SubCategories/{id}	  |  	Updates the details of a specific subcategory (Admin, Worker only) |
|  POST | /api/SubCategories  | Creates a new subcategory (Admin, Worker only)  |
| DELETE  |  /api/SubCategories/{id} |  	Deletes a specific subcategory (Admin, Worker only) |

## Testing the Project
To test the project, follow these steps:
### Access the Swagger UI
Open your browser and navigate to:
https://localhost:44394/swagger

### Authentication and Authorization
**1. Login as Admin:**
Endpoint: POST /api/auth/Login


    {
        "email": "admin@admin.com",
        "password": "Admin123!"
    }

* Copy the token from the response.

**2.  Authorize:**
- Click on the "Authorize" button in Swagger.
- Paste the token and click "Authorize".

**2.  Create an Employee:**
- Endpoint: POST /api/Employees
- Employee Status: Working, Quit
- JSON Body:

        {
          "applicationUserCreateDTO": {
            "firstName": "Employee",
            "lastName": "Test",
            "genderId": 1,
            "address": {
              "addressCountryId": 1,
              "addressCityId": 1,
              "clearAddress": "Test Address"
            },
            "birthDate": "1985-07-28T11:00:45.043Z",
            "phoneNumber": "12457897",
            "email": "employe@test.com",
            "password": "Test123!",
            "confirmPassword": "Test123!"
          },
          "titleId": 1,
          "departmentId": 1,
          "salary": 35000,
          "shiftId": 1
        }

**6. Login as Employee:**
- Repeat the login and authorization steps using the employee's credentials.

**5. Create a Location:**
- Endpoint: POST /api/Locations
- JSON Body:

       {
            "Shelf": "A11"
       }

**6. Create a Language:**
- Endpoint: POST /api/Languages
- JSON Body:



      {
            "code": "TUR",
            "name": "Türkçe"
      }

- Create a Category:
- Endpoint: POST /api/Categories
- JSON Body:



      {
            "name": "Novel"
      }

**7. Create a SubCategory:**
- Endpoint: POST /api/SubCategories
- JSON Body:



        {
            "name": "Epic Fantasy",
            "categoryId": 1
        }


**11. Create an Author:**
- Endpoint: POST /api/Authors
- JSON Body:



      {
        	"FullName": "George R. R. Martin",
        	"Biography":"George Raymond Richard Martin, Amerikalı yazar ve fantezi, korku ve bilimkurgu senaryo yazarı.",
        	"BirthDate":"1948-09-20",
        	"DeadYear": null
      }

**12. Create a Publisher:**
- Endpoint: POST /api/Publishers
- JSON Body:


        {
          "name": "Test Publisher",
          "phone": "12345678912",
          "email": "test@test.com",
          "contactPerson": "Test Person"
        }

**12. Create a Book:**
- Endpoint: POST /api/Books
- JSON Body:


      {
            "title": "Taht Oyunları",
            "isbn": "1234567890123",
            "PageCount": "1502",
            "publicationYear": 1996,
            "description": "Taht Oyunları, Amerikan yazar George R. R. Martin'in yazmakta olduğu epik fantezi roman serisi Buz ve Ateşin Şarkısı'nın ilk romanıdır. "
            "printCount": 5,
            "locationId": 1,
            "photoUrl": null,
            "CopyCount": 1,
            "publisherId": 1,
            "authorIds": [1],
            "languageId": [1],
            "subCategoryIds": [1]
      }


![355953098-2c30124e-c76e-4048-b3e6-0fce4f06b4f2](https://github.com/user-attachments/assets/2269e23d-0bad-4007-934b-fd2945aaa546)

![image](https://github.com/user-attachments/assets/b275e766-f237-48b6-9098-bcf0cab1974c)



**13. Create an Educational Degree:**
- Endpoint: POST /api/EducationalDegrees
- JSON Body:



        {
          "degree": "Üniversite"
        }

**14. Create a Member Account:**
- Endpoint: POST /api/Members
- JSON Body:


        {
          "applicationUserCreateDTO": {
            "firstName": "member",
            "lastName": "test",
            "genderId": 1,
            "address": {
              "addressCountryId": 1,
              "addressCityId": 1,
              "clearAddress": "Test Address"
            },
            "birthDate": "2000-07-28T11:05:00.589Z",
            "photoUrl": null,
            "phoneNumber": "14578985",
            "email": "member@test.com",
            "password": "member123!",
            "confirmPassword": "member123!"
          },
          "educationalDegreeId": 1
        }

**15. Borrow a Book:**
- Endpoint: POST /api/BorrowBooks
- JSON Body:



        {
          "memberId": "member ID",
          "rentalDate": "2024-08-07T19:11:59.744Z",
          "deadline": "2024-08-24T19:11:59.744Z",
          "booksId": [
            1
          ]
        }

**16. Return a Book:**
- Endpoint: DELETE /api/BorrowBooks/{id}

**17. Rate a Book:**
- Endpoint: POST /api/Books/Rate/{id}
- JSON Body:


        {
    	    "rate": 5
        }

![image](https://github.com/user-attachments/assets/b481e9b1-6496-447d-b133-78c229a9cfc5)


### Acknowledgements
This project was developed as part of the backend program at Softito Yazılım - Bilişim Akademisi. Special thanks to the instructors and peers who provided valuable feedback and support throughout the development process.
