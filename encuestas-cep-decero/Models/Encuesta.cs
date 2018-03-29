using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace encuestas_cep_decero.Models
{
    public class Encuesta
    {
        public int EncuestaID { get; set;}
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int Dni_Libreta { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "El domicilio debe de tener de 3 a 50 caracteres")]
        public string Domicilio { get; set; }
        [Required]
        public string Localidad { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email {get; set; }
        [Required]
        public string Pregunta_Aumento_Transporte { get; set; }
        [Required]
        public string Pregunta_Boleto_Edu { get; set; }
        [Required]
        public string Pregunta_Beca_Transporte { get; set; }
        [Required]
        public string Pregunta_Politica_Permanencia { get; set; }
        [Required]
        public string Pregunta_Politica_Iniciativas { get; set; }
        [Required]
        [StringLength(256)]
        public string Pregunta_Comentarios { get; set; }
        public Boolean Estado { get; set; } = false;
    }
}
