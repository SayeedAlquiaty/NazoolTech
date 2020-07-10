using ProjectsFileReaderApp.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.Services.Interfaces
{
    public interface IProjectFileService
    {
        void ProcessInputArguments(Request request);
    }
}
