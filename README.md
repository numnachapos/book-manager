# Book Manager Application

This project is a full-stack Book Manager application built with .NET 8.0 for the backend and Angular for the frontend. It demonstrates the use of Object-Oriented Programming (OOP) principles, SOLID principles, and the Code First approach using Entity Framework Core.

## Features

- **Backend (.NET)**: 
  - CRUD operations for books.
  - OOP design with a base Book class and derived classes like BiographyBook, CryptocurrencyBook, and InvestmentBook.
  - Asynchronous programming with async/await.
  - SOLID principles for maintainable and scalable code.
  - Entity Framework Core with Code First migrations.
  - Integrated Swagger UI for API documentation and testing.

- **Frontend (Angular)**: 
  - User interface for managing books.
  - Interaction with the backend API using HTTP requests.
  - Display of book lists, details, and forms for adding or updating books.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js and npm](https://nodejs.org/) (for the Angular frontend)
- [PostgreSQL](https://www.postgresql.org/download/) database

### Setup Instructions

#### Backend Setup

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/numnachapos/book-manager.git
    ```

2. **Configure Database:**
   Update the `appsettings.json` file in the Backend project with your PostgreSQL database connection string.

   ```json
   {
     "ConnectionStrings": {
       "DbConnectionStringName": "Host=localhost;Database=postgres;Username=postgres;Password=password"
     }
   }
    ```

3. **Run Migrations:**
    Ensure your database is set up correctly by running Entity Framework Core migrations.
    ```bash
    dotnet ef database update
    ```

4. **Run the Backend Application:**
    Start the backend application using the .NET CLI.
    ```bash
    dotnet run
    ```

5. **Access the API:**
     Once the application is running, you can access the API at https://localhost:5001 or http://localhost:5000.

6. **Explore with Swagger:**
    Navigate to https://localhost:5001/swagger to explore the API documentation and test endpoints.

#### Frontend Setup

1. **Navigate to the Frontend Directory:**
    ```bash
    cd ./ClientApp
    ```

2. **Install Dependencies:**
    Use npm to install the necessary dependencies for the Angular project.
    ```bash
    npm install
    ```
3. **Run the Frontend Application:**
    Start the Angular development server.
    ```bash
    ng serve
    ```

4. **Access the Frontend Application:**
    Open your browser and navigate to http://localhost:4200 to view the application.

### API Endpoints
- **POST /api/books/AddBook**: Add a new book to the database.
- **GET /api/books/**: Retrieve all books from the database(optionally filtered by book type) .
- **GET /api/books/GetBooksByType**: Retrieve books filtered by book type (Biography, Cryptocurrency, Investment).
- **GET /api/books/types**: Retrieve all book types.
- **PUT /api/books/UpdateBook/{id}**: Update an existing book by ID.
- **DELETE /api/books/DeleteBook/{id}**: Delete a book by ID.
- **GET /api/books/GetSingleBook/{id}**: Retrieve a single book by ID.

### Code Structure
- **Backend**: The backend application is structured using the MVC pattern with separate folders for Controllers, Services, Models, and Data.
  - **Controllers**: Contains the API endpoints for handling HTTP requests.
  - **Services**: Contains the business logic for handling CRUD operations.
  - **Models**: Contains the data models for the application.
  - **Data**: Contains the database context and migrations.
- **Frontend**: The frontend application is structured using Angular best practices with separate components for Books, BookDetails, BookForm, and BookList.
  - **Components**: Contains the Angular components for the application.
  - **Services**: Contains the Angular services for interacting with the backend API.

### Technologies Used
- **Backend**: .NET 8.0, Entity Framework Core, Swagger.
- **Frontend**: Angular, TypeScript, HTML, CSS.
- **Database**: PostgreSQL.

### Future Improvements
- **Authentication and Authorization**: Implement user authentication and authorization (eg., OAuth2, JWT).
- **Testing**: Add unit tests to cover key functionalities.

### Contribution
Contributions are welcome! Feel free to open an issue or submit at https://github.com/numnachapos/book-manager pull request.

### License
This project is licensed under the MIT License.