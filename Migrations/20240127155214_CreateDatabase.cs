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
                name: "MCargo",
                columns: table => new
                {
                    codCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCargo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCargo", x => x.codCargo);
                });

            migrationBuilder.CreateTable(
                name: "MCliente",
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
                    table.PrimaryKey("PK_MCliente", x => x.codCliente);
                });

            migrationBuilder.CreateTable(
                name: "MEndereco",
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
                    table.PrimaryKey("PK_MEndereco", x => x.codEndereco);
                });

            migrationBuilder.CreateTable(
                name: "MFormaPagamento",
                columns: table => new
                {
                    codForma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    forma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MFormaPagamento", x => x.codForma);
                });

            migrationBuilder.CreateTable(
                name: "MTipoQuarto",
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
                    table.PrimaryKey("PK_MTipoQuarto", x => x.codTipo);
                });

            migrationBuilder.CreateTable(
                name: "MTipoServicoLavanderia",
                columns: table => new
                {
                    codTipoServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    servico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTipoServicoLavanderia", x => x.codTipoServico);
                });

            migrationBuilder.CreateTable(
                name: "MFuncionario",
                columns: table => new
                {
                    codFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codCargo1 = table.Column<int>(type: "int", nullable: true),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MFuncionario", x => x.codFuncionario);
                    table.ForeignKey(
                        name: "FK_MFuncionario_MCargo_codCargo1",
                        column: x => x.codCargo1,
                        principalTable: "MCargo",
                        principalColumn: "codCargo");
                });

            migrationBuilder.CreateTable(
                name: "MConta",
                columns: table => new
                {
                    numeroConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codCliente1 = table.Column<int>(type: "int", nullable: true),
                    valorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MConta", x => x.numeroConta);
                    table.ForeignKey(
                        name: "FK_MConta_MCliente_codCliente1",
                        column: x => x.codCliente1,
                        principalTable: "MCliente",
                        principalColumn: "codCliente");
                });

            migrationBuilder.CreateTable(
                name: "MFilial",
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
                    table.PrimaryKey("PK_MFilial", x => x.codFilial);
                    table.ForeignKey(
                        name: "FK_MFilial_MEndereco_codEndereco1",
                        column: x => x.codEndereco1,
                        principalTable: "MEndereco",
                        principalColumn: "codEndereco");
                });

            migrationBuilder.CreateTable(
                name: "MQuarto",
                columns: table => new
                {
                    numeroQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codTipoQuartocodTipo = table.Column<int>(type: "int", nullable: true),
                    valorQuarto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MQuarto", x => x.numeroQuarto);
                    table.ForeignKey(
                        name: "FK_MQuarto_MTipoQuarto_codTipoQuartocodTipo",
                        column: x => x.codTipoQuartocodTipo,
                        principalTable: "MTipoQuarto",
                        principalColumn: "codTipo");
                });

            migrationBuilder.CreateTable(
                name: "MConsumoRestauranteFrigobar",
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
                    table.PrimaryKey("PK_MConsumoRestauranteFrigobar", x => x.codConsumo);
                    table.ForeignKey(
                        name: "FK_MConsumoRestauranteFrigobar_MConta_numeroConta1",
                        column: x => x.numeroConta1,
                        principalTable: "MConta",
                        principalColumn: "numeroConta");
                });

            migrationBuilder.CreateTable(
                name: "MPagamento",
                columns: table => new
                {
                    codPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codForma1 = table.Column<int>(type: "int", nullable: true),
                    numeroConta1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPagamento", x => x.codPagamento);
                    table.ForeignKey(
                        name: "FK_MPagamento_MConta_numeroConta1",
                        column: x => x.numeroConta1,
                        principalTable: "MConta",
                        principalColumn: "numeroConta");
                    table.ForeignKey(
                        name: "FK_MPagamento_MFormaPagamento_codForma1",
                        column: x => x.codForma1,
                        principalTable: "MFormaPagamento",
                        principalColumn: "codForma");
                });

            migrationBuilder.CreateTable(
                name: "MServicoLavanderia",
                columns: table => new
                {
                    codServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroConta1 = table.Column<int>(type: "int", nullable: true),
                    codTipoServico1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MServicoLavanderia", x => x.codServico);
                    table.ForeignKey(
                        name: "FK_MServicoLavanderia_MConta_numeroConta1",
                        column: x => x.numeroConta1,
                        principalTable: "MConta",
                        principalColumn: "numeroConta");
                    table.ForeignKey(
                        name: "FK_MServicoLavanderia_MTipoServicoLavanderia_codTipoServico1",
                        column: x => x.codTipoServico1,
                        principalTable: "MTipoServicoLavanderia",
                        principalColumn: "codTipoServico");
                });

            migrationBuilder.CreateTable(
                name: "MReserva",
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
                    table.PrimaryKey("PK_MReserva", x => x.codReserva);
                    table.ForeignKey(
                        name: "FK_MReserva_MCliente_codCliente1",
                        column: x => x.codCliente1,
                        principalTable: "MCliente",
                        principalColumn: "codCliente");
                    table.ForeignKey(
                        name: "FK_MReserva_MFuncionario_codFuncionario1",
                        column: x => x.codFuncionario1,
                        principalTable: "MFuncionario",
                        principalColumn: "codFuncionario");
                    table.ForeignKey(
                        name: "FK_MReserva_MQuarto_numeroQuarto1",
                        column: x => x.numeroQuarto1,
                        principalTable: "MQuarto",
                        principalColumn: "numeroQuarto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MConsumoRestauranteFrigobar_numeroConta1",
                table: "MConsumoRestauranteFrigobar",
                column: "numeroConta1");

            migrationBuilder.CreateIndex(
                name: "IX_MConta_codCliente1",
                table: "MConta",
                column: "codCliente1");

            migrationBuilder.CreateIndex(
                name: "IX_MFilial_codEndereco1",
                table: "MFilial",
                column: "codEndereco1");

            migrationBuilder.CreateIndex(
                name: "IX_MFuncionario_codCargo1",
                table: "MFuncionario",
                column: "codCargo1");

            migrationBuilder.CreateIndex(
                name: "IX_MPagamento_codForma1",
                table: "MPagamento",
                column: "codForma1");

            migrationBuilder.CreateIndex(
                name: "IX_MPagamento_numeroConta1",
                table: "MPagamento",
                column: "numeroConta1");

            migrationBuilder.CreateIndex(
                name: "IX_MQuarto_codTipoQuartocodTipo",
                table: "MQuarto",
                column: "codTipoQuartocodTipo");

            migrationBuilder.CreateIndex(
                name: "IX_MReserva_codCliente1",
                table: "MReserva",
                column: "codCliente1");

            migrationBuilder.CreateIndex(
                name: "IX_MReserva_codFuncionario1",
                table: "MReserva",
                column: "codFuncionario1");

            migrationBuilder.CreateIndex(
                name: "IX_MReserva_numeroQuarto1",
                table: "MReserva",
                column: "numeroQuarto1");

            migrationBuilder.CreateIndex(
                name: "IX_MServicoLavanderia_codTipoServico1",
                table: "MServicoLavanderia",
                column: "codTipoServico1");

            migrationBuilder.CreateIndex(
                name: "IX_MServicoLavanderia_numeroConta1",
                table: "MServicoLavanderia",
                column: "numeroConta1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MConsumoRestauranteFrigobar");

            migrationBuilder.DropTable(
                name: "MFilial");

            migrationBuilder.DropTable(
                name: "MPagamento");

            migrationBuilder.DropTable(
                name: "MReserva");

            migrationBuilder.DropTable(
                name: "MServicoLavanderia");

            migrationBuilder.DropTable(
                name: "MEndereco");

            migrationBuilder.DropTable(
                name: "MFormaPagamento");

            migrationBuilder.DropTable(
                name: "MFuncionario");

            migrationBuilder.DropTable(
                name: "MQuarto");

            migrationBuilder.DropTable(
                name: "MConta");

            migrationBuilder.DropTable(
                name: "MTipoServicoLavanderia");

            migrationBuilder.DropTable(
                name: "MCargo");

            migrationBuilder.DropTable(
                name: "MTipoQuarto");

            migrationBuilder.DropTable(
                name: "MCliente");
        }
    }
}
