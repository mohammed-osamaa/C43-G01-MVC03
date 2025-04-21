using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.AttachmentServises
{
    public interface IAttachmentServices
    {
        public string? UploadFile(IFormFile fileName, string FolderName);
        public bool DeleteFile(string filePath);
    }
}
