namespace PLCv4XFiles.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PLCv4XFiles.Models.PLCv4XFilesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PLCv4XFiles.Models.PLCv4XFilesContext context)
        {

            context.z_PLC_Device.AddOrUpdate(d =>

               d.Id,
               new z_PLC_Device() {

                   Id = 1,
                   Nome = "SLM Prod",
                   Modelo = "Siemens S7-200",
                   EnderecoFisico = "Nave 1 SLM",
                   IP = "192.168.106.98" 
               }
               
             );


            context.z_PLC_Contador.AddOrUpdate(x =>

            x.Id,
            new z_PLC_Contador()
            {
                Id = 1,
                Nome = "ContadorAbsolutoA",
                PLC_DeviceId = 1


            }
            
            );

            context.z_PLC_Tag.AddOrUpdate(x =>
            
            x.Id,
            new z_PLC_Tag() {
                Id=1,
                Nome = "Test.Device1.C0",
                Valor=33,
                Serie=false,
                PLC_ContadorId=1
            },
            new z_PLC_Tag()
            {
                Id=2,
                Nome= "Test.Device1.C1",
                Valor=1,
                Serie=true,
                PLC_ContadorId = 1


            }
            


            );








        }

    }
}
