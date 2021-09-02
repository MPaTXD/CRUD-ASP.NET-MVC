using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Banda
    {
        public int BandaId { get; set; }

        [Display(Name = "Nome da Banda")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nome com no minimo 2 Caracteres")]
        [Required(ErrorMessage = "Nome da Banda Obrigatório")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Formato Inválido")]
        public string NomeBanda { get; set; }


        [Display(Name = "Estilo Musical")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Estilo com no minimo 2 Caracteres")]
        [Required(ErrorMessage = "Estilo Musical Obrigatório")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Formato Inválido")]
        public string EstiloBanda { get; set; }

        public int IntegrantesBanda { get; set; }

        public virtual ICollection<MusicoBanda> musicobanda { get; set; }

        public Banda()
        {
            IntegrantesBanda = 0;
        }
    }
}