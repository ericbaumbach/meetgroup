using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeetGroup.Business.Models;

namespace MeetGroup.Business.Intefaces
{
    public interface IReservaService : IDisposable
    {
        Task<bool> Adicionar(Reserva Reserva);
        Task<bool> Atualizar(Reserva Reserva);
        Task<bool> Remover(Guid id);
        Task<IEnumerable<Sala>> BuscarSalasDisponiveis(DateTime dataInicio, DateTime dataFim, TimeSpan horaInicio, TimeSpan horaFim);
    }
}