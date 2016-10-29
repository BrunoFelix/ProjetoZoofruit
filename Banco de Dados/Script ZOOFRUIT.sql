CREATE DATABASE zoofruit ;

SET LANGUAGE 'Portuguese';

USE Zoofruit;

CREATE TABLE TipoUsuario (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	descricao VARCHAR (20) NOT NULL
);

CREATE TABLE Usuario (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(60) not null,
	cpf VARCHAR (15) NOT NULL,
	login VARCHAR (20) NOT NULL,
	senha VARCHAR (8) NOT NULL,
	crmv VARCHAR (15) NOT NULL,
	codigo_TipoUsuario INTEGER REFERENCES TipoUsuario(codigo)
);

CREATE TABLE TipoAnimal (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	descricao VARCHAR (20) NOT NULL
);

CREATE TABLE Animal (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR (20) NOT NULL,
	foto VARBINARY(MAX),
	cor VARCHAR (20) NOT NULL,
	porte VARCHAR (8) NOT NULL,
	peso DECIMAL (10,2) NOT NULL,
	codigo_TipoAnimal INTEGER REFERENCES TipoAnimal(codigo)
);

CREATE TABLE Ficha (
	codigo INTEGER IDENTITY (1,1) PRIMARY KEY,
	dt_criacao DATE NOT NULL,
	hr_cricacao TIME NOT NULL,
	dt_validade DATE NOT NULL,
	tipo VARCHAR (11) NOT NULL,
	codigo_Usuario INTEGER REFERENCES Usuario(codigo),
	codigo_Animal INTEGER REFERENCES Animal(codigo)
);


CREATE TABLE FichaExecucao (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	dt_execucao DATE NOT NULL,
	hr_execucao TIME NOT NULL,
	status VARCHAR (12) NOT NULL,
	observacao VARCHAR (50) NOT NULL,
	codigo_Usuario INTEGER REFERENCES Usuario(codigo),
	codigo_Ficha INTEGER REFERENCES Ficha(codigo)
);

CREATE TABLE Alimento (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR (20) NOT NULL,
	quantidade INT NOT NULL,
	valor_calorico DECIMAL (4,3) NOT NULL,
	dt_reposicao DATE NOT NULL
);

CREATE TABLE Ficha_Alimento (
	quantidade INT NOT NULL,
	codigo_Alimento INTEGER REFERENCES Alimento(codigo),
	codigo_Ficha INTEGER REFERENCES Ficha(codigo),
	CONSTRAINT PK_Ficha_Alimento PRIMARY KEY(codigo_Alimento, codigo_Ficha)
);

CREATE TABLE Medicamento (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR (20) NOT NULL,
	quantidade INT NOT NULL,
	dt_reposicao DATE NOT NULL
);

CREATE TABLE Ficha_Medicamento (
	quantidade INT NOT NULL,
	codigo_Medicamento INTEGER REFERENCES Medicamento(codigo),
	codigo_Ficha INTEGER REFERENCES Ficha(codigo)
	CONSTRAINT PK_Ficha_Medicamento PRIMARY KEY(codigo_Medicamento, codigo_Ficha)
);

CREATE TABLE FichaExecucao_Medicamento (
	quantidade INT NOT NULL,
	codigo_Medicamento INTEGER REFERENCES Medicamento(codigo),
	codigo_FichaExecucao INTEGER REFERENCES Ficha(codigo)
	CONSTRAINT PK_FichaExecucao_Medicamento PRIMARY KEY(codigo_Medicamento, codigo_FichaExecucao)
);

CREATE TABLE FichaExecucao_Alimento (
	quantidade INT NOT NULL,
	codigo_Alimento INTEGER REFERENCES Alimento(codigo),
	codigo_FichaExecucao INTEGER REFERENCES Ficha(codigo)
	CONSTRAINT PK_FichaExecucao_Alimento PRIMARY KEY(codigo_Alimento, codigo_FichaExecucao)
);

GO
INSERT INTO TipoUsuario([descricao]) VALUES ('Tratador');
GO
INSERT INTO Usuario([nome],[cpf],[login],[senha],[crmv],[codigo_TipoUsuario])VALUES('Administrador do Sistema','39194717338','admin','123','012345',1);



        