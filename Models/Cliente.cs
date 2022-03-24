using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }

        public string nascimento { get; set; }

        public string telefone { get; set; }
        public string situacao { get; set; }
    }
}