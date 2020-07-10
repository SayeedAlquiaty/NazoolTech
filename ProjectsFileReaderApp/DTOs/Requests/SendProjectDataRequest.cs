using ProjectsFileReaderApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.DTOs.Requests
{
    public class SendProjectDataRequest : Request
    {
        public List<ProjectQuantity> ProjectQuantityList { get; set; }
    }
}
