using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Infrastructure.Services;

public abstract class BaseService
{
	public List<ProblemResponse> ModelValidator(ModelStateDictionary model)
	{
		List<ProblemResponse> errors = new();

		foreach (var item in model.Where(v => v.Value.ValidationState == ModelValidationState.Invalid))
		{
			ProblemResponse extentison = new();
			extentison.Name = item.Key;

			foreach (var subItem in item.Value.Errors)
			{
				extentison.Reasons.Add(subItem.ErrorMessage);
			}

			errors.Add(extentison);
		}

		return errors;
	}

	public ProblemDetails ModelValidationProblem(ModelStateDictionary model, string detail)
	{
		var problemdetails = new ProblemDetails()
		{
			Title = "Doğrulama hatası!",
			Status = 400,
			Instance = null,
			Detail = detail,
			Type = "https://example.com/validation-error"
		};

		problemdetails.Extensions.Add("invalidParams", ModelValidator(model));

		return problemdetails;
	}
}
