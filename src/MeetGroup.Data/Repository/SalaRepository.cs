using System;
using System.Threading.Tasks;
using MeetGroup.Business.Intefaces;
using MeetGroup.Business.Models;
using MeetGroup.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MeetGroup.Data.Repository
{
    public class SalaRepository : Repository<Sala>, ISalaRepository
    {
        public SalaRepository(MeetGroupDbContext context) : base(context)
        {
        }
    }
}