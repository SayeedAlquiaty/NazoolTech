using ProjectsFileReaderApp.BusinessLayer.Interfaces;
using ProjectsFileReaderApp.DTOs.Requests;
using ProjectsFileReaderApp.Models;
using ProjectsFileReaderApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.Services
{
    public class ProjectFileService : IProjectFileService
    {
        private readonly IParseInputArguments parseInputArguments;
        private readonly IProcess process;
        private readonly ISendInformation sendInformation;

        public ProjectFileService(IParseInputArguments parseInputArguments, IProcess process, ISendInformation sendInformation)
        {
            this.parseInputArguments = parseInputArguments;
            this.process = process;
            this.sendInformation = sendInformation;
        }

        public void ProcessInputArguments(Request request)
        {
            var getParsedInputDataResponse = this.parseInputArguments.GetParsedInputData(request);

            if (getParsedInputDataResponse.Success)
            {
                var generateObjectsResponse = this.process.GenerateObjects(new ProjectsFileRequest
                {
                    FilePath = getParsedInputDataResponse.Data.FilePath,
                    IsSortByStartDate = getParsedInputDataResponse.Data.IsSortByStartDate,
                    ProjectId = getParsedInputDataResponse.Data.ProjectId
                });
                if (generateObjectsResponse.Success)
                {
                    this.sendInformation.SendData(new SendProjectDataRequest
                    {
                        ProjectQuantityList = generateObjectsResponse.Data
                    });
                }
                else
                {
                    this.sendInformation.SendErrorMessage(new SendErrorRequest
                    {
                        Errors = generateObjectsResponse.Errors
                    });
                }
            }
            else
            {
                this.sendInformation.SendErrorMessage(new SendErrorRequest
                {
                    Errors = getParsedInputDataResponse.Errors
                });
            }
        }
    }
}
