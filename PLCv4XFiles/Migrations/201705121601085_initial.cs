namespace PLCv4XFiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.z_PLC_Contador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PLC_DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.z_PLC_Device", t => t.PLC_DeviceId, cascadeDelete: true)
                .Index(t => t.PLC_DeviceId);
            
            CreateTable(
                "dbo.z_PLC_Device",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Modelo = c.String(),
                        EnderecoFisico = c.String(),
                        IP = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.z_PLC_Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Valor = c.Int(nullable: false),
                        Serie = c.Boolean(nullable: false),
                        PLC_ContadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.z_PLC_Device", t => t.PLC_ContadorId, cascadeDelete: true)
                .Index(t => t.PLC_ContadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.z_PLC_Tag", "PLC_ContadorId", "dbo.z_PLC_Device");
            DropForeignKey("dbo.z_PLC_Contador", "PLC_DeviceId", "dbo.z_PLC_Device");
            DropIndex("dbo.z_PLC_Tag", new[] { "PLC_ContadorId" });
            DropIndex("dbo.z_PLC_Contador", new[] { "PLC_DeviceId" });
            DropTable("dbo.z_PLC_Tag");
            DropTable("dbo.z_PLC_Device");
            DropTable("dbo.z_PLC_Contador");
        }
    }
}
