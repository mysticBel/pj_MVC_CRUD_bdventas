USE BDVENTAS2022
GO

SELECT * FROM Clientes
GO
SELECT * FROM Distritos
GO


-- /////////////// sesion 6 y 7  /////////////////////////
----------------------------------------------------------------
CREATE OR ALTER PROCEDURE PA_INSERTAR_CLIENTE
@COD_CLI CHAR(5),@NOM_CLI VARCHAR(50),@TEL_CLI VARCHAR(10),
@COR_CLI VARCHAR(50),@DIR_CLI VARCHAR(50),@CRED_CLI INT,
@FEC_NAC DATE, @COD_DIST INT
AS
	INSERT INTO Clientes VALUES(@COD_CLI,@NOM_CLI,@TEL_CLI,@COR_CLI,
	@DIR_CLI,@CRED_CLI,@FEC_NAC,@COD_DIST,'No')
GO

----------------------------------------------------------------
CREATE OR ALTER PROCEDURE PA_ACTUALIZAR_CLIENTE
@COD_CLI CHAR(5),@NOM_CLI VARCHAR(50),@TEL_CLI VARCHAR(10),
@COR_CLI VARCHAR(50),@DIR_CLI VARCHAR(50),@CRED_CLI INT,
@FEC_NAC DATE, @COD_DIST INT
AS
	UPDATE CLIENTES
		SET nom_cli=@NOM_CLI, tel_cli=@TEL_CLI,
			cor_cli=@COR_CLI, dir_cli=@DIR_CLI,
			cred_cli=@CRED_CLI, fec_nac=@FEC_NAC,
			cod_dist=@COD_DIST
	WHERE cod_cli = @COD_CLI
GO


----------------------------------------------------------------
CREATE OR ALTER PROCEDURE PA_ELIMINAR_CLIENTE
@COD_CLI CHAR(5)
AS
	UPDATE Clientes
		SET eli_cli='Si'
	WHERE cod_cli = @COD_CLI
GO

-----------------------------------------------------------------
CREATE OR ALTER PROCEDURE PA_LISTAR_CLIENTES
@ELI_CLI CHAR(2)='No'
AS
SELECT C.cod_cli, C.nom_cli, C.tel_cli, C.cor_cli, C.dir_cli,
	C.cred_cli, C.fec_nac, C.cod_dist
FROM Clientes C
	WHERE eli_cli=@ELI_CLI
GO

EXECUTE PA_LISTAR_CLIENTES 'No'
GO

EXECUTE PA_LISTAR_CLIENTES 'Si'
GO


-----------------------------------------
select * from Clientes
go

--------------------------------------------
CREATE OR ALTER PROCEDURE PA_LISTAR_DISTRITOS
AS
	SELECT cod_dist, nom_dist FROM Distritos
GO

EXECUTE PA_LISTAR_DISTRITOS
GO

