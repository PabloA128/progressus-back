﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgressusWebApi.DataContext;

#nullable disable

namespace ProgressusWebApi.Migrations
{
    [DbContext(typeof(ProgressusDataContext))]
    partial class ProgressusDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProgressusWebApi.Model.DiaDePlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumeroDeDia")
                        .HasColumnType("int");

                    b.Property<int>("PlanDeEntrenamientoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanDeEntrenamientoId");

                    b.ToTable("DiasDePlan");
                });

            modelBuilder.Entity("ProgressusWebApi.Model.ObjetivoDelPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ObjetivosDePlanes");
                });

            modelBuilder.Entity("ProgressusWebApi.Model.PlanDeEntrenamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiasPorSemana")
                        .HasColumnType("int");

                    b.Property<string>("DueñoDePlanId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DueñoDelPlanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("EsPlantilla")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjetivoDelPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DueñoDelPlanId");

                    b.HasIndex("ObjetivoDelPlanId");

                    b.ToTable("PlanesDeEntrenamiento");
                });

            modelBuilder.Entity("ProgressusWebApi.Model.SerieDeEjercicio", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DiaDePlanId")
                        .HasColumnType("int");

                    b.Property<int>("EjercicioId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroDeSerie")
                        .HasColumnType("int");

                    b.Property<int>("RepeticionesConcretadas")
                        .HasColumnType("int");

                    b.Property<int>("SemanaDelPlan")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaDeRealizacion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "DiaDePlanId", "EjercicioId");

                    b.HasIndex("EjercicioId", "DiaDePlanId");

                    b.ToTable("SeriesDeEjercicio");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.CobroModels.Membresia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MesesDuracion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Membresias");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.Ejercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenMaquina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoEjercicio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ejercicios");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.GrupoMuscular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenGrupoMuscular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GruposMusculares");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.Musculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrupoMuscularId")
                        .HasColumnType("int");

                    b.Property<string>("ImagenMusculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoMuscularId");

                    b.ToTable("Musculos");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.MusculoDeEjercicio", b =>
                {
                    b.Property<int>("EjercicioId")
                        .HasColumnType("int");

                    b.Property<int>("MusculoId")
                        .HasColumnType("int");

                    b.HasKey("EjercicioId", "MusculoId");

                    b.HasIndex("MusculoId");

                    b.ToTable("MusculosDeEjercicios");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.Entrenador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Entrenadores");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.EstadoSolicitud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstadoSolicitudes");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.HistorialSolicitudDePago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadoSolicitudId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCambioEstado")
                        .HasColumnType("datetime2");

                    b.Property<int>("SolicitudDePagoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoSolicitudId");

                    b.HasIndex("SolicitudDePagoId");

                    b.ToTable("HistorialSolicitudDePagos");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.Socio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Socios");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.SolicitudDePago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MembresiaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDePagoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MembresiaId");

                    b.HasIndex("TipoDePagoId");

                    b.ToTable("SolicitudDePagos");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.TipoDePago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDePagos");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.PlanEntrenamientoModels.AsignacionDePlan", b =>
                {
                    b.Property<int>("PlanDeEntrenamientoId")
                        .HasColumnType("int");

                    b.Property<string>("SocioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("esVigente")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaDeAsginacion")
                        .HasColumnType("datetime2");

                    b.HasKey("PlanDeEntrenamientoId", "SocioId");

                    b.HasIndex("SocioId");

                    b.ToTable("AsignacionesDePlanes");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.PlanEntrenamientoModels.EjercicioEnDiaDelPlan", b =>
                {
                    b.Property<int>("EjercicioId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("DiaDePlanId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("OrdenDeEjercicio")
                        .HasColumnType("int");

                    b.Property<int>("Repeticiones")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.HasKey("EjercicioId", "DiaDePlanId");

                    b.HasIndex("DiaDePlanId");

                    b.ToTable("EjerciciosDelDia");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgressusWebApi.Model.DiaDePlan", b =>
                {
                    b.HasOne("ProgressusWebApi.Model.PlanDeEntrenamiento", "PlanDeEntrenamiento")
                        .WithMany("DiasDelPlan")
                        .HasForeignKey("PlanDeEntrenamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanDeEntrenamiento");
                });

            modelBuilder.Entity("ProgressusWebApi.Model.PlanDeEntrenamiento", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "DueñoDelPlan")
                        .WithMany()
                        .HasForeignKey("DueñoDelPlanId");

                    b.HasOne("ProgressusWebApi.Model.ObjetivoDelPlan", "ObjetivoDelPlan")
                        .WithMany("PlanesDeEntrenamiento")
                        .HasForeignKey("ObjetivoDelPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DueñoDelPlan");

                    b.Navigation("ObjetivoDelPlan");
                });

            modelBuilder.Entity("ProgressusWebApi.Model.SerieDeEjercicio", b =>
                {
                    b.HasOne("ProgressusWebApi.Models.PlanEntrenamientoModels.EjercicioEnDiaDelPlan", "EjercicioDelDia")
                        .WithMany("SeriesDeEjercicio")
                        .HasForeignKey("EjercicioId", "DiaDePlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EjercicioDelDia");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.Musculo", b =>
                {
                    b.HasOne("ProgressusWebApi.Models.EjercicioModels.GrupoMuscular", "GrupoMuscular")
                        .WithMany("MusculosDelGrupo")
                        .HasForeignKey("GrupoMuscularId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoMuscular");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.MusculoDeEjercicio", b =>
                {
                    b.HasOne("ProgressusWebApi.Models.EjercicioModels.Ejercicio", "Ejercicio")
                        .WithMany("MusculosDeEjercicio")
                        .HasForeignKey("EjercicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgressusWebApi.Models.EjercicioModels.Musculo", "Musculo")
                        .WithMany("MusculosDeEjercicio")
                        .HasForeignKey("MusculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ejercicio");

                    b.Navigation("Musculo");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.Entrenador", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.HistorialSolicitudDePago", b =>
                {
                    b.HasOne("ProgressusWebApi.Models.MembresiaModels.EstadoSolicitud", "EstadoSolicitud")
                        .WithMany()
                        .HasForeignKey("EstadoSolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgressusWebApi.Models.MembresiaModels.SolicitudDePago", "SolicitudDePago")
                        .WithMany("HistorialSolicitudDePagos")
                        .HasForeignKey("SolicitudDePagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoSolicitud");

                    b.Navigation("SolicitudDePago");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.Socio", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.SolicitudDePago", b =>
                {
                    b.HasOne("ProgressusWebApi.Models.CobroModels.Membresia", "Membresia")
                        .WithMany()
                        .HasForeignKey("MembresiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgressusWebApi.Models.MembresiaModels.TipoDePago", "TipoDePago")
                        .WithMany()
                        .HasForeignKey("TipoDePagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membresia");

                    b.Navigation("TipoDePago");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.PlanEntrenamientoModels.AsignacionDePlan", b =>
                {
                    b.HasOne("ProgressusWebApi.Model.PlanDeEntrenamiento", "PlanDeEntrenamiento")
                        .WithMany("Asignaciones")
                        .HasForeignKey("PlanDeEntrenamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Socio")
                        .WithMany()
                        .HasForeignKey("SocioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanDeEntrenamiento");

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.PlanEntrenamientoModels.EjercicioEnDiaDelPlan", b =>
                {
                    b.HasOne("ProgressusWebApi.Model.DiaDePlan", "DiaDePlan")
                        .WithMany("EjerciciosDelDia")
                        .HasForeignKey("DiaDePlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgressusWebApi.Models.EjercicioModels.Ejercicio", "Ejercicio")
                        .WithMany()
                        .HasForeignKey("EjercicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiaDePlan");

                    b.Navigation("Ejercicio");
                });

            modelBuilder.Entity("ProgressusWebApi.Model.DiaDePlan", b =>
                {
                    b.Navigation("EjerciciosDelDia");
                });

            modelBuilder.Entity("ProgressusWebApi.Model.ObjetivoDelPlan", b =>
                {
                    b.Navigation("PlanesDeEntrenamiento");
                });

            modelBuilder.Entity("ProgressusWebApi.Model.PlanDeEntrenamiento", b =>
                {
                    b.Navigation("Asignaciones");

                    b.Navigation("DiasDelPlan");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.Ejercicio", b =>
                {
                    b.Navigation("MusculosDeEjercicio");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.GrupoMuscular", b =>
                {
                    b.Navigation("MusculosDelGrupo");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.EjercicioModels.Musculo", b =>
                {
                    b.Navigation("MusculosDeEjercicio");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.MembresiaModels.SolicitudDePago", b =>
                {
                    b.Navigation("HistorialSolicitudDePagos");
                });

            modelBuilder.Entity("ProgressusWebApi.Models.PlanEntrenamientoModels.EjercicioEnDiaDelPlan", b =>
                {
                    b.Navigation("SeriesDeEjercicio");
                });
#pragma warning restore 612, 618
        }
    }
}
