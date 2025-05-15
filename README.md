# FlyMe2theMoon – Airline Desktop Management System


---

## About

**FlyMe2theMoon** is a Windows Forms (VB‑NET) desktop application that helps a small airline manage its day‑to‑day operations. The system supports role‑based access for administrators, pilots, flight attendants, and passenger‑service agents, allowing them to perform common tasks such as scheduling flights, maintaining employee and passenger records, and reviewing simple statistics.

## Features

* **Role‑based authentication** for *Admin*, *Pilot*, *Attendant*, and *Passenger* users.
* **CRUD screens** for employees, passengers, aircraft, and flights.
* **Flight scheduling** with aircraft and crew assignment.
* **Operational dashboard** that shows total flights, passenger counts, and other at‑a‑glance metrics.
* **SQL Server backend** using stored procedures (mixed with inline SQL) accessed through `OleDb` connections.
* **Modular validation helpers** for common field checks.

## Requirements

| Component      | Version                                          |
| -------------- | ------------------------------------------------ |
| Windows        | 10 / 11                                          |
| .NET Framework | 4.7.2                                            |
| Visual Studio  | 2019 (16.0) or newer (Community edition is fine) |
| SQL Server     | 2019 Express or higher                           |
| (Optional) Git | Latest                                           |

## Getting Started

### Clone the Repository

```bash
# SSH
git clone git@github.com:YourOrg/FlyMe2theMoon.git
# or HTTPS
git clone https://github.com/YourOrg/FlyMe2theMoon.git
cd FlyMe2theMoon
```

### Database Setup

1. Create a new database called **FlyMe2theMoon** in SQL Server.
2. Execute the script https://github.com/glebovski1/CincinnatiState-FlyMe2theMoonApp/blob/master/SQLUpdatedDatabaseWithStoredProcedures.sql that will create database with all tables and required stored procedure.
3. Confirm that tables such as `Employees`, `Passengers`, and `Flights` now exist.



### Build & Run

1. Open `Project_2_HU.sln` in Visual Studio.
2. Ensure the startup project is **Project\_2\_HU**.
3. Press **F5** (Debug→Start Debugging) or **Ctrl+F5** to run without debugger.
4. On first launch, log in with the default admin credentials: **Username:** `admin` **Password:** `admin` *(change immediately in Production).*

## Project Structure

```
Project_2_HU/
├── App.config              # Runtime configuration & DB connection
├── frmLogin.vb             # Main login form
├── frmAddFlight.vb         # Flight creation UI + logic
├── frmEmployee*.vb         # Employee CRUD forms
├── modValidation.vb        # Input validation helpers
├── modDatabase.vb          # Open/Close DB utilities
├── Database/
│   └── Scripts/            # SQL scripts to create & seed DB
└── README.md               # (this file)
```

## Database Schema Overview

| Table        | Purpose                                            |
| ------------ | -------------------------------------------------- |
| `Employees`  | Core employee data, linked to role‑specific tables |
| `Pilots`     | Pilot‑specific license & rank info                 |
| `Attendants` | Cabin crew details                                 |
| `Passengers` | Passenger contact information                      |
| `Flights`    | Flight schedule and aircraft assignment            |
| `Bookings`   | Relationship table between passengers and flights  |

> **Stored Procedures:** The project ships with stored procs like `usp_InsertFlight`, `usp_UpdateEmployee`, etc. Inline SQL queries also exist and should be parameter‑ised (see *Security Notes*).

## Security Notes

* **Passwords are currently stored in plain text.** Before production deployment, implement salted hashing (e.g., PBKDF2).
* Replace every inline SQL string that concatenates user input with **parameterised queries** or stored procedures to mitigate SQL injection.
* Wrap DB calls in `Using … End Using` and transactions to avoid connection leaks and ensure atomicity.





## License

This project is licensed under the MIT License – see `LICENSE` for details.
