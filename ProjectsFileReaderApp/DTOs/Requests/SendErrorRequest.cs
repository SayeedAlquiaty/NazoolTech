using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectsFileReaderApp.DTOs.Requests
{
    public class SendErrorRequest : Request
    {
        public IList<ValidationResult> Errors { get; set; }
    }
}
