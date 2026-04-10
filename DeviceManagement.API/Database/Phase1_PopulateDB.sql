USE DeviceManagementDB;
GO

-- Seed Users (only if table is empty)
IF NOT EXISTS (SELECT 1 FROM Users)
BEGIN
    INSERT INTO Users (Name, Role, Location) VALUES
        ('Alice Johnson',  'Developer',       'New York'),
        ('Bob Smith',      'QA Engineer',     'London'),
        ('Carol White',    'Product Manager', 'Berlin'),
        ('David Brown',    'Designer',        'Paris'),
        ('Andrei Badarau',   'Developer',       'Cluj-Napoca');
END
GO

-- Seed Devices (only if table is empty)
IF NOT EXISTS (SELECT 1 FROM Devices)
BEGIN
    INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedUserId) VALUES
        ('iPhone 15 Pro',     'Apple',     'phone',  'iOS',     '17.0', 'A17 Pro',        8,  'Apple flagship phone',         1),
        ('Galaxy S24',        'Samsung',   'phone',  'Android', '14.0', 'Snapdragon 8 Gen 3', 12, 'Samsung flagship phone',   2),
        ('iPad Pro 12.9',     'Apple',     'tablet', 'iOS',     '17.0', 'M2',             16, 'High-end Apple tablet',        3),
        ('Pixel 8',           'Google',    'phone',  'Android', '14.0', 'Tensor G3',      8,  'Google stock Android phone',   NULL),
        ('Galaxy Tab S9',     'Samsung',   'tablet', 'Android', '14.0', 'Snapdragon 8 Gen 2', 12, 'Samsung premium tablet',   4),
        ('OnePlus 12',        'OnePlus',   'phone',  'Android', '14.0', 'Snapdragon 8 Gen 3', 16, 'Flagship killer phone',    NULL),
        ('iPhone 14',         'Apple',     'phone',  'iOS',     '16.0', 'A15 Bionic',     6,  'Previous gen Apple phone',    5),
        ('Xiaomi Pad 6',      'Xiaomi',    'tablet', 'Android', '13.0', 'Snapdragon 870', 8,  'Budget-friendly tablet',      NULL);
END
GO