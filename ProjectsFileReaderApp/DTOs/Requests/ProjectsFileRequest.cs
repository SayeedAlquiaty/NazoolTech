using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.DTOs.Requests
{
    public class ProjectsFileRequest : Request
    {
        /// <summary>
        /// Gets and sets FilePath
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets and sets IsSortByStartDate
        /// </summary>
        public bool IsSortByStartDate { get; set; }

        /// <summary>
        /// Gets and sets ProjectId
        /// </summary>
        public string ProjectId { get; set; }
    }
}
