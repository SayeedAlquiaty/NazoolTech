using ProjectsFileReaderApp.BusinessLayer.Interfaces;
using ProjectsFileReaderApp.Constants;
using ProjectsFileReaderApp.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.BusinessLayer
{
    public class SendInformationToConsole : ISendInformation
    {
        public void SendData(Request request)
        {
            var sendProjectDataRequest = request as SendProjectDataRequest;

            if (sendProjectDataRequest == null)
            {
                Console.WriteLine("Invalid Request: request type should be {0}", nameof(SendProjectDataRequest));
            }

            Console.WriteLine("/***********************************************************************************************************************************************/");
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t", 
            Header.Project, Header.Description, Header.StartDate, Header.Category, Header.Responsible, Header.SavingsAmount, Header.Currency, Header.Complexity);
            foreach(var pq in sendProjectDataRequest.ProjectQuantityList)
            {
                for(int i = 0; i < pq.Count; i++)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t",
            pq.Project.Id, pq.Project.Description, pq.Project.StartDate, pq.Project.Category, pq.Project.Responsible, pq.Project.SavingsAmount, pq.Project.Currency, pq.Project.Complexity);
                }
                
            }
            Console.WriteLine("/***********************************************************************************************************************************************/");
        }

        public void SendErrorMessage(Request request)
        {
            var sendErrorRequest = request as SendErrorRequest;

            if (sendErrorRequest == null)
            {
                Console.WriteLine("Invalid Request: request type should be {0}", nameof(SendErrorRequest));
            }

            Console.WriteLine("********* Error! *********");
            foreach(var error in sendErrorRequest.Errors)
            {
                Console.WriteLine("{0}", error);
            }
        }
    }
}
