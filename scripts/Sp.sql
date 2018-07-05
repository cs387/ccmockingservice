/****** Object:  StoredProcedure [dbo].[CheckCardExist]    Script Date: 7/5/2018 12:57:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROCEDURE [dbo].[CheckCardExist]
      @Number nvarchar(16)
AS
BEGIN
      SET NOCOUNT ON;
 
      DECLARE @Exists INT
 
      IF EXISTS(SELECT c.Number
                        FROM CreditCardEntity c
                        WHERE c.Number = @Number)
      BEGIN
            SET @Exists = 1
      END
      ELSE
      BEGIN
            SET @Exists = 0
      END
 
      RETURN @Exists
END
GO

