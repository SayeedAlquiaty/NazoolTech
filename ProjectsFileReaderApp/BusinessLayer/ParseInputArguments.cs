using ProjectsFileReaderApp.BusinessLayer.Interfaces;
using ProjectsFileReaderApp.Constants;
using ProjectsFileReaderApp.DTOs.Requests;
using ProjectsFileReaderApp.DTOs.Responses;
using ProjectsFileReaderApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectsFileReaderApp.BusinessLayer
{
    public class ParseInputArguments : IParseInputArguments
    {
        public GetParsedInputDataResponse GetParsedInputData(Request request)
        {
            var response = new GetParsedInputDataResponse();
            var processInputArgumentsRequest = request as ProcessInputArgumentsRequest;

            if (processInputArgumentsRequest == null)
            {
                response.AddErrorMessage(string.Format("{0}: request type should be {1}", ErrorStatus.InvalidRequest, nameof(ProcessInputArgumentsRequest)));
                return response;
            }

            var args = processInputArgumentsRequest.args;
            int index = 0;
            var input = new CommandLineInput();

            if (args.Count() < 2)
            {
                response.AddErrorMessage(string.Format("{0}: Please provide valid command line arguments", ErrorStatus.InvalidArgument) +
                    "\n--file <path>             full path to the input file" +
                    "\n--sortByStartDate         sort results by column \"Start date\" in ascending order" +
                    "\n--project <project id>    filter results by column \"Project\"");
                return response;
            }

            if (!args.Contains(Options.File))
            {
                response.AddErrorMessage(string.Format("{0}: --file <path> is mandatory", ErrorStatus.InvalidCommand));
                return response;
            }

            foreach(var arg in args)
            {
                if(arg == Options.File)
                {
                    input.FilePath = args[index + 1];
                }
                if (arg == Options.SortedByDate)
                {
                    input.IsSortByStartDate = true;
                }
                if (arg == Options.Project)
                {
                    input.ProjectId = args[index + 1];
                }
                index += 1;
            }

            response.Data = input;
            return response;
        }

    }
}
