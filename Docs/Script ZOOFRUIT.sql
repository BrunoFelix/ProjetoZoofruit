

CREATE TABLE Tipo_Usuario (Cod_TipoUsuario INTEGER IDENTITY(1,1) PRIMARY KEY,
						   Descrição VARCHAR (20) NOT NULL);


CREATE TABLE Usuario (Cod_Usuario INTEGER IDENTITY(1,1) PRIMARY KEY,
					  CPF VARCHAR (15) NOT NULL,
					  Login VARCHAR (20) NOT NULL,
					  Senha VARCHAR (8) NOT NULL,
					  CRMV VARCHAR (15) NOT NULL,
					  Cod_TipoUsuario INTEGER REFERENCES Tipo_Usuario(Cod_TipoUsuario));


CREATE TABLE Tipo_Animal (Cod_TipoAnimal INTEGER IDENTITY(1,1) PRIMARY KEY,
						  Tipo VARCHAR (20) NOT NULL);


CREATE TABLE Animal (Cod_Animal INTEGER IDENTITY(1,1) PRIMARY KEY,
					 Nome VARCHAR (20) NOT NULL,
					 Foto IMAGE NOT NULL,
					 Cor VARCHAR (20) NOT NULL,
					 Porte VARCHAR (8) NOT NULL,
					 Peso DECIMAL (4,3) NOT NULL,
					 Cod_TipoAnimal REFERENCES Tipo_Animal(Cod_TipoAnimal));


CREATE TABLE Ficha (Cod_Ficha INTEGER IDENTITY (1,1) PRIMARY KEY,
					Dt_Criacao DATE NOT NULL,
					Hr_Criacao TIME NOT NULL,
					Dt_Validade DATE NOT NULL,
					Tipo_Ficha VARCHAR (11) NOT NULL,
					Cod_Usuario INTEGER REFERENCES Usuario(Cod_Usuario),
					Cod_Animal INTEGER REFERENCES Animal(Cod_Animal));


CREATE TABLE Ficha_Execucao (Cod_FichaExecucao INTEGER IDENTITY(1,1) PRIMARY KEY,
								 Dt_Execucao DATE NOT NULL,
								 Hr_Execucao TIME NOT NULL,
								 Status VARCHAR (12) NOT NULL,
								 Observacao VARCHAR (50) NOT NULL
								 Cod_Usuario INTEGER REFERENCES Usuario(Cod_Usuario),
								 Cod_Ficha INTEGER REFERENCES Ficha(Cod_Ficha));


CREATE TABLE Alimento (Cod_Alimento INTEGER IDENTITY(1,1) PRIMARY KEY,
					   Nome VARCHAR (20) NOT NULL,
					   Qtd INT NOT NULL,
					   Vl_Calorico DECIMAL (4,3) NOT NULL,
					   Dt_Validade DATE NOT NULL,
					   Dt_Reposicao DATE NOT NULL);


CREATE TABLE Contem_Alim (Quantidade INT NOT NULL,
						  Cod_Alimento INTEGER REFERENCES Alimento(Cod_alimento),
						  Cod_Ficha INTEGER REFERENCES Ficha(Cod_Ficha)
						  Cod_Alimento, Cod_Ficha PRIMARY KEY);


CREATE TABLE Medicamento (Cod_Medicamento INTEGER IDENTITY(1,1) PRIMARY KEY,
						  Nome VARCHAR (20) NOT NULL,
						  Qtd INT NOT NULL,
						  Dt_Validade DATE NOT NULL,
						  Dt_Reposição DATE NOT NULL);


CREATE TABLE Contem_Medc (Quantidade INT NOT NULL,
						  Cod_Medicamento INTEGER REFERENCES Medicamento(Cod_Medicamento),
						  Cod_Ficha INTEGER REFERENCES Ficha(Cod_Ficha)
						  Cod_Medicamento, Cod_Ficha PRIMARY KEY);