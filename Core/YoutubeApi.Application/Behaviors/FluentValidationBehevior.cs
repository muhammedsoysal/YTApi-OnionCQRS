using FluentValidation;
using MediatR;

namespace YoutubeApi.Application.Behaviors;

public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validator;

    public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
    {
        _validator = validator;
    }
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validator.Select(x => x.Validate(context))
            .SelectMany(result => result.Errors)
            .GroupBy(g => g.ErrorMessage)
            .Select(f => f.First())
            .Where(w => w != null)
            .ToList();
        if (failures.Any())
            throw new ValidationException(failures);
        return next();
    }
}