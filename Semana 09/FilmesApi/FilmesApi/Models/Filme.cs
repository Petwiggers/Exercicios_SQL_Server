using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Filme
    {  

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O cmapo Nome não pode exceder 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo Diretor é de preenchimentom obrigatório")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo Genero é de preenchimentom obrigatório")]
        public int Duracao { get; set; }


        public string Genero { get; set; }
    }
}
