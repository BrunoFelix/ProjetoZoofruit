IF DB_ID('zoofruit') IS NOT NULL
	BEGIN
		USE Master
		DROP DATABASE zoofruit;
	END
-----------------------------------------------------------------------------------------------------	
	CREATE DATABASE zoofruit ;
	GO
	SET LANGUAGE 'Portuguese';
	USE Zoofruit;
-----------------------------------------------------------------------------------------------------

CREATE TABLE TipoUsuario (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	descricao VARCHAR (20) NOT NULL
);

CREATE TABLE TipoAnimal (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	descricao VARCHAR (20) NOT NULL,
	ativo VARCHAR(1) DEFAULT 'T'
);

CREATE TABLE Usuario (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(60) not null,
	cpf VARCHAR (15) NOT NULL,
	login VARCHAR (20) NOT NULL,
	senha VARCHAR (8) NOT NULL,
	crmv VARCHAR (15) NOT NULL,
	ativo varchar(1) default 'T',
	codigo_TipoUsuario INTEGER REFERENCES TipoUsuario(codigo)
);

CREATE TABLE Animal (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR (20) NOT NULL,
	foto VARBINARY(MAX),
	cor VARCHAR (20),
	porte VARCHAR (18),
	peso float,
	ativo varchar(1) default 'T',
	codigo_TipoAnimal INTEGER REFERENCES TipoAnimal(codigo)
);

CREATE TABLE Ficha_Alimento (
	codigo INTEGER IDENTITY (1,1) PRIMARY KEY,
	descricao VARCHAR(60),
	dt_criacao DATE NOT NULL,
	dt_validade DATE NOT NULL,
	qtd_max_cal float NOT NULL,
	hora_a_ser_executado INTEGER NOT NULL,
	ativo VARCHAR(1) DEFAULT 'T', 
	codigo_Usuario INTEGER REFERENCES Usuario(codigo),
	codigo_Animal INTEGER REFERENCES Animal(codigo)
);

CREATE TABLE Ficha_Medicamento (
	codigo INTEGER IDENTITY (1,1) PRIMARY KEY,
	descricao VARCHAR(60),
	dt_criacao DATETIME NOT NULL,
	dt_validade DATE NOT NULL,
	hora_a_ser_executado INTEGER NOT NULL,
	codigo_Usuario INTEGER REFERENCES Usuario(codigo),
	codigo_Animal INTEGER REFERENCES Animal(codigo)
);


CREATE TABLE Ficha_Execucao_Alimento (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	dt_execucao DATETIME NOT NULL,
	status VARCHAR (12) NOT NULL,
	observacao VARCHAR (50) NOT NULL,
	codigo_Usuario INTEGER REFERENCES Usuario(codigo),
	codigo_Ficha INTEGER REFERENCES Ficha_Alimento(codigo)
);

CREATE TABLE Ficha_Execucao_Medicamento (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	dt_execucao DATETIME NOT NULL,
	status VARCHAR (12) NOT NULL,
	observacao VARCHAR (50) NOT NULL,
	codigo_Usuario INTEGER REFERENCES Usuario(codigo),
	codigo_Ficha INTEGER REFERENCES Ficha_Medicamento(codigo)
);

CREATE TABLE Alimento (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR (20) NOT NULL,
	quantidade FLOAT NOT NULL,
	valor_calorico FLOAT NOT NULL,
	ativo varchar(1) default 'T',
);

CREATE TABLE Ficha_Contem_Alimento (
	codigo_Alimento INTEGER REFERENCES Alimento(codigo),
	codigo_Ficha INTEGER REFERENCES Ficha_Alimento(codigo),
	CONSTRAINT PK_Ficha_Alimento PRIMARY KEY(codigo_Alimento, codigo_Ficha)
);

CREATE TABLE Medicamento (
	codigo INTEGER IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR (20) NOT NULL,
	quantidade float NOT NULL,
	dt_reposicao DATE NOT NULL,
	ativo varchar(1) default 'T',
);

CREATE TABLE Ficha_Contem_Medicamento (
	codigo_Medicamento INTEGER REFERENCES Medicamento(codigo),
	codigo_Ficha INTEGER REFERENCES Ficha_Medicamento(codigo)
	CONSTRAINT PK_Ficha_Contem_Medicamento PRIMARY KEY(codigo_Medicamento, codigo_Ficha)
);

CREATE TABLE Ficha_Execucao_Contem_Medicamento (
	quantidade float NOT NULL,
	codigo_Medicamento INTEGER REFERENCES Medicamento(codigo),
	codigo_Ficha_Execucao_Medicamento INTEGER REFERENCES Ficha_Execucao_Medicamento(codigo)
	CONSTRAINT PK_Ficha_Execucao_Contem_Medicamento PRIMARY KEY(codigo_Medicamento, codigo_Ficha_Execucao_Medicamento)
);

CREATE TABLE Ficha_Execucao_Contem_Alimento (
	quantidade float NOT NULL,
	codigo_Alimento INTEGER REFERENCES Alimento(codigo),
	codigo_Ficha_Execucao_Alimento INTEGER REFERENCES Ficha_Execucao_Alimento(codigo)
	CONSTRAINT PK_Ficha_Execucao_Contem_Alimento PRIMARY KEY(codigo_Alimento, codigo_Ficha_Execucao_Alimento)
);

GO
INSERT INTO TipoUsuario([descricao]) VALUES ('Tratador');
GO
INSERT INTO TipoUsuario([descricao]) VALUES ('Veterinário');
GO
INSERT INTO TipoUsuario([descricao]) VALUES ('Administrador');
GO
INSERT INTO Usuario([nome],[cpf],[login],[senha],[crmv],[codigo_TipoUsuario])VALUES('Administrador do Sistema','39194717338','admin','123','012345',3);
GO
INSERT INTO TipoAnimal([descricao]) VALUES ('Felino');
GO
INSERT INTO TipoAnimal([descricao]) VALUES ('Roedor');
GO
INSERT INTO TipoAnimal([descricao]) VALUES ('Réptil');
GO
INSERT INTO Animal([nome],[cor],[porte],[peso],[codigo_TipoAnimal])VALUES('Leão', 'Amarelo','Médio','69.00',1);
GO
INSERT INTO Alimento([nome],[quantidade],[valor_calorico])VALUES('Laranja', '500','69.00');
GO
INSERT INTO Alimento([nome],[quantidade],[valor_calorico])VALUES('Pêra', '124','42.00');
GO
INSERT INTO Alimento([nome],[quantidade],[valor_calorico])VALUES('Morango', '7894','95.00');



        