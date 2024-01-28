use HotelProjeto;

INSERT INTO MCargo(NomeCargo)
VALUES ('Atendente'), ('Gerente'), ('Diretor'), ('Lavanderia'), ('Cozinha'), ('Contabilidade'), ('Faxina');

--DBCC CHECKIDENT ('MCargo',RESEED,0);

INSERT INTO MTipoQuarto(Tipo, CapacidadeMaxima, CapacidadeOpcional)
VALUES ('Solteiro', 1, 1);

INSERT INTO MTipoQuarto(Tipo, CapacidadeMaxima, CapacidadeOpcional)
VALUES ('Solteiro', 1, 0);

INSERT INTO MTipoQuarto(Tipo, CapacidadeMaxima, CapacidadeOpcional)
VALUES ('Casal', 2, 1);

INSERT INTO MTipoQuarto(Tipo, CapacidadeMaxima, CapacidadeOpcional)
VALUES ('Casal', 2, 0);

INSERT INTO MTipoQuarto(Tipo, CapacidadeMaxima, CapacidadeOpcional)
VALUES ('Familia', 3, 1);

INSERT INTO MTipoQuarto(Tipo, CapacidadeMaxima, CapacidadeOpcional)
VALUES ('Familia', 3, 0);

INSERT INTO MFormaPagamento(Forma)
VALUES ('Dinheiro'), ('PIX'), ('Cartao de Credito'), ('Cartao de Debito');

INSERT INTO MTipoServicoLavanderia(Servico, Valor)
VALUES ('Lavar e passar terno', 50.00);

INSERT INTO MTipoServicoLavanderia(Servico, Valor)
VALUES ('Lavar e passar vestido', 60.00);

INSERT INTO MTipoServicoLavanderia(Servico, Valor)
VALUES ('Lavar e passar camisa social', 45.00);

INSERT INTO MTipoServicoLavanderia(Servico, Valor)
VALUES ('Lavar e passar calça', 45.00);

INSERT INTO MTipoServicoLavanderia(Servico, Valor)
VALUES ('Lavar e passar meia', 25.00);

INSERT INTO MTipoServicoLavanderia(Servico, Valor)
VALUES ('Lavar e passar roupa completa', 90.00);

INSERT INTO MEndereco(Rua, Numero, Bairro, Cidade, Estado)
VALUES ('Rio das Flores', '327', 'Pomar', 'Florianopolis', 'Santa Catarina');

INSERT INTO MEndereco(Rua, Numero, Bairro, Cidade, Estado)
VALUES ('Visconde Guarapuava', '888', 'Batel', 'Curitiba', 'Parana');

INSERT INTO MEndereco(Rua, Numero, Bairro, Cidade, Estado)
VALUES ('Rei Pele', '2167', 'Pompeia', 'Santos', 'São Paulo');