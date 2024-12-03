-- Einfügen von Beispieldaten in die Tabelle Paletten
INSERT INTO Paletten (ID, Gewicht, Beschreibung) VALUES (1, 500.0, 'Palette mit Elektronikartikeln');
INSERT INTO Paletten (ID, Gewicht, Beschreibung) VALUES (2, 300.0, 'Palette mit Lebensmitteln');
INSERT INTO Paletten (ID, Gewicht, Beschreibung) VALUES (3, 700.0, 'Palette mit Möbeln');
GO

-- Einfügen von Beispieldaten in die Tabelle PKWs
INSERT INTO PKWs (ID, Modell, Kennzeichen, Baujahr, MaxGewicht, MaxPaletten) VALUES (1, 'VW Transporter', 'B-AB1234', 2018, 1000.0, 10);
INSERT INTO PKWs (ID, Modell, Kennzeichen, Baujahr, MaxGewicht, MaxPaletten) VALUES (2, 'Mercedes Sprinter', 'B-CD5678', 2020, 1200.0, 12);
INSERT INTO PKWs (ID, Modell, Kennzeichen, Baujahr, MaxGewicht, MaxPaletten) VALUES (3, 'Ford Transit', 'B-EF9012', 2019, 1100.0, 11);
GO

-- Einfügen von Beispieldaten in die Tabelle PKW_Paletten
INSERT INTO PKW_Paletten (PKW_ID, Palette_ID) VALUES (1, 1);
INSERT INTO PKW_Paletten (PKW_ID, Palette_ID) VALUES (2, 2);
INSERT INTO PKW_Paletten (PKW_ID, Palette_ID) VALUES (3, 3);
GO

-- Einfügen von Beispieldaten in die Tabelle Mitarbeiter
INSERT INTO Mitarbeiter (ID, Name, Position) VALUES (1, 'Max Mustermann', 'Fahrer');
INSERT INTO Mitarbeiter (ID, Name, Position) VALUES (2, 'Erika Musterfrau', 'Fahrer');
INSERT INTO Mitarbeiter (ID, Name, Position) VALUES (3, 'Hans Beispiel', 'Lagerist');
GO

-- Einfügen von Beispieldaten in die Tabelle PKW_Mitarbeiter
INSERT INTO PKW_Mitarbeiter (PKW_ID, Mitarbeiter_ID) VALUES (1, 1);
INSERT INTO PKW_Mitarbeiter (PKW_ID, Mitarbeiter_ID) VALUES (2, 2);
GO

-- Einfügen von Beispieldaten in die Tabelle PKW_Verfuegbarkeit
INSERT INTO PKW_Verfuegbarkeit (PKW_ID, Verfuegbar) VALUES (1, 1);
INSERT INTO PKW_Verfuegbarkeit (PKW_ID, Verfuegbar) VALUES (2, 0);
INSERT INTO PKW_Verfuegbarkeit (PKW_ID, Verfuegbar) VALUES (3, 1);
GO

-- Einfügen von Beispieldaten in die Tabelle Mitarbeiter_Verfuegbarkeit
INSERT INTO Mitarbeiter_Verfuegbarkeit (Mitarbeiter_ID, Verfuegbar) VALUES (1, 1);
INSERT INTO Mitarbeiter_Verfuegbarkeit (Mitarbeiter_ID, Verfuegbar) VALUES (2, 0);
INSERT INTO Mitarbeiter_Verfuegbarkeit (Mitarbeiter_ID, Verfuegbar) VALUES (3, 1);
GO

