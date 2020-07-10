using ProjectsFileReaderApp.DTOs.Requests;
using ProjectsFileReaderApp.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.BusinessLayer.Interfaces
{
    public interface IProcess
    {
        GenerateObjectsResponse GenerateObjects(Request request);
    }
}
