using System;

namespace Server.Exceptions
{
    /// <summary>
    /// Own exception class extends <see cref="System.Exception"/> to impelement user data model validation errors
    /// </summary>
    public class UserDataException : Exception
    {
        public UserDataException(string message, string inputData)
            : base($"{message}. {inputData} is incorrect") { }
    }
}