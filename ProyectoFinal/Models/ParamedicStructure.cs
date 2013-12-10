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
    public class Fecha
    {
        public int id { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int dayOfMonth { get; set; }
        public int hourOfDay { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }

    [Table("Modelo_Datos")]
    public class ModeloDatos
    {
        public int id { get; set; }
        public string Edad { get; set; }
        public virtual Fecha Fecha { get; set; }
        public string NombrePaciente { get; set; }
        public string NombreResponsable { get; set; }
        public string NumeroContacto { get; set; }
        public string SeguroMedico { get; set; }
        public string Sexo { get; set; }
    }

    [Table("Modelo_Examen")]
    public class ModeloExamen
    {
        public int id { get; set; }
        public string Abdomen { get; set; }
        public string ApCardio { get; set; }
        public string ApRespiratorio { get; set; }
        public string Fc { get; set; }
        public string Fr { get; set; }
        public string Gasgow { get; set; }
        public string Genitourinatorio { get; set; }
        public string SistemaNervioso { get; set; }
        public string Ta { get; set; }
        public string Taxilar { get; set; }
        public string Trectal { get; set; }
    }

    [Table("Modelo_Motivos")]
    public class ModeloMotivos
    {
        public int id { get; set; }
        public string Alergias { get; set; }
        public string EnfermedadesPrevias { get; set; }
        public string InicioSintomas { get; set; }
        public string Medicacion { get; set; }
        public string MotivoConsulta { get; set; }
    }

    [Table("Modelo_Trauma")]
    public class ModeloTrauma
    {
        public int id { get; set; }
        public string Nivel { get; set; }
        public string Posicion { get; set; }
    }

    public class RootObject
    {
        public int id { get; set; }
        public virtual ModeloDatos modeloDatos { get; set; }
        public virtual ModeloExamen modeloExamen { get; set; }
        public virtual ModeloMotivos modeloMotivos { get; set; }
        public virtual ModeloTrauma modeloTrauma { get; set; }
    }
}