using ProjectsFileReaderApp.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsFileReaderApp.BusinessLayer.Interfaces
{
    public interface ISendInformation
    {
        void SendErrorMessage(Request request);

        void SendData(Request request);
    }
}
