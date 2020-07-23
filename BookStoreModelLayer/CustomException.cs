using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer
{
    public class CustomException : Exception
    {
        /// <summary>
        /// This is enum constant exception
        /// </summary>
        public enum ExceptionType
        {
            INVALID_INPUT, OPTIONS_NOT_MATCH, NULL_EXCEPTION
        }
        public ExceptionType type;

        /// <summary>
        /// Parameterized constructors
        /// </summary>
        /// <param name="type"></param>
        public CustomException(ExceptionType type)
        {
            this.type = type;
        }

        /// <summary>
        /// Exception method
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public CustomException(ExceptionType type, String message) : base(message)
        {
            this.type = type;
        }
    }
}
