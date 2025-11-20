namespace BuildingBlocks.Core.Results;

public class Result(bool isSuccess, Error? error)
{
   private bool IsSuccess { get; } = isSuccess;
   public bool IsFailure => !IsSuccess;
   public Error? Error { get; } = error;

   public static Result Success() => new Result(true, null);
   private static Result Failure(Error? error) => new(false, error);

   public static implicit operator Result(Error error) => Failure(error);
}

public sealed class Result<T> : Result
{
   public T? Value { get; }
   private Result(T value) : base(true, null) => Value = value;
   private Result(Error error) : base(false, error) => Value = default;


   private static Result<T> Success(T value) => new(value);
   private static Result<T> Failure(Error error) => new(error);

   public static implicit operator Result<T>(T value) => Success(value);
   public static implicit operator Result<T>(Error error) => Failure(error);
}