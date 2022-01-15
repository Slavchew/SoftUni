CREATE SCHEMA colonial_journey_management_system_db;
USE colonial_journey_management_system_db;

-- 1.   Data Definition Language (DDL) – 30pts

CREATE TABLE planets(
	id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE spaceports(
	id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    name VARCHAR(50) NOT NULL,
    planet_id INT,
    CONSTRAINT fk_spaceports_planets
    FOREIGN KEY (planet_id) REFERENCES planets(id)
);

CREATE TABLE spaceships(
	id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    name VARCHAR(50) NOT NULL,
    manufacturer VARCHAR(30) NOT NULL,
    light_speed_rate INT DEFAULT 0
);

CREATE TABLE colonists(
	id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    first_name VARCHAR(20) NOT NULL,
    last_name VARCHAR(20) NOT NULL,
    ucn CHAR(10) NOT NULL UNIQUE,
    birth_date DATE NOT NULL
);

CREATE TABLE journeys(
	id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    journey_start DATETIME NOT NULL,
    journey_end DATETIME NOT NULL,
    purpose enum('Medical', 'Technical', 'Educational', 'Military'),
    destination_spaceport_id INT,
    spaceship_id INT,
    CONSTRAINT fk_journeys_spaceports
    FOREIGN KEY (destination_spaceport_id) REFERENCES spaceports(id),
    CONSTRAINT fk_journeys_spaceships
    FOREIGN KEY (spaceship_id) REFERENCES spaceships(id)
);

CREATE TABLE travel_cards(
	id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    card_number CHAR(10) UNIQUE NOT NULL,
    job_during_journey enum('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook'),
    colonist_id INT,
    journey_id INT,
    CONSTRAINT fk_travel_cards_colonists
    FOREIGN KEY (colonist_id) REFERENCES colonists(id),
    CONSTRAINT fk_travel_cards_journeys
    FOREIGN KEY (journey_id) REFERENCES journeys(id)
);

-- 2.   Data Manipulation Language (DML) – 30 pts

-- 2.1 Insert values (10 points)
INSERT INTO travel_cards (card_number, job_during_journey, colonist_id, journey_id)
SELECT (
	IF(
		c.birth_date > '1980-01-01',
        concat(YEAR(c.birth_date), DAY(c.birth_date), substring(c.ucn, 1, 4)),
        concat(YEAR(c.birth_date), MONTH(c.birth_date), substring(c.ucn, 7, 4))
    )
) AS card_number, (
	CASE
		WHEN c.id % 2 = 0 THEN 'Pilot'
        WHEN c.id % 3 = 0 THEN 'Cook'
        ELSE 'Engineer'
    END
) AS job_during_journey, (
	c.id
) AS colonist_id, (
	substring(c.ucn, 1, 1)
) AS journey_id
FROM colonists c
WHERE c.id BETWEEN 96 AND 100;

-- 2.2 Update values (10 points)
UPDATE journeys
SET purpose = (
	CASE
		WHEN id % 2 = 0 THEN 'Medical'
        WHEN id % 3 = 0 THEN 'Technical'
        WHEN id % 5 = 0 THEN 'Educational'
        WHEN id % 7 = 0 THEN 'Military'
        ELSE purpose
    END
)
WHERE id > 0;

-- 2.3 Delete values (10 points)
DELETE FROM colonists c
WHERE c.id NOT IN (
	SELECT tc.colonist_id FROM travel_cards tc
);

-- 3 Queries (70 points)

-- 3.1 Select card numbers (10 points)
SELECT card_number, job_during_journey
FROM travel_cards
ORDER BY card_number;

-- 3.2 Select colonists (10 points)
SELECT id, concat_ws(' ', first_name, last_name) AS full_name, ucn
FROM colonists
ORDER BY first_name, last_name, id;

-- 3.3 Select military travels (10 points)
SELECT id, journey_start, journey_end
FROM journeys
WHERE purpose = 'Military'
ORDER BY journey_start;

-- 3.4 Select pilots (10 points)
SELECT (tc.colonist_id) AS id, concat_ws(' ', c.first_name, c.last_name) AS full_name
FROM travel_cards tc
JOIN colonists c
	ON c.id = tc.colonist_id
WHERE tc.job_during_journey = 'Pilot'
ORDER BY id;

-- 3.5 Select fastest ship (10 points)
SELECT (s.name) AS spaceship_name, (sp.name) AS spaceport_name
FROM journeys j
JOIN spaceships s
	ON s.id = j.spaceship_id
JOIN spaceports sp
	ON sp.id = j.destination_spaceport_id
ORDER BY s.light_speed_rate DESC LIMIT 1;

-- 3.6 Select educational missions (10 points)
SELECT (p.name) AS planet_name, (sp.name) AS spaceport_name
FROM journeys j
JOIN spaceports sp
	ON sp.id = j.destination_spaceport_id
JOIN planets p 
	ON p.id = sp.planet_id
WHERE j.purpose = 'Educational'
ORDER BY spaceport_name DESC;

-- 3.7 Planets and journeys (10 points)
SELECT (p.name) AS planet_name, COUNT(p.name)
FROM planets p
JOIN spaceports sp
	ON sp.planet_id = p.id
JOIN journeys j
	ON j.destination_spaceport_id = sp.id
WHERE p.name = p.name
ORDER BY planet_name;







