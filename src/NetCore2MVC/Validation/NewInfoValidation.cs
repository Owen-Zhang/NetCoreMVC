using FluentValidation;
using KJT.Model;

namespace NetCore2MVC.Validation
{
    public class NewInfoValidation : AbstractValidator<NewInfo>
    {
        public NewInfoValidation()
        {
            RuleFor(item => item.Title).NotEmpty().WithMessage("Title must input");
        }
    }
}
