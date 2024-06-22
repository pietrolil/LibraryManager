using FluentValidation;
using LibraryManager.Application.Commands.CreateBook;

namespace LibraryManager.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(p => p.PublicationYear)
                .GreaterThan(0)
                .WithMessage("Ano de publicação maior que 0.");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo de Título é de 30 caracteres");

            RuleFor(p => p.Author)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo de Autor é de 30 caracteres");
        }
    }
}
