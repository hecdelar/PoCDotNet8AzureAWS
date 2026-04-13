using AdminRequest.poc.WebAPI.ApplicationCore.Command;
using FluentValidation;

namespace AdminRequest.WebAPI.ApplicationCore.Command
{
    public class MessageCreateCommandValidator  : AbstractValidator<MessageCreateCommand>
    {
        public MessageCreateCommandValidator() {

            RuleFor(x => x.id)
                     .NotEmpty();

            RuleFor(x => x.name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.payload)
                .NotEmpty();

            RuleFor(x => x.status)
                .IsInEnum();

            RuleFor(x => x.createAt)
                .NotEqual(DateTime.MinValue);

        }
    }
}
