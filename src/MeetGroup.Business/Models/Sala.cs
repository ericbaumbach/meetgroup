using System;
using System.Collections.Generic;
using System.Text;

namespace MeetGroup.Business.Models
{
    public class Sala : Entity
    {
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public bool PossuiComputador { get; set; }
        public bool PossuiAcessoAInternet { get; set; }
        public bool PossuiTV { get; set; }
        public bool PossuiWebCam { get; set; }   
        public bool Ativo { get; set; }
    }
}
