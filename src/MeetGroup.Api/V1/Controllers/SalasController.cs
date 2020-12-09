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
    [Route("api/v{version:apiVersion}/salas")]
    public class SalasController : MainController
    {
        private readonly ISalaRepository _salaRepository;
        private readonly ISalaService _salaService;
        private readonly IMapper _mapper;

        public SalasController(ISalaRepository salaRepository,
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
        public async Task<IEnumerable<SalaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<SalaViewModel>>(await _salaRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SalaViewModel>> ObterPorId(Guid id)
        {
            var sala = _mapper.Map<SalaViewModel>(await _salaRepository.ObterPorId(id));

            if (sala == null) return NotFound();

            return sala;
        }

        [ClaimsAuthorize("Sala", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<SalaViewModel>> Adicionar(SalaViewModel salaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _salaService.Adicionar(_mapper.Map<Sala>(salaViewModel));

            return CustomResponse(salaViewModel);
        }

        [ClaimsAuthorize("Sala", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SalaViewModel>> Atualizar(Guid id, SalaViewModel SalaViewModel)
        {
            if (id != SalaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado por parâmetro");
                return CustomResponse(SalaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _salaService.Atualizar(_mapper.Map<Sala>(SalaViewModel));

            return CustomResponse(SalaViewModel);
        }

        [ClaimsAuthorize("Sala", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SalaViewModel>> Excluir(Guid id)
        {
            var sala = await _salaRepository.ObterPorId(id);

            if (sala == null) return NotFound();

            await _salaService.Remover(id);

            return CustomResponse(sala);
        }


    }
}