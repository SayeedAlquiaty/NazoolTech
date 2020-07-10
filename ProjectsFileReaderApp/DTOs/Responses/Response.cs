using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectsFileReaderApp.DTOs.Responses
{
    /// <summary>
    /// Response class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : ResponseBase
    {
        /// <summary>
        /// Gets and sets Data
        /// </summary>
        public T Data { get; set; }
    }

    /// <summary>
    /// ResponseBase class
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Constructor of Responsebase class, which initializes the Errors list.
        /// </summary>
        public ResponseBase()
        {
            this.Errors = new List<ValidationResult>();
        }

        /// <summary>
        /// Gets and sets Errors
        /// </summary>
        public IList<ValidationResult> Errors { get; set; }

        /// <summary>
        /// Gets Success
        /// </summary>
        public bool Success => Errors == null || !Errors.Any();

        /// <summary>
        /// Following method updates Errors collection
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void AddErrorMessage(string errorMessage)
        {
            this.Errors.Add(new ValidationResult(errorMessage));
        }
    }
}
