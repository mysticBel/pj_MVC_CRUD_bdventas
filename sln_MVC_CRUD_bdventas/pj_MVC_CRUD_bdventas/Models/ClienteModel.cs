using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pj_MVC_CRUD_bdventas.Models
{
    public class ClienteModel
    {
        [Required]
        [RegularExpression(pattern: "C[0-9]{4}",
            ErrorMessage = "Debe iniciar con letra 'C' seguido de 4 numeros")]
        public string cod_cli { get; set; }

        [Required]
        [RegularExpression("[A-Za-z ]*",
            ErrorMessage = "Solo letras y espacio en blanco")]
        public string nom_cli { get; set; }

        [RegularExpression("9[13579][0-9]{7}",
            ErrorMessage = "Deben ser 9 numeros, Inicia con '9', luego un impar")]
        public string tel_cli { get; set; } // celular

        [Required]
        [DataType(DataType.EmailAddress)]
        public string cor_cli { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string dir_cli { get; set; }

        [Range(1000, 10000)] //exclusivo numeros
        public int cred_cli { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fec_nac { get; set; }


        [Required]
        public int cod_dist { get; set; }

        public string eli_cli { get; set; }
    }
}