SELECT * FROM [Student]
SELECT * FROM [Course]
SELECT * FROM [StudentCourse]
SELECT NEWID()

INSERT INTO 
 [Student]
VALUES 
    (NEWID(), 'Alice Johnson', 'alice@gmail.com', 031234567890, 21987654321, '1999-5-15', GETDATE()),
    (NEWID(), 'Bob Miller', 'bob@gmail.com', 041234567891, 21998765432, '2001-3-8', GETDATE()),
    (NEWID(), 'Emily Davis', 'emily@gmail.com', 051234567892, 21987654333, '1998-9-20', GETDATE());
    
-- Inserting the new students into the course
INSERT INTO [StudentCourse]
VALUES
    ('5d8cf396-e717-9a02-2443-021b00000000', 'e46de92b-67a5-4f25-90ef-64ca5e54f41e', 50, 0, '2022-1-2', GETDATE()),  -- Alice Johnson
    ('5c349848-e717-9a7d-1241-0e6500000000', '6906edcf-babc-4d9c-9079-826357d82049', 50, 0, '2022-1-2', GETDATE()),  -- Bob Miller
    ('5c349b3c-e717-9a7d-1241-0fcb00000000', 'e8028dbf-0b1c-4ed2-bd64-87391911e789', 50, 0, '2022-1-2', GETDATE());  -- Emily Davis

