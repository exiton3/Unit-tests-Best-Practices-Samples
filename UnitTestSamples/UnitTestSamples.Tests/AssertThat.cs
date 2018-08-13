using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSamples.Tests
{
   public class AssertThat
    {
        public static void Throws<TException>(Action action, Action<TException> exceptionValidator = null) where TException : Exception
        {
            TException exceptionThrown = null;
            try
            {
                action();
            }
            catch (Exception exception)
            {
                if (exception.GetType() != typeof(TException)) throw;
                exceptionThrown = (TException)exception;
            }

            if (exceptionThrown == null)
            {
                throw new AssertFailedException($"An exception of type {typeof(TException)} was expected, but not thrown");
            }
            exceptionValidator?.Invoke(exceptionThrown);
        }

        public static async Task ThrowsAsync<TException>(Func<Task> action, Action<TException> exceptionValidator = null) where TException : Exception
        {
            TException exceptionThrown = null;
            try
            {
                await action();
            }
            catch (Exception exception)
            {
                if (exception.GetType() != typeof(TException)) throw;
                exceptionThrown = (TException)exception;
            }

            if (exceptionThrown == null)
            {
                throw new AssertFailedException($"An exception of type {typeof(TException)} was expected, but not thrown");
            }
            exceptionValidator?.Invoke(exceptionThrown);
        }

        public static void Throws<TException>(Action action, string exceptionMessage) where TException : Exception
        {
            Throws<TException>(action, ex =>
            {
                if (exceptionMessage != ex.Message)
                {
                    throw new AssertFailedException($"Invalid exception message.\nExpected:\"{exceptionMessage}\";\nActual:\"{ex.Message}\".");
                }
            });
        }

        public static void Throws<TException>(Action action, Exception innerException) where TException : Exception
        {
            Throws<TException>(action, ex =>
            {
                if (!innerException.Equals(ex.InnerException))
                {
                    throw new AssertFailedException("The inner exception of thrown exception is not equal expected exception.");
                }
            });
        }
    }
}