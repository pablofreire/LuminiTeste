IF NOT EXISTS (SELECT 1 FROM Routes WHERE Origin = 'GRU' AND Destination = 'BRC' AND Cost = 10)
BEGIN
    INSERT INTO Routes (Origin, Destination, Cost) VALUES ('GRU', 'BRC', 10);
END;

IF NOT EXISTS (SELECT 1 FROM Routes WHERE Origin = 'BRC' AND Destination = 'SCL' AND Cost = 5)
BEGIN
    INSERT INTO Routes (Origin, Destination, Cost) VALUES ('BRC', 'SCL', 5);
END;

IF NOT EXISTS (SELECT 1 FROM Routes WHERE Origin = 'GRU' AND Destination = 'CDG' AND Cost = 75)
BEGIN
    INSERT INTO Routes (Origin, Destination, Cost) VALUES ('GRU', 'CDG', 75);
END;

IF NOT EXISTS (SELECT 1 FROM Routes WHERE Origin = 'GRU' AND Destination = 'SCL' AND Cost = 20)
BEGIN
    INSERT INTO Routes (Origin, Destination, Cost) VALUES ('GRU', 'SCL', 20);
END;

IF NOT EXISTS (SELECT 1 FROM Routes WHERE Origin = 'GRU' AND Destination = 'ORL' AND Cost = 56)
BEGIN
    INSERT INTO Routes (Origin, Destination, Cost) VALUES ('GRU', 'ORL', 56);
END;

IF NOT EXISTS (SELECT 1 FROM Routes WHERE Origin = 'ORL' AND Destination = 'CDG' AND Cost = 5)
BEGIN
    INSERT INTO Routes (Origin, Destination, Cost) VALUES ('ORL', 'CDG', 5);
END;

IF NOT EXISTS (SELECT 1 FROM Routes WHERE Origin = 'SCL' AND Destination = 'ORL' AND Cost = 20)
BEGIN
    INSERT INTO Routes (Origin, Destination, Cost) VALUES ('SCL', 'ORL', 20);
END;
