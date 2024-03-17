using DGII_Taxpayers.Infrastructure.Options;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DGII_Taxpayers.Infrastructure.Validators;

public sealed class DatabaseOptionsValidator : IValidateOptions<DatabaseOptions>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DatabaseOptionsValidator(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public ValidateOptionsResult Validate(string? name, DatabaseOptions options)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        IValidator<DatabaseOptions> validator = scope.ServiceProvider.GetRequiredService<IValidator<DatabaseOptions>>();

        ValidationResult result = validator.Validate(options);

        if (result.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        var errors = result.Errors.Select(x => $"Validation failed to {x.PropertyName} with the Error Message {x.ErrorMessage}").ToList();

        return ValidateOptionsResult.Fail(errors);
    }
}