using System;
using System.Linq;
using System.Threading.Tasks;
using MeetGroup.Business.Intefaces;
using MeetGroup.Business.Models;
using MeetGroup.Business.Models.Validations;

namespace MeetGroup.Business.Services
{
    public class ReservaService : BaseService, IReservaService
    {
        private readonly IReservaRepository _ReservaRepository;

        public ReservaService(IReservaRepository ReservaRepository, INotificador notificador) : base(notificador)
        {
            _ReservaRepository = ReservaRepository;
        }

        public async Task<bool> Adicionar(Reserva Reserva)
        {
            if (!ExecutarValidacao(new ReservaValidation(), Reserva)) return false;

            await _ReservaRepository.Adicionar(Reserva);
            
            return true;
        }

        public async Task<bool> Atualizar(Reserva Reserva)
        {
            if (!ExecutarValidacao(new ReservaValidation(), Reserva)) return false;

            await _ReservaRepository.Atualizar(Reserva);
            
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _ReservaRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _ReservaRepository?.Dispose();
        }
    }
}