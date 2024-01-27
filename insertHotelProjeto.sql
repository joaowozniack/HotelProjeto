use HotelProjeto;

EXEC sp_rename 'MTipoQuarto.capcidadeMaxima', 'capacidadeMaxima', 'COLUMN';

INSERT INTO MCargo(nomeCargo)
VALUES ('Atendente'), ('Gerente'), ('Diretor'), ('Lavanderia'), ('Cozinha'), ('Contabilidade'), ('Faxina');

SELECT * FROM MCargo;

--DBCC CHECKIDENT ('MCargo',RESEED,0);

INSERT INTO MTipoQuarto(tipo, capacidadeMaxima, capacidadeOpcional)
VALUES ('Solteiro', 1, 1);

INSERT INTO MTipoQuarto(tipo, capacidadeMaxima, capacidadeOpcional)
VALUES ('Solteiro', 1, 0);

INSERT INTO MTipoQuarto(tipo, capacidadeMaxima, capacidadeOpcional)
VALUES ('Casal', 2, 1);

INSERT INTO MTipoQuarto(tipo, capacidadeMaxima, capacidadeOpcional)
VALUES ('Casal', 2, 0);

INSERT INTO MTipoQuarto(tipo, capacidadeMaxima, capacidadeOpcional)
VALUES ('Familia', 3, 1);

INSERT INTO MTipoQuarto(tipo, capacidadeMaxima, capacidadeOpcional)
VALUES ('Familia', 3, 0);

SELECT * FROM MTipoQuarto;

INSERT INTO MFormaPagamento(forma)
VALUES ('Dinheiro'), ('PIX'), ('Cartao de Credito'), ('Cartao de Debito');

SELECT * FROM MFormaPagamento;

INSERT INTO MTipoServicoLavanderia(servico, valor)
VALUES ('Lavar e passar terno', 50.00);

INSERT INTO MTipoServicoLavanderia(servico, valor)
VALUES ('Lavar e passar vestido', 60.00);

INSERT INTO MTipoServicoLavanderia(servico, valor)
VALUES ('Lavar e passar camisa social', 45.00);

INSERT INTO MTipoServicoLavanderia(servico, valor)
VALUES ('Lavar e passar calça', 45.00);

INSERT INTO MTipoServicoLavanderia(servico, valor)
VALUES ('Lavar e passar meia', 25.00);

INSERT INTO MTipoServicoLavanderia(servico, valor)
VALUES ('Lavar e passar roupa completa', 90.00);

SELECT * FROM MTipoServicoLavanderia;

INSERT INTO MEndereco(rua, numero, bairro, cidade, estado)
VALUES ('Rio das Flores', '327', 'Pomar', 'Florianopolis', 'Santa Catarina');

INSERT INTO MEndereco(rua, numero, bairro, cidade, estado)
VALUES ('Visconde Guarapuava', '888', 'Batel', 'Curitiba', 'Parana');

INSERT INTO MEndereco(rua, numero, bairro, cidade, estado)
VALUES ('Rei Pele', '2167', 'Pompeia', 'Santos', 'São Paulo');

SELECT * FROM MEndereco;