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
                    CodCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCargo", x => x.CodCargo);
                });

            migrationBuilder.CreateTable(
                name: "MCliente",
                columns: table => new
                {
                    CodCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCliente", x => x.CodCliente);
                });

            migrationBuilder.CreateTable(
                name: "MEndereco",
                columns: table => new
                {
                    CodEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEndereco", x => x.CodEndereco);
                });

            migrationBuilder.CreateTable(
                name: "MFormaPagamento",
                columns: table => new
                {
                    CodForma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MFormaPagamento", x => x.CodForma);
                });

            migrationBuilder.CreateTable(
                name: "MTipoQuarto",
                columns: table => new
                {
                    CodTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CapacidadeMaxima = table.Column<int>(type: "int", nullable: false),
                    CapacidadeOpcional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTipoQuarto", x => x.CodTipo);
                });

            migrationBuilder.CreateTable(
                name: "MTipoServicoLavanderia",
                columns: table => new
                {
                    CodTipoServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servico = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTipoServicoLavanderia", x => x.CodTipoServico);
                });

            migrationBuilder.CreateTable(
                name: "MFuncionario",
                columns: table => new
                {
                    CodFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCodCargo = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MFuncionario", x => x.CodFuncionario);
                    table.ForeignKey(
                        name: "FK_MFuncionario_MCargo_CargoCodCargo",
                        column: x => x.CargoCodCargo,
                        principalTable: "MCargo",
                        principalColumn: "CodCargo");
                });

            migrationBuilder.CreateTable(
                name: "MConta",
                columns: table => new
                {
                    NumeroConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteCodCliente = table.Column<int>(type: "int", nullable: true),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MConta", x => x.NumeroConta);
                    table.ForeignKey(
                        name: "FK_MConta_MCliente_ClienteCodCliente",
                        column: x => x.ClienteCodCliente,
                        principalTable: "MCliente",
                        principalColumn: "CodCliente");
                });

            migrationBuilder.CreateTable(
                name: "MFilial",
                columns: table => new
                {
                    CodFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EnderecoCodEndereco = table.Column<int>(type: "int", nullable: true),
                    QuantidadeEstrelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MFilial", x => x.CodFilial);
                    table.ForeignKey(
                        name: "FK_MFilial_MEndereco_EnderecoCodEndereco",
                        column: x => x.EnderecoCodEndereco,
                        principalTable: "MEndereco",
                        principalColumn: "CodEndereco");
                });

            migrationBuilder.CreateTable(
                name: "MQuarto",
                columns: table => new
                {
                    NumeroQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoQuartoCodTipo = table.Column<int>(type: "int", nullable: true),
                    ValorQuarto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MQuarto", x => x.NumeroQuarto);
                    table.ForeignKey(
                        name: "FK_MQuarto_MTipoQuarto_TipoQuartoCodTipo",
                        column: x => x.TipoQuartoCodTipo,
                        principalTable: "MTipoQuarto",
                        principalColumn: "CodTipo");
                });

            migrationBuilder.CreateTable(
                name: "MConsumoRestauranteFrigobar",
                columns: table => new
                {
                    CodConsumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaNumeroConta = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    RestauranteEntregaQuarto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MConsumoRestauranteFrigobar", x => x.CodConsumo);
                    table.ForeignKey(
                        name: "FK_MConsumoRestauranteFrigobar_MConta_ContaNumeroConta",
                        column: x => x.ContaNumeroConta,
                        principalTable: "MConta",
                        principalColumn: "NumeroConta");
                });

            migrationBuilder.CreateTable(
                name: "MPagamento",
                columns: table => new
                {
                    CodPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormaCodForma = table.Column<int>(type: "int", nullable: true),
                    NumeroConta1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPagamento", x => x.CodPagamento);
                    table.ForeignKey(
                        name: "FK_MPagamento_MConta_NumeroConta1",
                        column: x => x.NumeroConta1,
                        principalTable: "MConta",
                        principalColumn: "NumeroConta");
                    table.ForeignKey(
                        name: "FK_MPagamento_MFormaPagamento_FormaCodForma",
                        column: x => x.FormaCodForma,
                        principalTable: "MFormaPagamento",
                        principalColumn: "CodForma");
                });

            migrationBuilder.CreateTable(
                name: "MServicoLavanderia",
                columns: table => new
                {
                    CodServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta1 = table.Column<int>(type: "int", nullable: true),
                    TipoServicoCodTipoServico = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MServicoLavanderia", x => x.CodServico);
                    table.ForeignKey(
                        name: "FK_MServicoLavanderia_MConta_NumeroConta1",
                        column: x => x.NumeroConta1,
                        principalTable: "MConta",
                        principalColumn: "NumeroConta");
                    table.ForeignKey(
                        name: "FK_MServicoLavanderia_MTipoServicoLavanderia_TipoServicoCodTipoServico",
                        column: x => x.TipoServicoCodTipoServico,
                        principalTable: "MTipoServicoLavanderia",
                        principalColumn: "CodTipoServico");
                });

            migrationBuilder.CreateTable(
                name: "MQuartosFilial",
                columns: table => new
                {
                    CodQuartosFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilialCodFilial = table.Column<int>(type: "int", nullable: true),
                    TipoQuartoCodTipo = table.Column<int>(type: "int", nullable: true),
                    QuantidadeQuartos = table.Column<int>(type: "int", nullable: false),
                    ValorQuarto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MQuartosFilial", x => x.CodQuartosFilial);
                    table.ForeignKey(
                        name: "FK_MQuartosFilial_MFilial_FilialCodFilial",
                        column: x => x.FilialCodFilial,
                        principalTable: "MFilial",
                        principalColumn: "CodFilial");
                    table.ForeignKey(
                        name: "FK_MQuartosFilial_MTipoQuarto_TipoQuartoCodTipo",
                        column: x => x.TipoQuartoCodTipo,
                        principalTable: "MTipoQuarto",
                        principalColumn: "CodTipo");
                });

            migrationBuilder.CreateTable(
                name: "MReserva",
                columns: table => new
                {
                    CodReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuartoNumeroQuarto = table.Column<int>(type: "int", nullable: true),
                    FuncionarioCodFuncionario = table.Column<int>(type: "int", nullable: true),
                    ClienteCodCliente = table.Column<int>(type: "int", nullable: true),
                    DataCheckin = table.Column<DateOnly>(type: "date", nullable: false),
                    DataCheckout = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MReserva", x => x.CodReserva);
                    table.ForeignKey(
                        name: "FK_MReserva_MCliente_ClienteCodCliente",
                        column: x => x.ClienteCodCliente,
                        principalTable: "MCliente",
                        principalColumn: "CodCliente");
                    table.ForeignKey(
                        name: "FK_MReserva_MFuncionario_FuncionarioCodFuncionario",
                        column: x => x.FuncionarioCodFuncionario,
                        principalTable: "MFuncionario",
                        principalColumn: "CodFuncionario");
                    table.ForeignKey(
                        name: "FK_MReserva_MQuarto_QuartoNumeroQuarto",
                        column: x => x.QuartoNumeroQuarto,
                        principalTable: "MQuarto",
                        principalColumn: "NumeroQuarto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MConsumoRestauranteFrigobar_ContaNumeroConta",
                table: "MConsumoRestauranteFrigobar",
                column: "ContaNumeroConta");

            migrationBuilder.CreateIndex(
                name: "IX_MConta_ClienteCodCliente",
                table: "MConta",
                column: "ClienteCodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_MFilial_EnderecoCodEndereco",
                table: "MFilial",
                column: "EnderecoCodEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_MFuncionario_CargoCodCargo",
                table: "MFuncionario",
                column: "CargoCodCargo");

            migrationBuilder.CreateIndex(
                name: "IX_MPagamento_FormaCodForma",
                table: "MPagamento",
                column: "FormaCodForma");

            migrationBuilder.CreateIndex(
                name: "IX_MPagamento_NumeroConta1",
                table: "MPagamento",
                column: "NumeroConta1");

            migrationBuilder.CreateIndex(
                name: "IX_MQuarto_TipoQuartoCodTipo",
                table: "MQuarto",
                column: "TipoQuartoCodTipo");

            migrationBuilder.CreateIndex(
                name: "IX_MQuartosFilial_FilialCodFilial",
                table: "MQuartosFilial",
                column: "FilialCodFilial");

            migrationBuilder.CreateIndex(
                name: "IX_MQuartosFilial_TipoQuartoCodTipo",
                table: "MQuartosFilial",
                column: "TipoQuartoCodTipo");

            migrationBuilder.CreateIndex(
                name: "IX_MReserva_ClienteCodCliente",
                table: "MReserva",
                column: "ClienteCodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_MReserva_FuncionarioCodFuncionario",
                table: "MReserva",
                column: "FuncionarioCodFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_MReserva_QuartoNumeroQuarto",
                table: "MReserva",
                column: "QuartoNumeroQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_MServicoLavanderia_NumeroConta1",
                table: "MServicoLavanderia",
                column: "NumeroConta1");

            migrationBuilder.CreateIndex(
                name: "IX_MServicoLavanderia_TipoServicoCodTipoServico",
                table: "MServicoLavanderia",
                column: "TipoServicoCodTipoServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MConsumoRestauranteFrigobar");

            migrationBuilder.DropTable(
                name: "MPagamento");

            migrationBuilder.DropTable(
                name: "MQuartosFilial");

            migrationBuilder.DropTable(
                name: "MReserva");

            migrationBuilder.DropTable(
                name: "MServicoLavanderia");

            migrationBuilder.DropTable(
                name: "MFormaPagamento");

            migrationBuilder.DropTable(
                name: "MFilial");

            migrationBuilder.DropTable(
                name: "MFuncionario");

            migrationBuilder.DropTable(
                name: "MQuarto");

            migrationBuilder.DropTable(
                name: "MConta");

            migrationBuilder.DropTable(
                name: "MTipoServicoLavanderia");

            migrationBuilder.DropTable(
                name: "MEndereco");

            migrationBuilder.DropTable(
                name: "MCargo");

            migrationBuilder.DropTable(
                name: "MTipoQuarto");

            migrationBuilder.DropTable(
                name: "MCliente");
        }
    }
}
