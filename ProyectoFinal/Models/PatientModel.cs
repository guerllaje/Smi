using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Web.Mvc;

namespace ProyectoFinal.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo -Nombre- es requerido.")]
        [StringLength(60)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo -Apellido- es requerido.")]
        [StringLength(60)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo -Cedula- es requerido.")]
        [StringLength(11, MinimumLength = 11)]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo -Fecha de Nacimiento- es requerido.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo -Edad- es requerido.")]
        public int Edad { get; set; }

        //[Required(ErrorMessage = "El campo -Sexo- es requerido.")]
        public string Sexo { get; set; }

        //[Required(ErrorMessage = "El campo -Tipo de Sangre- es requerido.")]
        public string TipoSangre { get; set; }

        public string SeguroMedico { get; set; }

        public string NumeroSeguroMedico { get; set; }

        public string NumeroSeguroSocial { get; set; }

        [Required(ErrorMessage = "El campo -Religión- es requerido.")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "El campo -Creado por- es requerido.")]
        public string CreadoPor { get; set; }

        public FormBloodPressure formBloodPressure;

        public FormVitalSigns formVitalSigns;

        public FormVaccinations formVaccinations;
    }

    [Table("Form_Blood_Pressure")]
    public class FormBloodPressure
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo -Fecha- es requerido.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo -Sistólica- es requerido.")]
        public int Sistolica { get; set; }

        [Required(ErrorMessage = "El campo -Diastólica- es requerido.")]
        public int Diastolica { get; set; }

        [Required(ErrorMessage = "El campo -Ritmo Cardíaco- es requerido.")]
        public int RitmoCardiaco { get; set; }

        [Required(ErrorMessage = "El campo -Creado por- es requerido.")]
        public string CreadoPor { get; set; }

        [ForeignKey("PatientModel")]
        public int PatientModelId { get; set; }

        public virtual PatientModel PatientModel { get; set; }

    }

    [Table("Form_Vital_Signs")]
    public class FormVitalSigns
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo -Fecha- es requerido.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo -Peso- es requerido.")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "El campo -Temperatura- es requerido.")]
        public double Temperatura { get; set; }

        [Required(ErrorMessage = "El campo -Pulso- es requerido.")]
        public int Pulso { get; set; }

        [Required(ErrorMessage = "El campo -Presion Sanguinea- es requerido.")]
        public string PresionSanguinea { get; set; }

        [Required(ErrorMessage = "El campo -Respiracion- es requerido.")]
        public int Respiracion { get; set; }

        [Required(ErrorMessage = "El campo -Dolor- es requerido.")]
        public string Dolor { get; set; }

        [Required(ErrorMessage = "El campo -Creado por- es requerido.")]
        public string CreadoPor { get; set; }

        [ForeignKey("PatientModel")]
        public int PatientModelId { get; set; }

        public virtual PatientModel PatientModel { get; set; }

    }

    [Table("Form_Vaccinations")]
    public class FormVaccinations
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo -Vacuna- es requerido.")]
        public string Vacuna { get; set; }

        public string OtraVacuna { get; set; }

        [Required(ErrorMessage = "El campo -Fecha de inicio- es requerido.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo -Fecha de expiración- es requerido.")]
        public DateTime FechaSiguiente { get; set; }

        [Required(ErrorMessage = "El campo -Creado por- es requerido.")]
        public string CreadoPor { get; set; }

        [ForeignKey("PatientModel")]
        public int PatientModelId { get; set; }

        public virtual PatientModel PatientModel { get; set; }
    }

    public class PatientModelDBContext : DbContext
    {
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<FormBloodPressure> FormBlood { get; set; }
        public DbSet<FormVitalSigns> FormVital { get; set; }
        public DbSet<FormVaccinations> FormVacci { get; set; }
        public DbSet<RootObject> RootObjects { get; set; }
        public DbSet<ModeloDatos> ModeloDato { get; set; }
        public DbSet<ModeloExamen> ModeloExamenes { get; set; }
        public DbSet<ModeloMotivos> ModeloMotivo { get; set; }
        public DbSet<ModeloTrauma> ModeloTraumas { get; set; }
        public DbSet<Fecha> Fecha { get; set; }
    }
}