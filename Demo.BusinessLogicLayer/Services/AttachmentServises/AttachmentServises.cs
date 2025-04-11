using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.AttachmentServises
{
    public class AttachmentServises : IAttachmentServices
    {
        List<string> Extensions = [".jpg", ".png", ".jpeg"];
        const int MaxSize = 2_097_152; // 2MB
        public string? UploadFile(IFormFile file, string FolderName)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            // Check if the file extension is valid
            // Check if the file size is within the limit
            if (!Extensions.Contains(fileExtension) || file.Length == 0 || file.Length > MaxSize)
                return null;
            // Get Folder Path  
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", FolderName);
            // Check if the folder exists, if not create it
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            // Get the file name
            string fileName = $"{Guid.NewGuid()}_{file.FileName}";
            // Combine the folder path and file name
            string filePath = Path.Combine(folderPath, fileName);
            //save the file in the folder
            using var stream = new FileStream(filePath, FileMode.Create) ;
            // Copy the file to the stream
            file.CopyTo(stream);
            // return the file name to Store in Database
            return fileName;
        }
        public bool DeleteFile(string filePath)
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
