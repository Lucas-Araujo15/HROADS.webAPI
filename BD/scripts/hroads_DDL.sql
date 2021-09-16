CREATE DATABASE SENAI_HROADS_WEBAPI_MANHA;
GO

USE SENAI_HROADS_WEBAPI_MANHA;
GO

CREATE TABLE classe(
	idClasse INT PRIMARY KEY IDENTITY(1,1),
	nomeClasse VARCHAR(30) NOT NULL UNIQUE
);
GO

CREATE TABLE personagem(
	idPersonagem INT PRIMArY KEY IDENTITY(1,1),
	idClasse INT FOREIGN KEY REFERENCES classe(idClasse),
	nome VARCHAR(20) NOT NULL,
	capVida TINYINT NOT NULL,
	capMana TINYINT NOT NULL,
	dataAtt DATE NOT NULL,
	dataCriacao DATE NOT NULL
);
GO

CREATE TABLE tipoHabilidade(
	idTipoHab INT PRIMARY KEY IDENTITY(1,1),
	nomeTipoHab VARCHAR(12) NOT NULL
);
GO

CREATE TABLE habilidade(
	idHabilidade INT PRIMARY KEY IDENTITY(1,1),
	idTipoHab INT ForEIGN KEY REFERENCES tipoHabilidade(idTipoHab),
	nomeHab VARCHAR(30) NOT NULL UNIQUE
);
GO

CREATE TABLE classHab(
	idClassHab INT PRIMARY KEY IDENTITY(1,1),
	idClasse INT FOREIGN KEY REFERENCES classe(idClasse),
	idHabilidade INT FOREIGN KEY REFERENCES habilidade(idHabilidade)
);
GO

CREATE TABLE tipoUsuario(
	idTipoUsuario INT PRIMARY KEY IDENTITY(1,1),
	titulo VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE usuario(
	idUsuario INT PRIMARY KeY IdeNTITY(1,1),
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nome VARCHAR(50) NOT NULL,
	email VARCHAR(256) NOT NULL UNIQUE,
	senha VARCHAR(10) NOT NULL
);
GO