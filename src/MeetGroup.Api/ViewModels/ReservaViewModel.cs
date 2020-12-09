using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetGroup.Api.ViewModels
{
    public class ReservaViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string ReservadaPor { get; set; }
       
    }
}