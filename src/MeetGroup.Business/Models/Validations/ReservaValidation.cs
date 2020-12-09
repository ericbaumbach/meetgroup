using FluentValidation;

namespace MeetGroup.Business.Models.Validations
{
    public class ReservaValidation : AbstractValidator<Reserva>
    {
        public ReservaValidation()
        {
            //RuleFor(f => f.Nome)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 100)
            //    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            //RuleFor(f => f.Capacidade)
            //    .GreaterThan(0)
            //    .WithMessage("O campo {PropertyName} precisa ter pelo menos 1 lugar");
        }
    }
}