CREATE DATABASE OrionProject
USE OrionProject

CREATE TABLE Client
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50),
	LastName VARCHAR(50),
	BirthDate DATE
)

CREATE TABLE Address
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	City VARCHAR(50),
	StreetName VARCHAR(200),
	StreetNumber VARCHAR(20),
	PostalCode VARCHAR(10),
	IdClient int,
	CONSTRAINT FK_Address_Client FOREIGN KEY (IdClient) REFERENCES Client(Id)
)

INSERT INTO Client VALUES('Oseas', 'Arnaud Sanchez', '23/12/1999')
INSERT INTO Address VALUES('Ensanche La Paz', 'Ramon Bienvenido Diaz', '#67', '10117', 1)

SELECT * FROM Client
SELECT * FROM Address