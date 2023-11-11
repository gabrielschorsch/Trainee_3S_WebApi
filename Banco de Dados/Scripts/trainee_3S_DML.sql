INSERT INTO TiposUsuarios (Titulo)
VALUES ('colaborador'),
	   ('visitante');
GO

INSERT INTO Usuarios (IdTipoUsuario, Email, Senha)
VALUES (1, 'adm@adm.com', 'adm123'),
	   (1, 'colaborador@gmail.com', 'colaborador123'),
	   (2, 'visitante@gmail.com', 'visitante123');
GO

INSERT INTO Setores (Titulo)
VALUES ('Recursos Humanos'),
	   ('Tecnologia da Informação'),
	   ('Financeiro');
GO

INSERT INTO Colaboradores (IdUsuario, IdSetor, Nome, IsAdmin)
VALUES (1, NULL, 'Administrador', 1),
       (1, 2, 'Administrador', 0);