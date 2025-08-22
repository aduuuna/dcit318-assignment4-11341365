
# Medical Appointment & Pharmacy Management System

This repository contains two C# projects:

* **Task 1: Medical Appointment System**
* **Task 2: Pharmacy Management System**

Both projects are built with **C#** and use **SQL Server** for database storage.

---

## 🚀 Getting Started

### Prerequisites

* Visual Studio (or any IDE with C# support)
* SQL Server (Express or full edition)
* .NET Framework (as configured in the project)

### Setup Instructions

1. **Clone or Download** this repository.

2. **Open the project** in Visual Studio.

3. **Create the databases manually** in SQL Server using the SQL scripts provided below.

4. **Update the connection string** inside the `App.config` file to match your SQL Server instance.

   ```xml
   <connectionStrings>
       <add name="MyDbConnection" connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=MedicalDB;Integrated Security=True;" providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

   > ⚠️ Replace `YOUR_SERVER_NAME` with your SQL Server instance name. Do the same for **PharmacyDB** in Task 2.

5. **Run the project** from Visual Studio.

---

## 📌 Task 1: Medical Appointment System

This system allows:

* Managing doctors and their specialties.
* Registering patients.
* Scheduling appointments between doctors and patients.

### Database Setup

```sql
-- Create the database
CREATE DATABASE MedicalDB;
GO

USE MedicalDB;
GO

-- Create Doctors table
CREATE TABLE Doctors (
    DoctorID int IDENTITY(1,1) PRIMARY KEY,
    FullName varchar(100) NOT NULL,
    Specialty varchar(100) NOT NULL,
    Availability bit NOT NULL DEFAULT 1
);

-- Create Patients table
CREATE TABLE Patients (
    PatientID int IDENTITY(1,1) PRIMARY KEY,
    FullName varchar(100) NOT NULL,
    Email varchar(100) NOT NULL
);

-- Create Appointments table
CREATE TABLE Appointments (
    AppointmentID int IDENTITY(1,1) PRIMARY KEY,
    DoctorID int NOT NULL,
    PatientID int NOT NULL,
    AppointmentDate datetime NOT NULL,
    Notes varchar(500),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID),
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID)
);

-- Insert sample data
INSERT INTO Doctors (FullName, Specialty, Availability) VALUES
('Dr. John Smith', 'Cardiology', 1),
('Dr. Sarah Johnson', 'Pediatrics', 1),
('Dr. Michael Brown', 'Orthopedics', 1),
('Dr. Emily Davis', 'Dermatology', 1),
('Dr. Robert Wilson', 'Neurology', 0);

INSERT INTO Patients (FullName, Email) VALUES
('Alice Cooper', 'alice.cooper@email.com'),
('Bob Johnson', 'bob.johnson@email.com'),
('Carol Smith', 'carol.smith@email.com'),
('David Wilson', 'david.wilson@email.com'),
('Eva Brown', 'eva.brown@email.com');
```

---

## 📌 Task 2: Pharmacy Management System

This system allows:

* Managing medicines and categories.
* Recording sales transactions.
* Updating stock levels.
* Searching for medicines.

### Database Setup

```sql
-- Create PharmacyDB Database
CREATE DATABASE PharmacyDB;
GO

USE PharmacyDB;
GO

-- Create Medicines Table
CREATE TABLE Medicines (
    MedicineID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Category VARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Quantity INT NOT NULL
);
GO

-- Create Sales Table
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    MedicineID INT FOREIGN KEY REFERENCES Medicines(MedicineID),
    QuantitySold INT NOT NULL,
    SaleDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Stored Procedure: AddMedicine
CREATE PROCEDURE AddMedicine
    @Name VARCHAR(255),
    @Category VARCHAR(100),
    @Price DECIMAL(10,2),
    @Quantity INT
AS
BEGIN
    INSERT INTO Medicines (Name, Category, Price, Quantity)
    VALUES (@Name, @Category, @Price, @Quantity)
END
GO

-- Stored Procedure: SearchMedicine
CREATE PROCEDURE SearchMedicine
    @SearchTerm VARCHAR(255)
AS
BEGIN
    SELECT MedicineID, Name, Category, Price, Quantity
    FROM Medicines
    WHERE Name LIKE '%' + @SearchTerm + '%' OR Category LIKE '%' + @SearchTerm + '%'
END
GO

-- Stored Procedure: UpdateStock
CREATE PROCEDURE UpdateStock
    @MedicineID INT,
    @Quantity INT
AS
BEGIN
    UPDATE Medicines
    SET Quantity = @Quantity
    WHERE MedicineID = @MedicineID
END
GO

-- Stored Procedure: RecordSale
CREATE PROCEDURE RecordSale
    @MedicineID INT,
    @QuantitySold INT
AS
BEGIN
    DECLARE @CurrentStock INT
    
    -- Check current stock
    SELECT @CurrentStock = Quantity FROM Medicines WHERE MedicineID = @MedicineID
    
    IF @CurrentStock >= @QuantitySold
    BEGIN
        -- Record the sale
        INSERT INTO Sales (MedicineID, QuantitySold, SaleDate)
        VALUES (@MedicineID, @QuantitySold, GETDATE())
        
        -- Update stock
        UPDATE Medicines
        SET Quantity = Quantity - @QuantitySold
        WHERE MedicineID = @MedicineID
    END
    ELSE
    BEGIN
        RAISERROR('Insufficient stock available', 16, 1)
    END
END
GO

-- Stored Procedure: GetAllMedicines
CREATE PROCEDURE GetAllMedicines
AS
BEGIN
    SELECT MedicineID, Name, Category, Price, Quantity
    FROM Medicines
    ORDER BY Name
END
GO

-- Insert Sample Data
INSERT INTO Medicines (Name, Category, Price, Quantity) VALUES
('Paracetamol', 'Analgesic', 5.50, 100),
('Amoxicillin', 'Antibiotic', 12.75, 50),
('Ibuprofen', 'Anti-inflammatory', 8.25, 75),
('Cetirizine', 'Antihistamine', 6.00, 60),
('Omeprazole', 'Antacid', 15.30, 40);
GO
```

---

## ⚡ Features

✅ Manage doctors, patients, and appointments.
✅ Manage medicines and categories.
✅ Record and track sales.
✅ Update and search stock efficiently.
✅ Sample data included for quick testing.

---

## 📖 Notes

* Ensure you **update the connection string** in `App.config` before running.
* Run the **SQL scripts** manually to set up your databases.
* You can extend the project by adding authentication, reporting features, or a GUI upgrade.


