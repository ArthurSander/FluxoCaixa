﻿// <auto-generated />
using System;
using FluxoCaixa.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FluxoCaixa.DataAccess.Migrations
{
    [DbContext(typeof(FluxoCaixaDbContext))]
    [Migration("20240109141437_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FluxoCaixa.DataAccess.Models.CaixaDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2")
                        .HasColumnName("atualizado_em");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2")
                        .HasColumnName("criado_em");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("pk_caixas");

                    b.ToTable("caixas", (string)null);
                });

            modelBuilder.Entity("FluxoCaixa.DataAccess.Models.LancamentoDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2")
                        .HasColumnName("atualizado_em");

                    b.Property<int>("CaixaId")
                        .HasColumnType("int")
                        .HasColumnName("caixa_id");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2")
                        .HasColumnName("criado_em");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_lancamento");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descricao");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.Property<double>("Valor")
                        .HasColumnType("float")
                        .HasColumnName("valor");

                    b.HasKey("Id")
                        .HasName("pk_lancamentos");

                    b.HasIndex("CaixaId")
                        .HasDatabaseName("ix_lancamentos_caixa_id");

                    b.ToTable("lancamentos", (string)null);
                });

            modelBuilder.Entity("FluxoCaixa.DataAccess.Models.NovoLancamentoDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CaixaId")
                        .HasColumnType("int")
                        .HasColumnName("caixa_id");

                    b.Property<int>("LancamentoId")
                        .HasColumnType("int")
                        .HasColumnName("lancamento_id");

                    b.Property<double>("SaldoAnterior")
                        .HasColumnType("float")
                        .HasColumnName("saldo_anterior");

                    b.Property<double>("SaldoAtual")
                        .HasColumnType("float")
                        .HasColumnName("saldo_atual");

                    b.HasKey("Id")
                        .HasName("pk_historico_lancamentos_caixa");

                    b.HasIndex("CaixaId")
                        .HasDatabaseName("ix_historico_lancamentos_caixa_caixa_id");

                    b.ToTable("historico_lancamentos_caixa", (string)null);
                });

            modelBuilder.Entity("FluxoCaixa.DataAccess.Models.LancamentoDataModel", b =>
                {
                    b.HasOne("FluxoCaixa.DataAccess.Models.CaixaDataModel", "Caixa")
                        .WithMany("Lancamentos")
                        .HasForeignKey("CaixaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_lancamentos_caixas_caixa_id");

                    b.Navigation("Caixa");
                });

            modelBuilder.Entity("FluxoCaixa.DataAccess.Models.NovoLancamentoDataModel", b =>
                {
                    b.HasOne("FluxoCaixa.DataAccess.Models.CaixaDataModel", "Caixa")
                        .WithMany("HistoricoLancamentos")
                        .HasForeignKey("CaixaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_historico_lancamentos_caixa_caixas_caixa_id");

                    b.Navigation("Caixa");
                });

            modelBuilder.Entity("FluxoCaixa.DataAccess.Models.CaixaDataModel", b =>
                {
                    b.Navigation("HistoricoLancamentos");

                    b.Navigation("Lancamentos");
                });
#pragma warning restore 612, 618
        }
    }
}