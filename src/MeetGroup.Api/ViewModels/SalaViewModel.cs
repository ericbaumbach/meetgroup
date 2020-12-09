using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetGroup.Api.ViewModels
{
    public class SalaViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }
        
        [Min(1, ErrorMessage = "O campo {0} precisa ter pelo menos 1 lugar")]
        public int Capacidade { get; set; }
        
        public bool PossuiComputador { get; set; }
        
        public bool PossuiAcessoAInternet { get; set; }
        
        public bool PossuiTV { get; set; }
        
        
        public bool PossuiWebCam { get; set; }
        
        public bool Ativo { get; set; }
    }
}