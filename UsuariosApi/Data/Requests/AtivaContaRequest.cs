using System;
using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required] //Para identificar o usuario que vai ser ativado.
        public int UsuarioId { get; set; }

        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
}
