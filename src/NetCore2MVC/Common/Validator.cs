using FluentValidation;
using System.Linq;
using KJT.WebFrameWork.Common;

namespace NetCore2MVC.Common
{
    public class Validator
    {
        public static void Validate<ValidateT, RequestT>(RequestT model) where ValidateT : AbstractValidator<RequestT>, new()
        {
            var instance = new ValidateT();
            var result = instance.Validate(model);
            if (!result.IsValid)
                throw new BusinessError(result.Errors.FirstOrDefault().ErrorMessage);
        }
    }
}
