Gym Management System - Final Assignment by Aashish Arun and Anderson Neves

Overview
The Gym Management System is a .NET MAUI-based application designed to manage appointments, customers, trainers, and staff for a gym. The system integrates a MySQL database using HeidiSQL to ensure smooth data management and retrieval.

The technologies we used:
- .NET MAUI: Used for cross-platform UI development.
- C# Classes and Inheritance: Used for Object-oriented programming structure.
- Interfaces and Abstract Classes: Used for modular design.
- MySQL & HeidiSQL: Used for database storage and management.
- Exception Handling: Ensures the strength of our database queries and app operations.

Project Goals & Functionality
The application provides:
- Appointment Management: Create, edit, and delete gym bookings.
- Customer Management: Add, update, and remove customers.
- Trainer Management: Maintain trainer records and schedules.
- Staff Management: Track staff roles and contact details.
- MAUI GUI for User Interaction: Offers an intuitive user interface with icon-based navigation.

Classes and Inheritance
The project uses **object-oriented principles:
- Base Classes (Person.cs): Shared attributes for customers, trainers, and staff.
- Inherited Classes (Customer.cs, Trainer.cs, Staff.cs): Extend the base class and add unique properties.
- Interfaces (IAppointment.cs): We tried to implement but faced many issues.

GUI Implementation with .NET MAUI
- The UI is designed with MAUI components for cross-platform compatibility.
- Button icons enhance navigation for Appointment, Customer, Trainer, and Staff.
- Forms and data tables allow users to interact with MySQL data.

Exception Handling
- Database Connection Handling: Ensures MySQL errors don’t crash the app.
- Validation Errors: Prevents invalid data entry (e.g., empty appointment details).
- Custom Exceptions: Used to restrict unavailable features.

How to Run the Project
1. Database Setup:
   - Open HeidiSQL and create the GymManagementSystem database.
   - Run the provided SQL script to initialize tables and insert sample data.

2. Run the App:
   - Open the project in Visual Studio.
   - Set '.NET MAUI' to run on Windows.
   - Press 'Ctrl+F5' to start.

3. Test Features:
   - Add and delete customers via UI and verify updates in HeidiSQL.

Future Enhancements We Plan To Do:
- Authentication for secure logins.
- More detailed reports on gym appointments and trainer schedules.
- Advanced filtering for customer and trainer searches.

Contributors
- Aashish Arun: Database integration and UI implementation.
- Anderson Neves: Classes and Inheritance, and Interface Design

