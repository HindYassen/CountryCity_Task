-- =============================================
-- CountryCity_Task - Seed Data
-- =============================================

-- =============================================
-- Countries
-- =============================================
SET IDENTITY_INSERT Countries ON;
INSERT INTO Countries (Id, Name, Code)
VALUES
(2, 'Egypt', 'EGY'),
(3, 'United States', 'USA'),
(4, 'United Kingdom', 'GBR'),
(5, 'Canada', 'CAN'),
(6, 'Germany', 'DEU'),
(7, 'France', 'FRA'),
(8, 'Italy', 'ITA'),
(9, 'Spain', 'ESP'),
(10, 'Australia', 'AUS'),
(11, 'Japan', 'JPN'),
(12, 'China', 'CHN'),
(13, 'India', 'IND'),
(14, 'Brazil', 'BRA'),
(15, 'Mexico', 'MEX'),
(16, 'Turkey', 'TUR'),
(17, 'Saudi Arabia', 'SAU'),
(18, 'United Arab Emirates', 'ARE'),
(19, 'Qatar', 'QAT'),
(20, 'Kuwait', 'KWT'),
(21, 'Jordan', 'JOR'),
(22, 'Lebanon', 'LBN'),
(23, 'Iraq', 'IRQ'),
(24, 'Syria', 'SYR'),
(25, 'Palestine', 'PSE'),
(26, 'Oman', 'OMN'),
(27, 'Bahrain', 'BHR'),
(28, 'Yemen', 'YEM'),
(29, 'Morocco', 'MAR'),
(30, 'Algeria', 'DZA'),
(31, 'Tunisia', 'TUN'),
(32, 'Libya', 'LBY'),
(33, 'Sudan', 'SDN'),
(34, 'South Africa', 'ZAF'),
(35, 'Nigeria', 'NGA'),
(36, 'Kenya', 'KEN'),
(37, 'Ghana', 'GHA'),
(38, 'Ethiopia', 'ETH');

SET IDENTITY_INSERT Countries OFF;

-- =============================================
-- Cities
-- =============================================
INSERT INTO Cities (Name, CountryId)
VALUES

-- Egypt (2)
('Cairo', 2),
('Alexandria', 2),
('Giza', 2),
('Luxor', 2),
('Aswan', 2),
('Mansoura', 2),

-- United States (3)
('New York', 3),
('Los Angeles', 3),
('Chicago', 3),
('Houston', 3),
('Miami', 3),
('Boston', 3),

-- United Kingdom (4)
('London', 4),
('Manchester', 4),
('Liverpool', 4),
('Birmingham', 4),

-- Canada (5)
('Toronto', 5),
('Vancouver', 5),
('Montreal', 5),
('Calgary', 5),

-- Germany (6)
('Berlin', 6),
('Munich', 6),
('Hamburg', 6),
('Frankfurt', 6),

-- France (7)
('Paris', 7),
('Marseille', 7),
('Lyon', 7),
('Nice', 7),

-- Italy (8)
('Rome', 8),
('Milan', 8),
('Naples', 8),
('Turin', 8),

-- Spain (9)
('Madrid', 9),
('Barcelona', 9),
('Valencia', 9),
('Seville', 9),

-- Australia (10)
('Sydney', 10),
('Melbourne', 10),
('Brisbane', 10),
('Perth', 10),

-- Japan (11)
('Tokyo', 11),
('Osaka', 11),
('Kyoto', 11),
('Nagoya', 11),

-- China (12)
('Beijing', 12),
('Shanghai', 12),
('Guangzhou', 12),
('Shenzhen', 12),

-- India (13)
('Mumbai', 13),
('Delhi', 13),
('Bangalore', 13),
('Chennai', 13),

-- Brazil (14)
('Sao Paulo', 14),
('Rio de Janeiro', 14),
('Brasilia', 14),
('Salvador', 14),

-- Mexico (15)
('Mexico City', 15),
('Guadalajara', 15),
('Monterrey', 15),
('Puebla', 15),

-- Turkey (16)
('Istanbul', 16),
('Ankara', 16),
('Izmir', 16),
('Antalya', 16),

-- Saudi Arabia (17)
('Riyadh', 17),
('Jeddah', 17),
('Mecca', 17),
('Medina', 17),

-- United Arab Emirates (18)
('Dubai', 18),
('Abu Dhabi', 18),
('Sharjah', 18),
('Ajman', 18),

-- Qatar (19)
('Doha', 19),
('Al Rayyan', 19),
('Al Wakrah', 19),

-- Kuwait (20)
('Kuwait City', 20),
('Hawally', 20),
('Salmiya', 20),

-- Jordan (21)
('Amman', 21),
('Zarqa', 21),
('Irbid', 21),

-- Lebanon (22)
('Beirut', 22),
('Tripoli', 22),
('Sidon', 22),

-- Iraq (23)
('Baghdad', 23),
('Basra', 23),
('Mosul', 23),
('Erbil', 23),

-- Syria (24)
('Damascus', 24),
('Aleppo', 24),
('Homs', 24),

-- Palestine (25)
('Ramallah', 25),
('Gaza City', 25),
('Hebron', 25),

-- Oman (26)
('Muscat', 26),
('Salalah', 26),
('Sohar', 26),

-- Bahrain (27)
('Manama', 27),
('Riffa', 27),
('Muharraq', 27),

-- Yemen (28)
('Sanaa', 28),
('Aden', 28),
('Taiz', 28),

-- Morocco (29)
('Rabat', 29),
('Casablanca', 29),
('Marrakesh', 29),
('Fes', 29),

-- Algeria (30)
('Algiers', 30),
('Oran', 30),
('Constantine', 30),

-- Tunisia (31)
('Tunis', 31),
('Sfax', 31),
('Sousse', 31),

-- Libya (32)
('Tripoli', 32),
('Benghazi', 32),
('Misrata', 32),

-- Sudan (33)
('Khartoum', 33),
('Omdurman', 33),
('Port Sudan', 33),

-- South Africa (34)
('Cape Town', 34),
('Johannesburg', 34),
('Durban', 34),
('Pretoria', 34),

-- Nigeria (35)
('Lagos', 35),
('Abuja', 35),
('Kano', 35),
('Ibadan', 35),

-- Kenya (36)
('Nairobi', 36),
('Mombasa', 36),
('Kisumu', 36),

-- Ghana (37)
('Accra', 37),
('Kumasi', 37),
('Tamale', 37),

-- Ethiopia (38)
('Addis Ababa', 38),
('Dire Dawa', 38),
('Gondar', 38);
 