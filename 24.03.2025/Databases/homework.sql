CREATE DATABASE TaxiCompany;

USE TaxiCompany;

CREATE TABLE Drivers (
    id INT PRIMARY KEY,
    [name] VARCHAR(100) NOT NULL,
    phone_number VARCHAR(16) NOT NULL
);

CREATE TABLE Cars (
    id INT PRIMARY KEY,
    license_plate VARCHAR(8) NOT NULL,
    model VARCHAR(200) NOT NULL
);

CREATE TABLE Customers (
    id INT PRIMARY KEY,
    [name] VARCHAR(150) NOT NULL,
    phone_number VARCHAR(16) NOT NULL
);

CREATE TABLE Rides (
    id INT PRIMARY KEY IDENTITY,
    driver_id INT FOREIGN KEY REFERENCES Drivers(id) 
		ON DELETE CASCADE
		ON UPDATE CASCADE,
    car_id INT FOREIGN KEY REFERENCES Cars(id) 
		ON DELETE SET NULL 
		ON UPDATE CASCADE,
    customer_id INT DEFAULT 1 FOREIGN KEY REFERENCES Customers(id) 
		ON DELETE SET DEFAULT
		ON UPDATE SET DEFAULT,
    pickup_location VARCHAR(200) NOT NULL,
    dropoff_location VARCHAR(200) NOT NULL,
    fare DECIMAL NOT NULL,
);

INSERT INTO Drivers
(id, [name], [phone_number])
VALUES
(1, 'Vasil Kunev', '0894559875'),
(2, 'Evgeni Ivanov', '0897666889'),
(3, 'Konstantin Draganev', '0883347321'),
(4, 'Stefan Petrov', '0874543333'),
(5, 'Elenko Vasilev', '0894449090');

INSERT INTO Cars
(id, license_plate, model)
VALUES
(1, 'ST2000BV', 'Skoda'),
(2, 'SO3434BF', 'BMW'),
(3, 'DO4444GH', 'Mercedes'),
(4, 'PL8865VF', 'Mazda'),
(5, 'GB2111KL', 'Nissan');

INSERT INTO Customers
(id, [name], phone_number)
VALUES
(1, 'Stefani Ivanova', '0895889345'),
(2, 'Silvena Fandukova', '087334564'),
(3, 'Petur Stanislavov', '0887666555'),
(4, 'Desislava Trifanova', '0897654321'),
(5, 'Teodor Stefanov', '0887654323');

INSERT INTO Rides
(driver_id, car_id, customer_id, pickup_location, dropoff_location, fare)
VALUES
(1, 1, 1, 'Enina', 'Krun', 20),
(1, 2, 2, 'Cherganovo', 'Stara Zagora', 50),
(2, 3, 3, 'Varna', 'Burgas', 45),
(3, 4, 4, 'Sofia', 'Pernik', 55),
(4, 4, 5, 'Gorno Sahrane', 'Gabarevo', 20);

SELECT * FROM Drivers;
SELECT * FROM Cars;
SELECT * FROM Customers;
SELECT * FROM Rides;

--01.
SELECT * FROM Drivers;
SELECT * FROM Rides;

DELETE FROM Drivers WHERE id = 1;

SELECT * FROM Drivers;
SELECT * FROM Rides;

--02.
SELECT * FROM Cars;
SELECT * FROM Rides;

DELETE FROM Cars WHERE id = 3;

SELECT * FROM Cars;
SELECT * FROM Rides;

--03.
SELECT * FROM Customers;
SELECT * FROM Rides;

DELETE FROM Customers WHERE id = 4;

SELECT * FROM Customers;
SELECT * FROM Rides;

--04.
SELECT * FROM Drivers;
SELECT * FROM Rides;

UPDATE Drivers SET id = 1 WHERE id = 2;

SELECT * FROM Drivers;
SELECT * FROM Rides;

--05.
SELECT * FROM Cars;
SELECT * FROM Rides;

UPDATE Cars SET id = 10 WHERE id = 4;

SELECT * FROM Cars;
SELECT * FROM Rides;

--06.
SELECT * FROM Customers;
SELECT * FROM Rides;

UPDATE Customers SET id = 1000 WHERE id = 5;

SELECT * FROM Customers;
SELECT * FROM Rides;