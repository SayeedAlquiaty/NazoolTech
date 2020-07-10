using ProjectsFileReaderApp.DTOs.Requests;
using ProjectsFileReaderApp.DTOs.Responses;
using ProjectsFileReaderApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.BusinessLayer.Interfaces
{
    public interface IParseInputArguments
    {
        GetParsedInputDataResponse GetParsedInputData(Request request);

    }
}
