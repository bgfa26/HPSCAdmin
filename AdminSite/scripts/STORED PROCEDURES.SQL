/****** 
		PROCEDIMIENTO PARA AGREGAR EMPLEADOS A LA BASE DE DATOS (NO POSEEN NINGUN ROL) 
		FECHA: 20/06/2019 11:00 AM
******/
USE [MTGROUPDATABAS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREATE_EMPLOYEE]
  @id AS int,
  @workerid AS varchar (20),
  @firstname AS varchar (50),
  @lastname AS varchar (50),
  @email AS varchar (120),
  @password AS varchar (50)
AS
BEGIN
  IF ((SELECT COUNT(*) FROM EMPLOYEE WHERE ID = @id) = 0)
    IF ((SELECT COUNT(*) FROM EMPLOYEE WHERE WORKERID = @workerid) = 0)
      IF ((SELECT COUNT(*) FROM EMPLOYEE WHERE EMAIL = @email) = 0)
        BEGIN
          INSERT INTO EMPLOYEE VALUES(@id, @workerid, @firstname, @lastname, @email, @password);
          RETURN 200;
        END;
      ELSE
        RETURN 103;
    ELSE
      RETURN 102;  
  ELSE
    RETURN 101;  
END