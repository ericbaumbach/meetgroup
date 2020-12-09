using System.Collections.Generic;
using MeetGroup.Business.Notificacoes;

namespace MeetGroup.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}