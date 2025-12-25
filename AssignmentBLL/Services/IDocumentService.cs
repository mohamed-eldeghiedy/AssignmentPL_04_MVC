using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.Services
{
    public interface IDocumentService
    {
        Task<string?> UploadAsync(IFormFile file, string folderName);
        bool Delete(string fileName , string folderName );
    }
}
