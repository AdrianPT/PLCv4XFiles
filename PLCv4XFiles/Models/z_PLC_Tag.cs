using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLCv4XFiles.Models
{
    public class z_PLC_Tag
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }


        public int Valor { get; set; }
        public bool Serie { get; set; }


        // FK device plc al que pertenece
        public int PLC_ContadorId { get; set; }

        // Para navegar
        public z_PLC_Device PLC_Contador { get; set; }


    }
}