use BikeStores;

-- task 1
CREATE PROCEDURE GetCustomersByProduct
    @ProductID INT
AS
BEGIN
    SELECT 
        sales.customers.customer_id AS CustomerID,
        sales.customers.first_name + ' ' + sales.customers.last_name AS CustomerName,
        sales.orders.order_date AS PurchaseDate
    FROM 
        sales.customers, 
        sales.orders, 
        sales.order_items
    WHERE 
        sales.customers.customer_id = sales.orders.customer_id
        AND sales.orders.order_id = sales.order_items.order_id
        AND sales.order_items.product_id = @ProductID;
END;

GetCustomersByProduct 2;
--task2
CREATE TABLE Department (
    ID INT PRIMARY KEY,
    Name NVARCHAR(100)
);
INSERT INTO Department (ID, Name) VALUES 
(1, 'HR'),
(2, 'IT'),
(3, 'Finance'),
(4, 'Marketing'),
(5, 'Sales');

CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Gender CHAR(1),
    DOB DATE,
    DeptId INT FOREIGN KEY REFERENCES Department(ID)
);

INSERT INTO Employee (ID, Name, Gender, DOB, DeptId) VALUES 
(1, 'Suresh Kumar', 'M', '1991-02-05', 1),
(2, 'Meera Iyer', 'F', '1993-04-18', 2),
(3, 'Priya Patel', 'F', '1986-06-15', 3),
(4, 'Arun Raghav', 'M', '1989-09-12', 2),
(5, 'Karthik Rajan', 'M', '1986-08-23', 4),
(6, 'Renu Sharma', 'F', '1994-12-22', 5),
(7, 'Gopal Das', 'M', '1988-07-14', 3),
(8, 'Vijay Menon', 'M', '1983-03-11', 4);


CREATE PROCEDURE UpdateEmployeeDetails 
    @EmployeeID INT,
    @Name NVARCHAR(100),
    @Gender CHAR(1),
    @DOB DATE,
    @DeptId INT
AS
BEGIN
UPDATE Employee
SET Name = @Name,
        Gender = @Gender,
        DOB = @DOB,
        DeptId = @DeptId
WHERE ID = @EmployeeID;
END;

EXEC UpdateEmployeeDetails @EmployeeID = 4, @Name = 'Sri keer', @Gender = 'F', @DOB = '2000-08-19', @DeptId = 3;
SELECT *FROM Employee;


CREATE PROCEDURE GetEmployeesByGenderAndDept 
    @Gender CHAR(1),
    @DeptId INT
AS
BEGIN
SELECT E.ID,E.Name,E.Gender,E.DOB, D.Name AS Department
FROM Employee E
JOIN Department D ON E.DeptId = D.ID
WHERE E.Gender = @Gender AND E.DeptId = @DeptId;
END;
EXEC GetEmployeesByGenderAndDept @Gender = 'F', @DeptId = 2;

CREATE PROCEDURE GetEmployeeCountByGender
    @Gender CHAR(1)
AS
BEGIN
SELECT COUNT(*) AS EmployeeCount
FROM Employee
WHERE Gender = @Gender;
END;

EXEC GetEmployeeCountByGender @Gender = 'M';
--task 3
CREATE FUNCTION CalculateTotalPrice
(
    @ProductID INT,
    @Quantity INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
DECLARE @TotalPrice DECIMAL(10, 2);
SELECT @TotalPrice = (list_price * @Quantity)
FROM production.products
WHERE product_id = @ProductID;
RETURN @TotalPrice;
END;

SELECT dbo.CalculateTotalPrice(1, 5) as TotalPrice;
--task 4
CREATE FUNCTION GetCustomerOrders
(
    @CustomerID INT
)
RETURNS TABLE
AS
RETURN
(
SELECT 
o.order_id,
o.order_date,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS TotalAmount 
FROM sales.orders o
JOIN sales.order_items oi ON o.order_id = oi.order_id
WHERE o.customer_id = @CustomerID
GROUP BY o.order_id, o.order_date
);

SELECT * FROM dbo.GetCustomerOrders(1);

--TASK5
CREATE FUNCTION CalculateTotalSalesForProducts()
RETURNS @TotalSalesTable TABLE
(
    product_id INT,
    product_name VARCHAR(255),
    total_sales DECIMAL(15, 2)
)
AS
BEGIN
INSERT INTO @TotalSalesTable (product_id, product_name, total_sales)
SELECT 
p.product_id,
p.product_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM production.products p
JOIN sales.order_items oi ON p.product_id = oi.product_id
GROUP BY p.product_id, p.product_name;
RETURN;
END;
SELECT * FROM dbo.CalculateTotalSalesForProducts();

-- TASK 6
CREATE FUNCTION GetCustomerTotalSpent()
RETURNS @CustomerTotalSpent TABLE
(
    customer_id INT,
    first_name VARCHAR(255),
	last_name VARCHAR(255),
    total_spent DECIMAL(15, 2)
)
AS
BEGIN
INSERT INTO @CustomerTotalSpent (customer_id, first_name,last_name, total_spent)
SELECT 
c.customer_id,
c.first_name, 
c.last_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_spent
FROM sales.customers c
JOIN sales.orders o ON c.customer_id = o.customer_id
JOIN sales.order_items oi ON o.order_id = oi.order_id
GROUP BY c.customer_id, c.first_name, c.last_name;
RETURN;
END;
SELECT * FROM dbo.GetCustomerTotalSpent();

