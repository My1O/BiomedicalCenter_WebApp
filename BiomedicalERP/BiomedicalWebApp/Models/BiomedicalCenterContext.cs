using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BiomedicalWebApp.Models
{
    public partial class BiomedicalCenterContext : DbContext
    {
        public BiomedicalCenterContext()
        {
        }

        public BiomedicalCenterContext(DbContextOptions<BiomedicalCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Concepto> Conceptos { get; set; } = null!;
        public virtual DbSet<Especialidad> Especialidads { get; set; } = null!;
        public virtual DbSet<HistoriaPaciente> HistoriaPacientes { get; set; } = null!;
        public virtual DbSet<Historium> Historia { get; set; } = null!;
        public virtual DbSet<Medico> Medicos { get; set; } = null!;
        public virtual DbSet<MedicoEspecialidad> MedicoEspecialidads { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<PacienteTurnosPendiente> PacienteTurnosPendientes { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<PagoPaciente> PagoPacientes { get; set; } = null!;
        public virtual DbSet<Pai> Pais { get; set; } = null!;
        public virtual DbSet<Turno> Turnos { get; set; } = null!;
        public virtual DbSet<TurnoEstado> TurnoEstados { get; set; } = null!;
        public virtual DbSet<TurnoPaciente> TurnoPacientes { get; set; } = null!;

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.HasKey(e => e.IdConcepto)
                    .HasName("PK_IdConcepto");

                entity.ToTable("Concepto");

                entity.Property(e => e.IdConcepto).ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad)
                    .HasName("PK_IdEspecialidad");

                entity.ToTable("Especialidad");

                entity.Property(e => e.Especialidad1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Especialidad");
            });

            modelBuilder.Entity<HistoriaPaciente>(entity =>
            {
                entity.HasKey(e => new { e.IdHistoria, e.IdPaciente, e.IdMedico })
                    .HasName("PK_IdHistoriaPaciente");

                entity.ToTable("HistoriaPaciente");

                entity.HasOne(d => d.IdHistoriaNavigation)
                    .WithMany(p => p.HistoriaPacientes)
                    .HasForeignKey(d => d.IdHistoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoriaPaciente_Historia");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.HistoriaPacientes)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoriaPaciente_Medico");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.HistoriaPacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoriaPaciente_Paciente");
            });

            modelBuilder.Entity<Historium>(entity =>
            {
                entity.HasKey(e => e.IdHistoria)
                    .HasName("PK_IdHistoria");

                entity.Property(e => e.FechaHistoria).HasColumnType("datetime");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK_IdMedico");

                entity.ToTable("Medico", "hrdbo");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicoEspecialidad>(entity =>
            {
                entity.HasKey(e => new { e.IdMedico, e.IdEspecialidad });

                entity.ToTable("MedicoEspecialidad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.MedicoEspecialidads)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicoEspecialidad_Especialidad");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.MedicoEspecialidads)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicoEspecialidad_Medico");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente);

                entity.ToTable("Paciente", "clientedbo");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.IdPais)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK_Paciente_Pais");
            });

            modelBuilder.Entity<PacienteTurnosPendiente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PacienteTurnosPendientes");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaTurno).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK_IdPago");

                entity.ToTable("Pago");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConceptoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.Concepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_Concepto");
            });

            modelBuilder.Entity<PagoPaciente>(entity =>
            {
                entity.HasKey(e => new { e.IdPago, e.IdPaciente, e.IdTurno })
                    .HasName("PK__PagoPaci__CBD72D84C49D0942");

                entity.ToTable("PagoPaciente");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.PagoPacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PagoPaciente_Paciente");

                entity.HasOne(d => d.IdPagoNavigation)
                    .WithMany(p => p.PagoPacientes)
                    .HasForeignKey(d => d.IdPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PagoPaciente_Pago");

                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.PagoPacientes)
                    .HasForeignKey(d => d.IdTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PagoPaciente_Turno");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK_IdPais");

                entity.Property(e => e.IdPais)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaisNombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno)
                    .HasName("PK_IdTurno");

                entity.ToTable("Turno");

                entity.Property(e => e.FechaTurno).HasColumnType("datetime");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_Turno_TurnoEstado");
            });

            modelBuilder.Entity<TurnoEstado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK_IdEstado");

                entity.ToTable("TurnoEstado");

                entity.Property(e => e.IdEstado).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TurnoPaciente>(entity =>
            {
                entity.HasKey(e => new { e.IdTurno, e.IdPaciente, e.IdMedico });

                entity.ToTable("TurnoPaciente");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.TurnoPacientes)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TurnoPaciente_Medico");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.TurnoPacientes)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TurnoPaciente_Paciente1");

                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.TurnoPacientes)
                    .HasForeignKey(d => d.IdTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TurnoPaciente_Turno");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
