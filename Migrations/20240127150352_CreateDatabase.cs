using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProjeto.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    codCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCargo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.codCargo);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    codCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.codCliente);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    codEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.codEndereco);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    codForma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    forma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.codForma);
                });

            migrationBuilder.CreateTable(
                name: "TipoQuarto",
                columns: table => new
                {
                    codTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capcidadeMaxima = table.Column<int>(type: "int", nullable: false),
                    capacidadeOpcional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuarto", x => x.codTipo);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicoLavanderia",
                columns: table => new
                {
                    codTipoServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    servico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicoLavanderia", x => x.codTipoServico);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    codFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codCargo1 = table.Column<int>(type: "int", nullable: true),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.codFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_codCargo1",
                        column: x => x.codCargo1,
                        principalTable: "Cargo",
                        principalColumn: "codCargo");
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    numeroConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codCliente1 = table.Column<int>(type: "int", nullable: true),
                    valorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.numeroConta);
                    table.ForeignKey(
                        name: "FK_Conta_Cliente_codCliente1",
                        column: x => x.codCliente1,
                        principalTable: "Cliente",
                        principalColumn: "codCliente");
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    codFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codEndereco1 = table.Column<int>(type: "int", nullable: true),
                    numeroQuartoSolteiro = table.Column<int>(type: "int", nullable: false),
                    valorQuartoSolteiro = table.Column<double>(type: "float", nullable: false),
                    numeroQuartoCasal = table.Column<int>(type: "int", nullable: false),
                    valorQuartoCasal = table.Column<double>(type: "float", nullable: false),
                    numeroQuartoFamilia = table.Column<int>(type: "int", nullable: false),
                    valorQuartoFamilia = table.Column<double>(type: "float", nullable: false),
                    numeroQuartoPresidencial = table.Column<int>(type: "int", nullable: false),
                    valorQuartoPresidencial = table.Column<double>(type: "float", nullable: false),
                    quantidadeEstrelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.codFilial);
                    table.ForeignKey(
                        name: "FK_Filial_Endereco_codEndereco1",
                        column: x => x.codEndereco1,
                        principalTable: "Endereco",
                        principalColumn: "codEndereco");
                });

            migrationBuilder.CreateTable(
                name: "Quarto",
                columns: table => new
                {
                    numeroQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codTipoQuartocodTipo = table.Column<int>(type: "int", nullable: true),
                    valorQuarto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarto", x => x.numeroQuarto);
                    table.ForeignKey(
                        name: "FK_Quarto_TipoQuarto_codTipoQuartocodTipo",
                        column: x => x.codTipoQuartocodTipo,
                        principalTable: "TipoQuarto",
                        principalColumn: "codTipo");
                });

            migrationBuilder.CreateTable(
                name: "ConsumoRestauranteFrigobar",
                columns: table => new
                {
                    codConsumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroConta1 = table.Column<int>(type: "int", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor = table.Column<double>(type: "float", nullable: false),
                    restauranteEntregaQuarto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoRestauranteFrigobar", x => x.codConsumo);
                    table.ForeignKey(
                        name: "FK_ConsumoRestauranteFrigobar_Conta_numeroConta1",
                        column: x => x.numeroConta1,
                        principalTable: "Conta",
                        principalColumn: "numeroConta");
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    codPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codForma1 = table.Column<int>(type: "int", nullable: true),
                    numeroConta1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.codPagamento);
                    table.ForeignKey(
                        name: "FK_Pagamento_Conta_numeroConta1",
                        column: x => x.numeroConta1,
                        principalTable: "Conta",
                        principalColumn: "numeroConta");
                    table.ForeignKey(
                        name: "FK_Pagamento_FormaPagamento_codForma1",
                        column: x => x.codForma1,
                        principalTable: "FormaPagamento",
                        principalColumn: "codForma");
                });

            migrationBuilder.CreateTable(
                name: "ServicoLavanderia",
                columns: table => new
                {
                    codServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroConta1 = table.Column<int>(type: "int", nullable: true),
                    codTipoServico1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoLavanderia", x => x.codServico);
                    table.ForeignKey(
                        name: "FK_ServicoLavanderia_Conta_numeroConta1",
                        column: x => x.numeroConta1,
                        principalTable: "Conta",
                        principalColumn: "numeroConta");
                    table.ForeignKey(
                        name: "FK_ServicoLavanderia_TipoServicoLavanderia_codTipoServico1",
                        column: x => x.codTipoServico1,
                        principalTable: "TipoServicoLavanderia",
                        principalColumn: "codTipoServico");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    codReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroQuarto1 = table.Column<int>(type: "int", nullable: true),
                    codFuncionario1 = table.Column<int>(type: "int", nullable: true),
                    codCliente1 = table.Column<int>(type: "int", nullable: true),
                    dataCheckin = table.Column<DateOnly>(type: "date", nullable: false),
                    dataCheckout = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.codReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_codCliente1",
                        column: x => x.codCliente1,
                        principalTable: "Cliente",
                        principalColumn: "codCliente");
                    table.ForeignKey(
                        name: "FK_Reserva_Funcionario_codFuncionario1",
                        column: x => x.codFuncionario1,
                        principalTable: "Funcionario",
                        principalColumn: "codFuncionario");
                    table.ForeignKey(
                        name: "FK_Reserva_Quarto_numeroQuarto1",
                        column: x => x.numeroQuarto1,
                        principalTable: "Quarto",
                        principalColumn: "numeroQuarto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoRestauranteFrigobar_numeroConta1",
                table: "ConsumoRestauranteFrigobar",
                column: "numeroConta1");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_codCliente1",
                table: "Conta",
                column: "codCliente1");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_codEndereco1",
                table: "Filial",
                column: "codEndereco1");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_codCargo1",
                table: "Funcionario",
                column: "codCargo1");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_codForma1",
                table: "Pagamento",
                column: "codForma1");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_numeroConta1",
                table: "Pagamento",
                column: "numeroConta1");

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_codTipoQuartocodTipo",
                table: "Quarto",
                column: "codTipoQuartocodTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_codCliente1",
                table: "Reserva",
                column: "codCliente1");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_codFuncionario1",
                table: "Reserva",
                column: "codFuncionario1");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_numeroQuarto1",
                table: "Reserva",
                column: "numeroQuarto1");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoLavanderia_codTipoServico1",
                table: "ServicoLavanderia",
                column: "codTipoServico1");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoLavanderia_numeroConta1",
                table: "ServicoLavanderia",
                column: "numeroConta1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumoRestauranteFrigobar");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "ServicoLavanderia");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Quarto");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "TipoServicoLavanderia");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "TipoQuarto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
