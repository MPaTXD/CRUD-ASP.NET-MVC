using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Musico
    {

        public int MusicoId { get; set; }

        [Display(Name = "Nome")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nome com no minimo 2 Caracteres")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Formato Inválido")]
        public string NomeMusico { get; set; }

        [Required(ErrorMessage = "Idade Obrigatória")]
        [Display(Name = "Idade")]
        [Range(18, 100, ErrorMessage = "Idade menor que 18")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "E-mail Obrigatório")]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*", ErrorMessage = "E-mail Inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 4, ErrorMessage = "A senha deve ter no minimo 4 Caracteres")]
        [Required(ErrorMessage = "Senha Obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Categoria obrigatória")]
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }

        public virtual ICollection<MusicoBanda> musicobanda { get; set; }
    }
}