using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PLCv4XFiles.Models
{
    public class PLCv4XFilesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PLCv4XFilesContext() : base("name=PLCv4XFilesContext")
        {
        }

        public System.Data.Entity.DbSet<PLCv4XFiles.Models.z_PLC_Device> z_PLC_Device { get; set; }

        public System.Data.Entity.DbSet<PLCv4XFiles.Models.z_PLC_Contador> z_PLC_Contador { get; set; }

        public System.Data.Entity.DbSet<PLCv4XFiles.Models.z_PLC_Tag> z_PLC_Tag { get; set; }
    }
}
