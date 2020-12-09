using System;
using System.Linq;
using System.Threading.Tasks;
using MeetGroup.Business.Intefaces;
using MeetGroup.Business.Models;
using MeetGroup.Business.Models.Validations;

namespace MeetGroup.Business.Services
{
    public class SalaService : BaseService, ISalaService
    {
        private readonly ISalaRepository _SalaRepository;

        public SalaService(ISalaRepository SalaRepository, INotificador notificador) : base(notificador)
        {
            _SalaRepository = SalaRepository;
        }

        public async Task<bool> Adicionar(Sala Sala)
        {
            if (!ExecutarValidacao(new SalaValidation(), Sala)) return false;

            if (_SalaRepository.Buscar(f => f.Nome == Sala.Nome).Result.Any())
            {
                Notificar("Já existe uma sala com este nome infomado.");
                return false;
            }

            await _SalaRepository.Adicionar(Sala);
            
            return true;
        }

        public async Task<bool> Atualizar(Sala Sala)
        {
            if (!ExecutarValidacao(new SalaValidation(), Sala)) return false;

            if (_SalaRepository.Buscar(f => f.Nome == Sala.Nome && f.Id != Sala.Id).Result.Any())
            {
                Notificar("Já existe uma sala com este nome infomado.");
                return false;
            }

            await _SalaRepository.Atualizar(Sala);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _SalaRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _SalaRepository?.Dispose();
        }
    }
}