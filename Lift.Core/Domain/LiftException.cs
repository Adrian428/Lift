using System;

namespace Lift.Core.Domain
{
    public abstract class LiftException : Exception
    {
        public string Code { get; }

        protected LiftException()
        {
        }

        protected LiftException(string code)
        {
            Code = code;
        }

        protected LiftException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected LiftException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected LiftException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected LiftException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }

        public LiftException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // public LiftException(string message) : base(message)
        // {
        // }
    }
}