CREATE DATABASE Teams;

USE Teams;

CREATE TABLE Teams
(
	team_id INT PRIMARY KEY IDENTITY,
	team_name VARCHAR(255) NOT NULL,
	country VARCHAR(100) NOT NULL,
	foundation_year INT NOT NULL
);

CREATE TABLE Drivers
(
	driver_id INT PRIMARY KEY IDENTITY,
	first_name VARCHAR(100) NOT NULL,
	last_name VARCHAR(100) NOT NULL,
	birth_date DATE,
	nationality VARCHAR(100) NOT NULL,
	team_id INT FOREIGN KEY REFERENCES Teams(team_id)
);

CREATE TABLE Races
(
	race_id INT PRIMARY KEY IDENTITY,
	race_name VARCHAR(255) NOT NULL,
	[location] VARCHAR(255) NOT NULL,
	race_date DATE NOT NULL,
	season_year INT
);

CREATE TABLE Race_Results
(
	result_id INT PRIMARY KEY IDENTITY,
	race_id INT FOREIGN KEY REFERENCES Races(race_id),
	driver_id INT FOREIGN KEY REFERENCES Drivers(driver_id),
	position INT NOT NULL,
	points DECIMAl(5, 2) NOT NULL,
	laps INT,
	time TIME
);

INSERT INTO Teams (team_name, country, foundation_year) VALUES 
('Red Bull Racing', 'Austria', 2005),
('Mercedes-AMG Petronas', 'Germany', 2010),
('Ferrari', 'Italy', 1929),
('McLaren', 'United Kingdom', 1963),
('Alpine', 'France', 2021),
('Aston Martin', 'United Kingdom', 2021),
('AlphaTauri', 'Italy', 2020),
('Williams', 'United Kingdom', 1977),
('Haas', 'United States', 2016),
('Alfa Romeo', 'Switzerland', 2019);

INSERT INTO Drivers (first_name, last_name, birth_date, nationality, team_id) VALUES 
('Max', 'Verstappen', '1997-09-30', 'Dutch', 1),
('Lewis', 'Hamilton', '1985-01-07', 'British', 2),
('Charles', 'Leclerc', '1997-10-16', 'Monégasque', 3),
('Lando', 'Norris', '1999-11-13', 'British', 4),
('Fernando', 'Alonso', '1981-07-29', 'Spanish', 5),
('Sebastian', 'Vettel', '1987-07-03', 'German', 6),
('Pierre', 'Gasly', '1996-02-07', 'French', 7),
('George', 'Russell', '1998-02-15', 'British', 2),
('Mick', 'Schumacher', '1999-03-22', 'German', 9),
('Valtteri', 'Bottas', '1989-08-28', 'Finnish', 10);

INSERT INTO Races (race_name, [location], race_date, season_year) VALUES 
('Australian Grand Prix', 'Melbourne, Australia', '2023-03-19', 2023),
('Bahrain Grand Prix', 'Sakhir, Bahrain', '2023-03-05', 2023),
('Saudi Arabian Grand Prix', 'Jeddah, Saudi Arabia', '2023-03-19', 2023),
('Monaco Grand Prix', 'Monte Carlo, Monaco', '2023-05-28', 2023),
('British Grand Prix', 'Silverstone, UK', '2023-07-09', 2023),
('Italian Grand Prix', 'Monza, Italy', '2023-09-03', 2023),
('Japanese Grand Prix', 'Suzuka, Japan', '2023-09-24', 2023),
('Brazilian Grand Prix', 'São Paulo, Brazil', '2023-11-05', 2023),
('Abu Dhabi Grand Prix', 'Yas Marina, UAE', '2023-11-26', 2023),
('Singapore Grand Prix', 'Marina Bay, Singapore', '2023-09-17', 2023);

INSERT INTO Race_Results (race_id, driver_id, position, points, laps, time) VALUES 
(1, 1, 1, 25.00, 58, '01:32:15'),
(1, 2, 2, 18.00, 58, '01:32:18'),
(2, 3, 3, 15.00, 57, '01:30:50'),
(2, 4, 4, 12.00, 57, '01:31:10'),
(3, 5, 5, 10.00, 56, '01:32:45'),
(3, 6, 6, 8.00, 56, '01:32:50'),
(4, 7, 7, 6.00, 78, '01:45:30'),
(4, 8, 8, 4.00, 78, '01:45:45'),
(5, 9, 9, 2.00, 52, '01:30:55'),
(5, 10, 10, 1.00, 52, '01:31:20');