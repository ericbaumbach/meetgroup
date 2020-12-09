using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetGroup.Business.Intefaces;
using MeetGroup.Business.Models;
using MeetGroup.Business.Models.Validations;

namespace MeetGroup.Business.Services
{
    public class ReservaService : BaseService, IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ISalaRepository _salaRepository;

        public ReservaService(IReservaRepository reservaRepository, ISalaRepository salaRepository, INotificador notificador) : base(notificador)
        {
            _reservaRepository = reservaRepository;
            _salaRepository = salaRepository;
        }

        public async Task<bool> Adicionar(Reserva Reserva)
        {
            if (!ExecutarValidacao(new ReservaValidation(), Reserva)) return false;

            await _reservaRepository.Adicionar(Reserva);
            
            return true;
        }

        public async Task<bool> Atualizar(Reserva Reserva)
        {
            if (!ExecutarValidacao(new ReservaValidation(), Reserva)) return false;

            await _reservaRepository.Atualizar(Reserva);
            
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _reservaRepository.Remover(id);

            return true;
        }

        public async Task<IEnumerable<Sala>> BuscarSalasDisponiveis(DateTime dataInicio, DateTime dataFim, TimeSpan horaInicio, TimeSpan horaFim)
        {
            var salasDisponiveis = new List<Sala>();

            try
            {
                var salasReservadas = _reservaRepository
                                                    .Buscar(x => x.DataInicio == dataInicio && x.DataFim == dataFim && x.HoraInicio == horaInicio && x.HoraFim == horaFim).Result
                                                    .Select(x => x.SalaId)
                                                    .ToArray();

                salasDisponiveis = _salaRepository.Buscar(x => !salasReservadas.Contains(x.Id)).Result.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return salasDisponiveis;
        }

        public void Dispose()
        {
            _reservaRepository?.Dispose();
        }
    }
}