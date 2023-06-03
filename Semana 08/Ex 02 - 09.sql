
CREATE DATABASE SEMANA08;

USE SEMANA08
GO

CREATE TABLE Clientes (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(200) NOT NULL,
	Data_Nascimento DATE NOT NULL,
	Email VARCHAR(250) NOT NULL,
	Cpf CHAR(11) NOT NULL,
	Senha VARCHAR(25)
);


CREATE TABLE MetodosPagamentos (
	Id INT PRIMARY KEY IDENTITY (1,1),
	Id_Cliente INT NOT NULL,
	Numero_Cartao VARCHAR(16) NOT NULL,
	Validade DATE NOT NULL,
	Codigo_Seguranca VARCHAR(50) NOT NULL

	FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id)
);

CREATE TABLE Produtos(
	Id INT PRIMARY KEY IDENTITY (1,1),
	Nome VARCHAR (150) NOT NULL,
	Preco NUMERIC (10,2) NOT NULL,
	Nota NUMERIC (2,1) NOT NULL,
	Unidades INT NOT NULL,
	Numero_Vendas INT NOT NULL
);

CREATE TABLE Avaliacoes_Produtos(
	Id INT PRIMARY KEY IDENTITY (1,1),
	Id_Cliente INT NOT NULL,
	Id_Produto INT NOT NULL,
	Comentario VARCHAR (500) NOT NULL,
	Numero_Estrelas NUMERIC (1,0) NOT NULL,
	Data_Criacao DATE NOT NULL
);

CREATE TABLE Pedidos (
	Id INT PRIMARY KEY IDENTITY (1,1),
	Id_Cliente INT NOT NULL,
	Id_Metodo_Pagamento INT NOT NULL,
	Valor_Total DECIMAL (5,2) NOT NULL,
	Status VARCHAR (30) NOT NULL,
	Entregue BIT NOT NULL,
	FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id),
	FOREIGN KEY (Id_Metodo_Pagamento) REFERENCES MetodosPagamentos(Id)
);

CREATE TABLE Produto_Pedido (
	Id INT PRIMARY KEY IDENTITY (1,1),
	Id_Pedido INT NOT NULL,
	Id_Produto INT NOT NULL,
    FOREIGN KEY (Id_Pedido) REFERENCES Pedidos(Id),
    FOREIGN KEY (Id_Produto) REFERENCES Produtos(Id)
);
DROP Table Produto_Pedido; 
drop table dbo.Pedidos;

ALTER TABLE Clientes ALTER COLUMN Cpf CHAR(11);


INSERT INTO Clientes (Nome,Data_Nascimento,Email,Cpf,Senha) VALUES
('João Silva', '1990-05-12', 'joao.silva@exemple.com', '12345678901', 'senha123'),
('Maria Santos', '1985-08-18', 'maria.santos@exemple.com', '98765432101', 'senh456'),
('Pedro Almeida', '1995-02-25', 'pedro.almeida@exemple.com', '65432178901', 'senha789'),
('Ana Oliveira', '1992-11-30', 'ana.oliveira@example.com', '98765412301', 'senhaabc'),
('Eduardo Costa', '1998-05-22', 'eduardo.costa@example.com', '98775512101', 'senhadef');

INSERT INTO MetodosPagamentos (Id_Cliente, Numero_Cartao, Validade, Codigo_Seguranca) VALUES 
	(1, '1234567890123456', '2025-12-31', 'senha123'),
	(2, '9876543210987654', '2024-06-30', 'senha456'),
	(3, '6543219870654321', '2023-09-30', 'senha789'),
	(4, '9876543210123456', '2026-03-31', 'senhaabc');

INSERT INTO Produtos (Nome, Preco, Nota, Unidades, Numero_Vendas) VALUES
	('Camiseta', 29.90, 4.5, 100, 50),
	('Calça Jeans', 99.90, 4.2, 80, 30),
	('Tênis', 149.90, 4.8, 50, 20),
	('Bolsa', 79.90, 4.0, 120, 60);

INSERT INTO Avaliacoes_Produtos (Id_Cliente, Id_Produto, Comentario, Numero_Estrelas, Data_Criacao) VALUES
	(1, 1, 'Ótimo produto!', 5, '2023-05-15'),
	(2, 1, 'Gostei muito!', 4, '2023-05-16'),
	(3, 2, 'Qualidade excelente!', 4, '2023-05-17'),
	(4, 3, 'Recomendo!', 5, '2023-05-18'),
	(4, 4, 'Uma porcaria!', 1, '2023-05-19');

INSERT INTO Pedidos (Id_Cliente, Id_Metodo_Pagamento, Valor_Total, Status, Entregue ) VALUES 
	(1, 1, 59.90, 'Em andamento', 0),
	(2, 2, 149.90, 'Entregue', 1),
	(3, 3, 228.70, 'Em andamento', 0),
	(4, 4, 79.90, 'Cancelado', 0);

ALTER TABLE Pedidos ALTER COLUMN Valor_Total DECIMAL(5,2);

INSERT INTO Produto_Pedido (Id_Pedido, Id_Produto) VALUES 
	(1, 1),
	(1, 2),
	(2, 2),
	(3, 3),
	(4, 4);

SELECT TOP 2 Nome, Numero_Vendas FROM Produtos ORDER BY Numero_Vendas DESC;

SELECT *FROM Pedidos 
WHERE entregue = 1 AND Valor_Total > 100;

SELECT C.Nome, COUNT(A.Id) AS 'Número de avaliações'
FROM Clientes AS C
LEFT JOIN Avaliacoes_Produtos AS A
ON C.Id = A.Id_Cliente
GROUP BY C.Nome
ORDER BY COUNT(A.Id) DESC

SELECT C.Nome, I.Nome, P.Valor_Total
FROM Clientes AS C 
INNER JOIN Pedidos AS P
ON C.Id = P.Id_Cliente
INNER JOIN Produtos I 
ON I.Nome = I.Id_Produto 
