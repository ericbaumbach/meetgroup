using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeetGroup.Business.Models
{
    public class Reserva : Entity
    {
        public Guid SalaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public Guid ReservadaPor { get; set; }
        
        [ForeignKey(nameof(SalaId))]
        public Sala Sala { get; set; }
    }
}
