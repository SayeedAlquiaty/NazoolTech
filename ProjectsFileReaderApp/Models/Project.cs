using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.Models
{
    public class Project
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public string Category { get; set; }

        public string Responsible { get; set; }

        public string SavingsAmount { get; set; }

        public string Currency { get; set; }

        public string Complexity { get; set; }
    }
}
