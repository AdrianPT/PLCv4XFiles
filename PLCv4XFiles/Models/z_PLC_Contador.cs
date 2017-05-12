using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLCv4XFiles.Models
{
    public class z_PLC_Contador
    {

        public int Id { get; set; }

        public string Nome { get; set; }



        // FK device plc al que pertenece
        public int PLC_DeviceId { get; set; }

        // Para navegar
        public z_PLC_Device PLC_Device { get; set; }





    }
}