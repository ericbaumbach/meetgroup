using System;
using System.Threading.Tasks;
using MeetGroup.Business.Intefaces;
using MeetGroup.Business.Models;
using MeetGroup.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MeetGroup.Data.Repository
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        public ReservaRepository(MeetGroupDbContext context) : base(context)
        {
        }
    }
}