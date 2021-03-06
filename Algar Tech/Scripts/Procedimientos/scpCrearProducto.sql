CREATE PROCEDURE scpCrearProducto (
	@ID_PRODUCTO INT,
	@NOMBRE VARCHAR(50),
	@PRECIO NUMERIC(18, 2),
	@ID_TALLA INT,
	@ID_COLOR INT,
	@ID_TIPO_DEPARTAMENTO INT
	)
AS
BEGIN
	IF(@ID_PRODUCTO = 0)
	BEGIN
		INSERT INTO PRODUCTO(NOMBRE, PRECIO, ID_TALLA, ID_COLOR, ID_TIPO_DEPARTAMENTO)
		VALUES
		(@NOMBRE, @PRECIO, @ID_TALLA, @ID_COLOR, @ID_TIPO_DEPARTAMENTO)
	END
	ELSE
	BEGIN
		UPDATE PRODUCTO
		SET
		NOMBRE = @NOMBRE, 
		PRECIO = @PRECIO, 
		ID_TALLA = @ID_TALLA, 
		ID_COLOR = @ID_COLOR, 
		ID_TIPO_DEPARTAMENTO = @ID_TIPO_DEPARTAMENTO
		WHERE ID_PRODUCTO = @ID_PRODUCTO
	END
END