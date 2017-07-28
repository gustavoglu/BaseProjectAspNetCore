using BaseProjectANC.Domain.Models.EntitySample.Commands;
using FluentValidation;
using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Validations
{
    public abstract class EntitySampleValidation : AbstractValidator<BaseEntitySampleCommand>
    {
        public void ValidaDescricao()
        {
            RuleFor(e => e.Descricao)
                .NotEmpty().WithMessage("Obrigatório informar a Descrição");
        }

        public void ValidaId()
        {
            RuleFor(e => e.Id)
                .NotEqual(Guid.Empty).WithMessage("O Id precisa ser informado")
                .NotEmpty().WithMessage("O Id precisa ser informado")
                .NotNull().WithMessage("O Id precisa ser informado");
        }
    }
}
