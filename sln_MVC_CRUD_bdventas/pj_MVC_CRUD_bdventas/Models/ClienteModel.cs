using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pj_MVC_CRUD_bdventas.Models
{
    public class ClienteModel
    {
        public int cod_cli { get; set; }
        public string nom_cli { get; set; }
        public string tel_cli { get; set; } // celular
        public string cor_cli { get; set; }

        public string dir_cli { get; set; }
        public int cred_cli { get; set; }

        public DateTime fec_nac { get; set; }

        public int cod_dist { get; set; }
        public string eli_cli { get; set; }
    }
}