IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Routes')
BEGIN
    CREATE TABLE Routes (
        Id INT PRIMARY KEY IDENTITY,
        Origin VARCHAR(3) NOT NULL,
        Destination VARCHAR(3) NOT NULL,
        Cost INT NOT NULL
    );
END
