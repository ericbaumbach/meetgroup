using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MeetGroup.Api.Controllers;
using MeetGroup.Api.Extensions;
using MeetGroup.Api.ViewModels;
using MeetGroup.Business.Intefaces;
using MeetGroup.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetGroup.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/reservas")]
    public class ReservasController : MainController
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly ISalaService _salaService;
        private readonly IReservaService _reservaService;
        private readonly IMapper _mapper;

        public ReservasController(ISalaRepository salaRepository, IReservaRepository reservaRepository, IMapper mapper, ISalaService salaService, IReservaService reservaService, INotificador notificador, IUser user) : base(notificador, user)
        {
            _salaRepository = salaRepository;
            _reservaRepository = reservaRepository;
            _mapper = mapper;
            _salaService = salaService;
            _reservaService = reservaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterPorFiltros(BuscarSalasDisponiveisViewModel buscarSalasDisponiveisViewModel)
        {
            try
            {
                var dataInicio = Convert.ToDateTime(buscarSalasDisponiveisViewModel.DataInicio);
                var dataFim = Convert.ToDateTime(buscarSalasDisponiveisViewModel.DataFim);
                var horaInicio = TimeSpan.Parse(buscarSalasDisponiveisViewModel.HoraInicio);
                var horaFim = TimeSpan.Parse(buscarSalasDisponiveisViewModel.HoraFim);

                var salas = _mapper.Map<IEnumerable<SalaViewModel>>(await _reservaService.BuscarSalasDisponiveis(dataInicio, dataFim, horaInicio, horaFim));

                return CustomResponse(salas);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }
        }
    }
}