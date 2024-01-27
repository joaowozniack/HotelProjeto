﻿// <auto-generated />
using System;
using HotelProjeto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelProjeto.Migrations
{
    [DbContext(typeof(HotelProjetoContext))]
    [Migration("20240127155214_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelProjeto.MCargo", b =>
                {
                    b.Property<int>("codCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codCargo"));

                    b.Property<string>("nomeCargo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codCargo");

                    b.ToTable("MCargo");
                });

            modelBuilder.Entity("HotelProjeto.MCliente", b =>
                {
                    b.Property<int>("codCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codCliente"));

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nacionalidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codCliente");

                    b.ToTable("MCliente");
                });

            modelBuilder.Entity("HotelProjeto.MConsumoRestauranteFrigobar", b =>
                {
                    b.Property<int>("codConsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codConsumo"));

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("numeroConta1")
                        .HasColumnType("int");

                    b.Property<bool>("restauranteEntregaQuarto")
                        .HasColumnType("bit");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("codConsumo");

                    b.HasIndex("numeroConta1");

                    b.ToTable("MConsumoRestauranteFrigobar");
                });

            modelBuilder.Entity("HotelProjeto.MConta", b =>
                {
                    b.Property<int>("numeroConta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("numeroConta"));

                    b.Property<int?>("codCliente1")
                        .HasColumnType("int");

                    b.Property<double>("valorTotal")
                        .HasColumnType("float");

                    b.HasKey("numeroConta");

                    b.HasIndex("codCliente1");

                    b.ToTable("MConta");
                });

            modelBuilder.Entity("HotelProjeto.MEndereco", b =>
                {
                    b.Property<int>("codEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codEndereco"));

                    b.Property<string>("bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.Property<string>("rua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codEndereco");

                    b.ToTable("MEndereco");
                });

            modelBuilder.Entity("HotelProjeto.MFilial", b =>
                {
                    b.Property<int>("codFilial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codFilial"));

                    b.Property<int?>("codEndereco1")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numeroQuartoCasal")
                        .HasColumnType("int");

                    b.Property<int>("numeroQuartoFamilia")
                        .HasColumnType("int");

                    b.Property<int>("numeroQuartoPresidencial")
                        .HasColumnType("int");

                    b.Property<int>("numeroQuartoSolteiro")
                        .HasColumnType("int");

                    b.Property<int>("quantidadeEstrelas")
                        .HasColumnType("int");

                    b.Property<double>("valorQuartoCasal")
                        .HasColumnType("float");

                    b.Property<double>("valorQuartoFamilia")
                        .HasColumnType("float");

                    b.Property<double>("valorQuartoPresidencial")
                        .HasColumnType("float");

                    b.Property<double>("valorQuartoSolteiro")
                        .HasColumnType("float");

                    b.HasKey("codFilial");

                    b.HasIndex("codEndereco1");

                    b.ToTable("MFilial");
                });

            modelBuilder.Entity("HotelProjeto.MFormaPagamento", b =>
                {
                    b.Property<int>("codForma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codForma"));

                    b.Property<string>("forma")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codForma");

                    b.ToTable("MFormaPagamento");
                });

            modelBuilder.Entity("HotelProjeto.MFuncionario", b =>
                {
                    b.Property<int>("codFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codFuncionario"));

                    b.Property<int?>("codCargo1")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codFuncionario");

                    b.HasIndex("codCargo1");

                    b.ToTable("MFuncionario");
                });

            modelBuilder.Entity("HotelProjeto.MPagamento", b =>
                {
                    b.Property<int>("codPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codPagamento"));

                    b.Property<int?>("codForma1")
                        .HasColumnType("int");

                    b.Property<int?>("numeroConta1")
                        .HasColumnType("int");

                    b.HasKey("codPagamento");

                    b.HasIndex("codForma1");

                    b.HasIndex("numeroConta1");

                    b.ToTable("MPagamento");
                });

            modelBuilder.Entity("HotelProjeto.MQuarto", b =>
                {
                    b.Property<int>("numeroQuarto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("numeroQuarto"));

                    b.Property<int?>("codTipoQuartocodTipo")
                        .HasColumnType("int");

                    b.Property<double>("valorQuarto")
                        .HasColumnType("float");

                    b.HasKey("numeroQuarto");

                    b.HasIndex("codTipoQuartocodTipo");

                    b.ToTable("MQuarto");
                });

            modelBuilder.Entity("HotelProjeto.MReserva", b =>
                {
                    b.Property<int>("codReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codReserva"));

                    b.Property<int?>("codCliente1")
                        .HasColumnType("int");

                    b.Property<int?>("codFuncionario1")
                        .HasColumnType("int");

                    b.Property<DateOnly>("dataCheckin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("dataCheckout")
                        .HasColumnType("date");

                    b.Property<int?>("numeroQuarto1")
                        .HasColumnType("int");

                    b.HasKey("codReserva");

                    b.HasIndex("codCliente1");

                    b.HasIndex("codFuncionario1");

                    b.HasIndex("numeroQuarto1");

                    b.ToTable("MReserva");
                });

            modelBuilder.Entity("HotelProjeto.MServicoLavanderia", b =>
                {
                    b.Property<int>("codServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codServico"));

                    b.Property<int?>("codTipoServico1")
                        .HasColumnType("int");

                    b.Property<int?>("numeroConta1")
                        .HasColumnType("int");

                    b.HasKey("codServico");

                    b.HasIndex("codTipoServico1");

                    b.HasIndex("numeroConta1");

                    b.ToTable("MServicoLavanderia");
                });

            modelBuilder.Entity("HotelProjeto.MTipoQuarto", b =>
                {
                    b.Property<int>("codTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codTipo"));

                    b.Property<bool>("capacidadeOpcional")
                        .HasColumnType("bit");

                    b.Property<int>("capcidadeMaxima")
                        .HasColumnType("int");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codTipo");

                    b.ToTable("MTipoQuarto");
                });

            modelBuilder.Entity("HotelProjeto.MTipoServicoLavanderia", b =>
                {
                    b.Property<int>("codTipoServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codTipoServico"));

                    b.Property<string>("servico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("codTipoServico");

                    b.ToTable("MTipoServicoLavanderia");
                });

            modelBuilder.Entity("HotelProjeto.MConsumoRestauranteFrigobar", b =>
                {
                    b.HasOne("HotelProjeto.MConta", "numeroConta")
                        .WithMany()
                        .HasForeignKey("numeroConta1");

                    b.Navigation("numeroConta");
                });

            modelBuilder.Entity("HotelProjeto.MConta", b =>
                {
                    b.HasOne("HotelProjeto.MCliente", "codCliente")
                        .WithMany()
                        .HasForeignKey("codCliente1");

                    b.Navigation("codCliente");
                });

            modelBuilder.Entity("HotelProjeto.MFilial", b =>
                {
                    b.HasOne("HotelProjeto.MEndereco", "codEndereco")
                        .WithMany()
                        .HasForeignKey("codEndereco1");

                    b.Navigation("codEndereco");
                });

            modelBuilder.Entity("HotelProjeto.MFuncionario", b =>
                {
                    b.HasOne("HotelProjeto.MCargo", "codCargo")
                        .WithMany()
                        .HasForeignKey("codCargo1");

                    b.Navigation("codCargo");
                });

            modelBuilder.Entity("HotelProjeto.MPagamento", b =>
                {
                    b.HasOne("HotelProjeto.MFormaPagamento", "codForma")
                        .WithMany()
                        .HasForeignKey("codForma1");

                    b.HasOne("HotelProjeto.MConta", "numeroConta")
                        .WithMany()
                        .HasForeignKey("numeroConta1");

                    b.Navigation("codForma");

                    b.Navigation("numeroConta");
                });

            modelBuilder.Entity("HotelProjeto.MQuarto", b =>
                {
                    b.HasOne("HotelProjeto.MTipoQuarto", "codTipoQuarto")
                        .WithMany()
                        .HasForeignKey("codTipoQuartocodTipo");

                    b.Navigation("codTipoQuarto");
                });

            modelBuilder.Entity("HotelProjeto.MReserva", b =>
                {
                    b.HasOne("HotelProjeto.MCliente", "codCliente")
                        .WithMany()
                        .HasForeignKey("codCliente1");

                    b.HasOne("HotelProjeto.MFuncionario", "codFuncionario")
                        .WithMany()
                        .HasForeignKey("codFuncionario1");

                    b.HasOne("HotelProjeto.MQuarto", "numeroQuarto")
                        .WithMany()
                        .HasForeignKey("numeroQuarto1");

                    b.Navigation("codCliente");

                    b.Navigation("codFuncionario");

                    b.Navigation("numeroQuarto");
                });

            modelBuilder.Entity("HotelProjeto.MServicoLavanderia", b =>
                {
                    b.HasOne("HotelProjeto.MTipoServicoLavanderia", "codTipoServico")
                        .WithMany()
                        .HasForeignKey("codTipoServico1");

                    b.HasOne("HotelProjeto.MConta", "numeroConta")
                        .WithMany()
                        .HasForeignKey("numeroConta1");

                    b.Navigation("codTipoServico");

                    b.Navigation("numeroConta");
                });
#pragma warning restore 612, 618
        }
    }
}