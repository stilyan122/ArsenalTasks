CREATE DATABASE ConstructionMaterialsDB;

USE ConstructionMaterialsDB;

CREATE TABLE Categories (
    id INT PRIMARY KEY IDENTITY,
    name NVARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Products (
    id INT PRIMARY KEY IDENTITY,
    name NVARCHAR(100) UNIQUE NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    category_id INT FOREIGN KEY REFERENCES Categories(id)
);

CREATE TABLE Suppliers (
    id INT PRIMARY KEY IDENTITY,
    name NVARCHAR(100) UNIQUE NOT NULL,
    contact_info VARCHAR(200)
);

CREATE TABLE Customers (
    id INT PRIMARY KEY IDENTITY,
    name NVARCHAR(100) NOT NULL,
    phone VARCHAR(20) UNIQUE NOT NULL
);

CREATE TABLE Orders (
    id INT PRIMARY KEY IDENTITY,
    customer_id INT FOREIGN KEY REFERENCES Customers(id),
    order_date DATETIME NOT NULL,
    total_price DECIMAL(10, 2) NOT NULL,
);

CREATE TABLE OrderDetails (
    id INT PRIMARY KEY IDENTITY,
    order_id INT FOREIGN KEY REFERENCES Orders(id),
    product_id INT FOREIGN KEY REFERENCES Products(id),
    quantity INT NOT NULL,
);

CREATE TABLE SupplierProducts (
    id INT PRIMARY KEY IDENTITY,
    supplier_id INT FOREIGN KEY REFERENCES Suppliers(id),
    product_id INT FOREIGN KEY REFERENCES Products(id),
    supply_price DECIMAL(10, 2) NOT NULL,
);

CREATE TABLE Employees (
    id INT PRIMARY KEY IDENTITY,
    name VARCHAR(100) NOT NULL,
    position NVARCHAR(50) NOT NULL
);

INSERT INTO Categories (name) 
VALUES (N'Бои и лакове'), 
       (N'Цимент и лепила'), 
       (N'Инструменти');

INSERT INTO Products (name, price, category_id) 
VALUES (N'Бяла боя', 12.50, 1), 
       (N'Цимент 25кг', 9.80, 2), 
       (N'Чук 500г', 15.00, 3);

INSERT INTO Suppliers (name, contact_info) 
VALUES (N'Строител ООД', N'ул. Индустриална 5, София'), 
       (N'БГ Материали', N'бул. България 12, Пловдив');

INSERT INTO Customers (name, phone) 
VALUES (N'Иван Петров', '0888123456'), 
       (N'Мария Иванова', '0899765432');

INSERT INTO Orders (customer_id, order_date, total_price) 
VALUES (1, '2025-03-16 10:30:00', 22.30), 
       (2, '2025-03-16 11:45:00', 15.00);

INSERT INTO OrderDetails (order_id, product_id, quantity) 
VALUES (1, 1, 1), 
       (1, 2, 1), 
       (2, 3, 1);

INSERT INTO SupplierProducts (supplier_id, product_id, supply_price) 
VALUES (1, 1, 10.00), 
       (2, 2, 8.50);

INSERT INTO Employees (name, position) 
VALUES (N'Георги Димитров', N'Касиер'), 
       (N'Петър Николов', N'Управител');