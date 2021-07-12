CREATE DATABASE senai_czBooks;
GO

USE senai_czBooks;
GO

CREATE TABLE tiposUsuario 
(
	idTipoUsuario	INT PRIMARY KEY IDENTITY,
	tipo			VARCHAR(100) NOT NULL 
);
GO

CREATE TABLE categoria 
(
	idCategoria		INT PRIMARY KEY IDENTITY,
	categoria		VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE biblioteca
(
	idBiblioteca	INT PRIMARY KEY IDENTITY,
	cnpj			CHAR(14) UNIQUE NOT NULL,
	endereco		VARCHAR(250) UNIQUE NOT NULL,
	razaoSocial		VARCHAR(250) NOT NULL
);
GO

CREATE TABLE usuario
(
	idUsuario		INT PRIMARY KEY IDENTITY,
	idTipoUsuario	INT FOREIGN KEY REFERENCES tiposUsuario(idTipoUsuario),
	nome			VARCHAR(250) NOT NULL,
	email			VARCHAR(250) UNIQUE NOT NULL,
	senha			VARCHAR(30) NOT NULL
);
GO

CREATE TABLE autor
(
	idAutor			INT PRIMARY KEY IDENTITY,
	idUsuario		INT FOREIGN KEY REFERENCES usuario(idUsuario),
	sobrenome		VARCHAR(100) NOT NULL
);
GO

CREATE TABLE livro
(
	idLivro			INT PRIMARY KEY IDENTITY,
	idCategoria		INT FOREIGN KEY REFERENCES categoria(idCategoria),
	idAutor			INT FOREIGN KEY REFERENCES autor(idAutor),
	idBiblioteca	INT FOREIGN KEY REFERENCES biblioteca(idBiblioteca),
	titulo			VARCHAR(100) NOT NULL,
	sinopse			VARCHAR(1000) NOT NULL,
	dataPublicacao	DATE,
	preco			MONEY
);
GO