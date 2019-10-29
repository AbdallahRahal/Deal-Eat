using System;

namespace ITI.PrimarySchool.DAL
{
    public class Result<T>
    {
        readonly string _errorMessage;
        readonly T _value;

        internal Result(string errorMessage, T value)
        {
            _errorMessage = errorMessage;
            _value = value;
        }

        public bool IsSuccess => _errorMessage == null;

        public string ErrorMessage
        {
            get
            {
                if (IsSuccess) throw new InvalidOperationException("The result contains no error.");
                return _errorMessage;
            }
        }

        public T Value
        {
            get
            {
                if (!IsSuccess) throw new InvalidOperationException("The result has an error.");
                return _value;
            }
        }
    }

    public static class Result
    {
        public static Result<T> CreateSuccess<T>(T value)
        {
            return new Result<T>(null, value);
        }

        public static Result<T> CreateError<T>(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage)) throw new ArgumentException("The error message must be not null nor whitespace.", nameof(errorMessage));
            return new Result<T>(errorMessage, default);
        }
    }
}
