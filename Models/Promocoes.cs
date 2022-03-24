using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Promocoes
    {
        [Key]
        public int promocoesId { get; set; }
        public string lugar { get; set; }
        public float valor { get; set; }
    }
}