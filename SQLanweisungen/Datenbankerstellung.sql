-- Erstellen der Datenbank
CREATE DATABASE Lagerverwaltung;
GO

-- Verwenden der erstellten Datenbank
USE Lagerverwaltung;
GO

-- Erstellen der Tabelle für Paletten
CREATE TABLE Paletten (
    ID INT PRIMARY KEY,
    Gewicht FLOAT NOT NULL,
    Beschreibung NVARCHAR(255)
);
GO

-- Erstellen der Tabelle für PKWs mit zusätzlichen Attributen
CREATE TABLE PKWs (
    ID INT PRIMARY KEY,
    Modell NVARCHAR(100) NOT NULL,
    Kennzeichen NVARCHAR(20) NOT NULL,
    Baujahr INT NOT NULL,
    MaxGewicht FLOAT NOT NULL,
    MaxPaletten INT NOT NULL
);
GO

-- Erstellen der Tabelle für die Zuordnung von Paletten zu PKWs
CREATE TABLE PKW_Paletten (
    PKW_ID INT,
    Palette_ID INT,
    FOREIGN KEY (PKW_ID) REFERENCES PKWs(ID),
    FOREIGN KEY (Palette_ID) REFERENCES Paletten(ID),
    PRIMARY KEY (PKW_ID, Palette_ID)
);
GO

-- Erstellen der Tabelle für Mitarbeiter
CREATE TABLE Mitarbeiter (
    ID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Position NVARCHAR(100) NOT NULL
);
GO

-- Erstellen der Tabelle für die Zuordnung von Mitarbeitern zu PKWs
CREATE TABLE PKW_Mitarbeiter (
    PKW_ID INT,
    Mitarbeiter_ID INT,
    FOREIGN KEY (PKW_ID) REFERENCES PKWs(ID),
    FOREIGN KEY (Mitarbeiter_ID) REFERENCES Mitarbeiter(ID),
    PRIMARY KEY (PKW_ID, Mitarbeiter_ID)
);
GO

-- Erstellen der Tabelle für die Verfügbarkeit von PKWs
CREATE TABLE PKW_Verfuegbarkeit (
    PKW_ID INT,
    Verfuegbar BIT NOT NULL,
    FOREIGN KEY (PKW_ID) REFERENCES PKWs(ID),
    PRIMARY KEY (PKW_ID)
);
GO

-- Erstellen der Tabelle für die Verfügbarkeit von Mitarbeitern
CREATE TABLE Mitarbeiter_Verfuegbarkeit (
    Mitarbeiter_ID INT,
    Verfuegbar BIT NOT NULL,
    FOREIGN KEY (Mitarbeiter_ID) REFERENCES Mitarbeiter(ID),
    PRIMARY KEY (Mitarbeiter_ID)
);
GO

