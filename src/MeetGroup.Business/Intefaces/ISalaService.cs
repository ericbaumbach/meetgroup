using System;
using System.Threading.Tasks;
using MeetGroup.Business.Models;

namespace MeetGroup.Business.Intefaces
{
    public interface ISalaService : IDisposable
    {
        Task<bool> Adicionar(Sala Sala);
        Task<bool> Atualizar(Sala Sala);
        Task<bool> Remover(Guid id);
    }
}