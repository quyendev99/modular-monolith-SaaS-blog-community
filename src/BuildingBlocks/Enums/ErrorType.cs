namespace BuildingBlocks.Enums;

public enum ErrorType
{
   Validation,
   Conflict,
   NotFound,
   Unauthorized,
   Forbidden,
   BadRequest,
   TenantViolation,
   Unexpected,
   IntegrationFailure,
   PersistenceFailure,
   DomainRuleViolation,
   ServiceUnavailable,
   BusinessRule,
   InvariantViolation,
   PreconditionsNotMet
}