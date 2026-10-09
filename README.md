# Virtual Bookshelf

**Virtual Bookshelf** is a web application developed with ASP.NET Core MVC to simplify library management and improve the experience of discovering, requesting, and reviewing books.

The application provides a centralized platform where users can browse the available book collection, manage their wishlists, submit borrowing and return requests, write book reviews, and manage their personal profiles. It also provides administrative functionality for managing books and handling borrowing and return requests.

The application uses role-based authorization to distinguish between regular users and administrators, ensuring that each role has access to the appropriate features.

## Features

### Book Collection

- Browse the available books in the library.
- View book covers, titles, and categories.
- Explore the book collection without authentication.
- Access book-related actions when authenticated.
- Discover books through the Bookshelf page.

### User Accounts and Authentication

- Register and log in using an individual account.
- Assign the regular user role to newly registered accounts.
- Restrict administrative functionality based on user roles.
- View and update personal profile information.
- Update first name, last name, gender, email address, profile picture, and password.
- Access authenticated features according to the assigned role.

### Wishlist Management

- Add books to a personal wishlist.
- View saved books in one place.
- Remove books from the wishlist.
- Request books directly from the wishlist.
- Return to the Bookshelf page to discover additional books.

### Book Reviews and Ratings

- Submit reviews for available books.
- Rate books using a star-based rating system.
- Provide written feedback about books.
- View existing reviews to help other readers discover books.

Reviews require a written description and a rating of at least one star.

### Book Borrowing and Return Requests

- Submit requests to borrow books.
- Specify the requested date and provide a description.
- Allow administrators to review and approve or reject borrowing requests.
- Submit requests to return borrowed books.
- Allow administrators to approve or reject return requests.
- Display notifications related to the book return process.

### Administration

Administrators have access to dedicated management pages and additional functionality, including:

- Add new books to the collection.
- Edit existing book information.
- Delete books.
- Review and approve or reject borrowing requests.
- Review and approve or reject return requests.

When editing a book, administrators can update its information except for its ISBN.

## Additional Pages

- **Home:** Provides access to the main application sections and the Bookshelf page.
- **About Us:** Presents information about the library and its events.
- **Bookshelf:** Displays the available book collection and provides access to book-related actions.
- **Wishlist:** Allows authenticated users to manage their saved books and submit borrowing requests.
- **Contact:** Allows users, whether authenticated or not, to send messages to administrators through a contact form.
- **Settings:** Allows authenticated users to view and update their personal profile information.
- **Manage Books:** Provides administrative functionality for adding, editing, and deleting books.
- **Admin Requests:** Allows administrators to manage borrowing requests and access return requests.

## User Roles

### Guest

Unauthenticated visitors can:

- Browse the available books.
- Access the About Us page.
- Access the Contact page.

### Registered User

Authenticated users can:

- Browse the book collection.
- Submit requests to borrow books and return borrowed books.
- Add books to their wishlist and remove saved books.
- Submit book reviews and ratings.
- View existing reviews.
- View and update their personal profile.
- Access the features available to guests.

### Administrator

Administrators have access to regular user functionality, along with additional permissions to:

- Create, edit, and delete books.
- Manage borrowing requests.
- Approve or reject borrowing requests.
- Review and approve or reject return requests.

## Technologies Used

- C#
- ASP.NET Core MVC
- Razor Views
- Entity Framework Core
- Microsoft SQL Server
- ASP.NET Core Identity
- HTML5
- CSS3
- JavaScript

## Application Architecture

The application follows the Model-View-Controller (MVC) architectural pattern, separating request handling, application data, and user interface rendering.

- **Models:** Represent the application's data and entities.
- **Views:** Use Razor (`.cshtml`) files to render the user interface.
- **Controllers:** Handle incoming HTTP requests, coordinate application operations, and select the appropriate views.
- **Entity Framework Core:** Provides database access and object-relational mapping.
- **ASP.NET Core Identity:** Supports user registration, authentication, password management, and role-based authorization.
- **Static Resources:** Stylesheets, JavaScript files, and images are organized within the `wwwroot` directory.

The MVC structure helps organize the application's code and separates presentation logic from request handling and data operations.

## Security

The application implements authentication and role-based authorization using ASP.NET Core Identity.

- User access is restricted according to authentication status and assigned roles.
- Newly registered accounts are assigned the regular user role.
- Passwords are stored using the password-hashing mechanisms provided by ASP.NET Core Identity.
- Administrative operations are restricted to users with the administrator role.
- Entity Framework Core helps protect database operations against SQL injection by using parameterized queries for standard LINQ-based database operations.

## Project Goals

The main goals of Virtual Bookshelf are to:

- Make book discovery accessible and straightforward.
- Provide an organized process for requesting and returning books.
- Allow readers to maintain personalized wishlists.
- Encourage readers to share feedback through reviews and ratings.
- Simplify library administration through dedicated management pages.
- Protect administrative functionality through role-based authorization.
- Provide users with a convenient way to manage their account information.

## Use Case Diagram

The following diagram illustrates the main interactions between guests, registered users, and administrators in the Virtual Bookshelf application.

![Virtual Bookshelf Use Case Diagram](./Library_MVC/wwwroot/Use_Case_Diagram.png)
