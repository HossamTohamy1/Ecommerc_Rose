// Application/Common/Behaviours/ValidationBehaviour.cs
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours
{
    /// <summary>
    /// MediatR pipeline behavior that runs all registered FluentValidation validators
    /// before the request reaches its handler.
    /// Throws <see cref="ValidationException"/> (FluentValidation's own) when any
    /// rule fails, which your global exception handler should translate to 400.
    /// </summary>
    public sealed class ValidationBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            // Run all validators in parallel
            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f is not null)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return await next();
        }
    }
}