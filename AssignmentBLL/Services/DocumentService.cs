using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.Services
{
    public class DocumentService : IDocumentService
    {
        private List<String?> _allowedExtensions = new List<String?> { ".jpg", ".jpeg", ".png" };
        private const int MAXSIZE = 2 * 1024 * 1024; // 2 MB


        public async Task<string?> UploadAsync(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);
            if(!_allowedExtensions.Contains(extension.ToLower()))
                throw null;
            if(file.Length > MAXSIZE)
                throw null;
            var fileName = $"{Guid.NewGuid()}{extension}";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","Data", folderName);
            var filePath = Path.Combine(folderPath, fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return fileName;
        }

        public bool Delete(string fileName , string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", folderName , fileName);
            if (!File.Exists(filePath))
                return false;
            File.Delete(filePath);
            return true;
            
        }
    }
}
