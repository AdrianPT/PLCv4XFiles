using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLCv4XFiles.Models
{
    public class z_PLC_Device
    {

        public int Id { get; set; }


        [Required]
        public string Nome { get; set; }

        public string Modelo { get; set; }
        public string EnderecoFisico { get; set; }
        public string IP { get; set; }
        

    }
}