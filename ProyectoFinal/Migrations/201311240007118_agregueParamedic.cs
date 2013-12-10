namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregueParamedic : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ModeloDatos", newName: "Modelo_Datos");
            RenameTable(name: "dbo.ModeloExamen", newName: "Modelo_Examen");
            RenameTable(name: "dbo.ModeloMotivos", newName: "Modelo_Motivos");
            RenameTable(name: "dbo.ModeloTraumas", newName: "Modelo_Trauma");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Modelo_Trauma", newName: "ModeloTraumas");
            RenameTable(name: "dbo.Modelo_Motivos", newName: "ModeloMotivos");
            RenameTable(name: "dbo.Modelo_Examen", newName: "ModeloExamen");
            RenameTable(name: "dbo.Modelo_Datos", newName: "ModeloDatos");
        }
    }
}
