using ProjectsFileReaderApp.DTOs.Requests;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using ProjectsFileReaderApp.BusinessLayer.Interfaces;
using ProjectsFileReaderApp.BusinessLayer;
using ProjectsFileReaderApp.Services.Interfaces;
using ProjectsFileReaderApp.Services;

namespace ProjectsFileReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var seriviceProvider = BuildServices();
            seriviceProvider.GetService<IProjectFileService>().ProcessInputArguments(new ProcessInputArgumentsRequest { args = args });
        }

        public static IServiceProvider BuildServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IProjectFileService, ProjectFileService>();
            services.AddScoped<IParseInputArguments, ParseInputArguments>();
            services.AddScoped<IProcess, ProcessFile>();
            services.AddScoped<ISendInformation, SendInformationToConsole>();


            return services.BuildServiceProvider();
        }
    }
}
