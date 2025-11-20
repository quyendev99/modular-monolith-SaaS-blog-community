using BuildingBlocks.Enums;

namespace BuildingBlocks.Core.Results;

public record struct Error(
   string Code,
   ErrorType Type,
   string Message,
   string? Description,
   int StatusCode)
{
   public static Error Validation(string code, string message, string? description = null) =>
      new(code, ErrorType.Validation, message, description, 400);

   public static Error Conflict(string code, string message, string? description = null) =>
      new(code, ErrorType.Conflict, message, description, 409);

   public static Error NotFound(string code, string message, string? description = null) =>
      new(code, ErrorType.NotFound, message, description, 404);

   public static Error Unauthorized(string code, string message, string? description = null) =>
      new(code, ErrorType.Unauthorized, message, description, 401);

   public static Error Forbidden(string code, string message, string? description = null) =>
      new(code, ErrorType.Forbidden, message, description, 403);

   public static Error BadRequest(string code, string message, string? description = null) =>
      new(code, ErrorType.BadRequest, message, description, 400);

   public static Error TenantViolation(string code, string message, string? description = null) =>
      new(code, ErrorType.TenantViolation, message, description, 403);

   public static Error Unexpected(string code, string message, string? description = null) =>
      new(code, ErrorType.Unexpected, message, description, 500);

   public static Error IntegrationFailure(string code, string message, string? description = null) =>
      new(code, ErrorType.IntegrationFailure, message, description, 500);

   public static Error PersistenceFailure(string code, string message, string? description = null) =>
      new(code, ErrorType.PersistenceFailure, message, description, 500);

   public static Error DomainRuleViolation(string code, string message, string? description = null) =>
      new(code, ErrorType.DomainRuleViolation, message, description, 409);

   public static Error ServiceUnavailable(string code, string message, string? description = null) =>
      new(code, ErrorType.ServiceUnavailable, message, description, 503);

   public static Error BusinessRule(string code, string message, string? description = null) =>
      new(code, ErrorType.BusinessRule, message, description, 409);

   public static Error InvariantViolation(string code, string message, string? description = null) =>
      new(code, ErrorType.InvariantViolation, message, description, 409);

   public static Error PreconditionsNotMet(string code, string message, string? description = null) =>
      new(code, ErrorType.PreconditionsNotMet, message, description, 409);
}