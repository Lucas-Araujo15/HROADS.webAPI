USE SENAI_HROADS_WEBAPI_MANHA;
GO

INSERT INTO tipoHabilidade
VALUES ('Ataque'), ('Defesa'), ('Cura'), ('Magia');
GO

SELECT * FROM tipoHabilidade

INSERT INTO habilidade
VALUES (1, 'Lança mortal'), (2, 'Escudo Supremo'), (3, 'Recuperar Vida')
GO


SELECT * FROM habilidade

INSERT INTO classe
VALUES ('Bárbaro'),('Cruzado'),('Caçadora de Demônios'),('Monge'),('Necromante'),('Feiticeiro'),('Arcanista');
GO

SELECT * FROM classe

INSERT INTO classHab
VALUES (1,1),(1,2),(2,2),(3,1),(4,3),(4,2),(5, NULL),(6,3),(7,NULL);
GO

SELECT * FROM classHab


INSERT INTO PERSONAGEM
VALUES (1, 'DeuBug', 100, 80, GETDATE(), '2019-01-18'), (4, 'BitBug', 70, 100, GETDATE(), '2016-03-17'), (7, 'Fer8', 75,60, GETDATE(), '2018-03-18');
GO

SELECT * FROM personagem

INSERT INTO tipoUsuario
VALUES ('Administrador'), ('Jogador');
GO

SELECT * FROM tipoUsuario;

INSERT INTO usuario
VALUES (1, 'Admin', 'admin@admin.com', '123456'), (2, 'Jogador', 'jogador@jogador.com', '123456');
GO

SELECT * FROM usuario;