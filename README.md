# SMSApp

Welcome to SMSApp! This is a web application for student registration.

## Getting Started

Follow these steps to set up and run the SMSApp on your local machine:

### Prerequisites

- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/shiva2013-tech/SMSApp.git
    ```

2. Change to the project directory:

    ```bash
    cd SMSApp
    ```

3. Update the database connection string in `appSettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "YourDatabaseConnectionString"
      },
      // Other settings...
    }
    ```

4. Open a terminal and run the following commands to migrate and update the database:

    ```bash
    dotnet ef database update
    ```

5. Run the project:

    ```bash
    dotnet run
    ```

6. Open your web browser and navigate to [http://localhost:7276/Student/Registration](http://localhost:7276/Student/Registration)

7. Fill out the student registration form.

8. After submitting the form, navigate to [http://localhost:7276/admin/login](http://localhost:7276/admin/login)

9. Log in with the following credentials:
   - Username: admin@example.com
   - Password: Default@123

10. You should now see the submitted forms on the admin dashboard.

## Contributing

Feel free to contribute to SMSApp by following the [contribution guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE.md).

## Acknowledgments

Thank you for using SMSApp!

