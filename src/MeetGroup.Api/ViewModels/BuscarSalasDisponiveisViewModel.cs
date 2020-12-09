using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetGroup.Api.ViewModels
{
    public class BuscarSalasDisponiveisViewModel
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public int? Capacidade { get; set; }
        public bool? PossuiComputador { get; set; }
        public bool? PossuiAcessoAInternet { get; set; }
        public bool? PossuiTV { get; set; }
        public bool? PossuiWebCam { get; set; }
    }
}
