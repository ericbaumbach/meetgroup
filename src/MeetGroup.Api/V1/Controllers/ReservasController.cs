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
        private readonly ISalaService _salaService;
        private readonly IMapper _mapper;

        public ReservasController(ISalaRepository salaRepository,
                                      IMapper mapper,
                                      ISalaService salaService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _salaRepository = salaRepository;
            _mapper = mapper;
            _salaService = salaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterPorFiltros(BuscarSalasDisponiveisViewModel buscarSalasDisponiveisViewModel)
        {
            try
            {
                var salas = _mapper.Map<IEnumerable<SalaViewModel>>(await _salaRepository.Buscar(x => x.Capacidade >= buscarSalasDisponiveisViewModel.Capacidade || !buscarSalasDisponiveisViewModel.Capacidade.HasValue));

                return CustomResponse(salas);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }
        }
    }
}