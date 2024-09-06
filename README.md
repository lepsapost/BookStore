# BookStore API

This project implements a RESTful API that provides comprehensive CRUD (Create, Read, Update, Delete) operations for a bookstore management system.

## Features

- Retrieve a list of all books
- Add new books to the inventory
- Retrieve detailed information for a specific book
- Update existing book information
- Remove books from the inventory (Note: This feature is currently in development and has not been fully tested)

## Technology Stack

- ASP.NET Core 6.0
- Entity Framework Core (utilizing InMemory provider)
- Swagger UI for API documentation and testing

## Setup and Installation

1. Clone the repository to your local machine
2. Navigate to the project directory
3. Execute the command `dotnet run` in your terminal
4. Access the Swagger UI by opening `http://localhost:5105/swagger/index.html` in your web browser

## API Endpoints

- GET /api/Book: Retrieves all books in the inventory
- GET /api/Book/{id}: Retrieves a specific book by its unique identifier
- POST /api/Book: Adds a new book to the inventory
- PUT /api/Book/{id}: Updates the information of an existing book
- DELETE /api/Book/{id}: Removes a book from the inventory (Note: This endpoint is currently under development)

## Usage Examples

### Adding a New Book

Endpoint: POST /api/Book

Request Body:
json
{
"title": "Sample Book Title",
"genreId": 1,
"pageCount": 200,
"publishDate": "2023-06-15T00:00:00"
}


### Updating a Book

Endpoint: PUT /api/Book/4

Request Body:
json
{
"title": "Updated Book Title",
"genreId": 2,
"pageCount": 250,
"publishDate": "2023-06-20T00:00:00"
}


## Important Notes

- This API utilizes an in-memory database. Consequently, all data will be reset upon application restart.
- Sample data is automatically loaded when the application starts to facilitate testing and demonstration.

## Future Enhancements

- Implementation of robust error handling mechanisms
- Introduction of data validation processes
- Development of more complex query capabilities
- Migration to a persistent database system
- Integration of unit tests for improved code reliability

## License

This project is licensed under the MIT License. Please see the LICENSE file for more details.
